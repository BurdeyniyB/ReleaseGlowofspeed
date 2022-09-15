using N.Fridman.DailyReward.Scripts;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private DailyRewardComponent dailyReward;
        
        public Text text;
        public string SceneName;
        public string SaveText;

        private void Start()
        {
            StartCoroutine(dailyReward.CheckDailyReward(day =>
            {
                if (day == -1)
                {
                    // Нет подлючения к интернету
                    Debug.Log("Not Internet Connection");
                    text.text = "Not Internet Connection";
                }

                if (day == -2)
                {
                    // Http ошибка (4xx Response Code)
                    Debug.Log("Http Error!");
                    text.text = "Http Error!";
                }
                
                if (day == 0)
                {
                    // Игрок уже получал награду сегодня.
                    Debug.Log("Reward Earned Today");
                    text.text = "Reward Earned Today";
                }

                if (day >= 1)
                {
                    // Вручить награду.
                    Debug.Log("Day In Row -> " + day);
                    text.text = "Day In Row -> " + day.ToString("D1");
                    PlayerPrefs.SetInt(SaveText, 1);
                    Debug.Log(SaveText);
                    int d_r = PlayerPrefs.GetInt("FirstDailyreward");
                    if(d_r != 0)
                    {
                    SceneManager.LoadScene(SceneName);
                    }
                    else
                    {
                    PlayerPrefs.SetInt("FirstDailyreward", 1);
                    }
                }
            }));
        }
    }
}