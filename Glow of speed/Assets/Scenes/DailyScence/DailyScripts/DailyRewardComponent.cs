using System;
using System.Collections;
using N.Fridman.DailyReward.Scripts.Structs;
using UnityEngine;
using UnityEngine.Networking;

namespace N.Fridman.DailyReward.Scripts
{
    public class DailyRewardComponent : MonoBehaviour
    {
        [Header("Properties")] 
        public int serverTime;
        public int lastReceiveBonusTime;
        public int dayInRow;
        private int time = 86400;
        public int DayMaximum;
        [Space] 
        public bool isNetworkError;
        public bool isHttpError;
        public bool isLoaded;
        public bool isCompleteLoaded;
        public bool isLocalDataFounded;

        [Header("Settings")] 
        [SerializeField] private string localLastReceiveBonusTimeKey;
        [SerializeField] private string localDayInRowKey;
        [Space] 
        [SerializeField] private string serverUri;
        [Space]
        [SerializeField] private bool useLocalData;
        [SerializeField] private int localTime;

        private IEnumerator SendRequest()
        {
            UnityWebRequest request = UnityWebRequest.Get(this.serverUri);
            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                this.isNetworkError = true;
                this.isLoaded = true;
                Debug.Log("{GameLog} => [DailyRewardComponent] - (<color=yellow>Network Error</color>) -> " + request.error);                
                yield break;
            }

            if (request.isHttpError)
            {
                this.isHttpError = true;
                this.isLoaded = true;
                Debug.Log("{GameLog} => [DailyRewardComponent] - (<color=yellow>Http Error</color>) -> " + request.error);                
            }

            string json = request.downloadHandler.text;
            ServerTimeResponse response = JsonUtility.FromJson<ServerTimeResponse>(json);

            this.serverTime = response.unixtime;
            this.isCompleteLoaded = true;
            this.isLoaded = true;
        }

        public IEnumerator CheckDailyReward(Action<int> callback)
        {
            while (!this.isLoaded)
            {
                yield return new WaitForSeconds(0.25f);
            }

            if (this.isNetworkError)
            {
                callback(-1);
                yield break;
            }

            if (this.isHttpError)
            {
                callback(-2);
                yield break;
            }

            if (this.isCompleteLoaded)
            {
                CalculateDay();
                callback(this.dayInRow);
            }
        }
    
        private void LoadLocalData()
        {
            if (PlayerPrefs.HasKey(localLastReceiveBonusTimeKey) && PlayerPrefs.HasKey(localDayInRowKey))
            {
                this.lastReceiveBonusTime = PlayerPrefs.GetInt(localLastReceiveBonusTimeKey);
                this.dayInRow = PlayerPrefs.GetInt(localDayInRowKey);
                this.isLocalDataFounded = true;
            }
        }

        private void SetLastReceiveBonusTime()
        {
            this.lastReceiveBonusTime = this.serverTime;
            PlayerPrefs.SetInt(localLastReceiveBonusTimeKey, this.lastReceiveBonusTime);
            if(this.dayInRow > DayMaximum)
            {
                this.dayInRow = 1;
                Debug.Log("Save day 1");
            }
            PlayerPrefs.SetInt(localDayInRowKey, this.dayInRow);
        }

        private void CalculateDay()
        {
            if (!this.isLocalDataFounded)
            {
                this.dayInRow = 1;
                SetLastReceiveBonusTime();
            }

            if (this.isLocalDataFounded)
            {
                int timeDifference = this.serverTime - this.lastReceiveBonusTime;

                if (timeDifference <= time)
                {
                    this.dayInRow = 0;
                }

                if (timeDifference > time)
                {
                    this.dayInRow += 1;
                    SetLastReceiveBonusTime();
                }

            }
        }
    
        private void Awake()
        {
            if (this.useLocalData)
            {
                LoadLocalData();
                this.serverTime = this.localTime;
                this.isCompleteLoaded = true;
                this.isLoaded = true;
            }
            else
            {
                LoadLocalData();
                StartCoroutine(SendRequest());
            }
        }
    }
}
