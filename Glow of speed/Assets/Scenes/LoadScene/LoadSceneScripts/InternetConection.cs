using System;
using System.Collections;
using System.Collections.Generic;
using N.Fridman.DailyReward.Scripts.Structs;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Unity.RemoteConfig;

public class InternetConection : MonoBehaviour
{
        public Image Fill;
        public Text version_control;
        public Text version_control_False;
        public string SceneName;
        [SerializeField] private string serverUri;
        public bool isNetworkError;
        public bool isHttpError;
        public bool isLoaded;
        private int LoadInt;
        public GameObject Panel;
        public GameObject Panel_UGV;
        public LoadSceneRange _LoadSceneRange;
        private string Application_version;
        public string version;
        public struct userAttributes { };
        public struct appAttributes { };

    private IEnumerator SendRequest()
        {
            Debug.Log("yes");

            UnityWebRequest request = UnityWebRequest.Get(this.serverUri);
            Debug.Log("UnityWebRequest request yes");
            yield return request.SendWebRequest();
            Debug.Log("request.SendWebRequest() yes");

            if (request.isNetworkError)
            {
                this.isNetworkError = true;
                this.isLoaded = true;
                Debug.Log("{GameLog} => [DailyRewardComponent] - (<color=yellow>Network Error</color>) -> " + request.error);  
                Panel.SetActive(true);          
                yield break;
            }
            else
            {
                Debug.Log("Network not " + request.isNetworkError);
                Fill.fillAmount = 0.5f;
            }
            if (request.isHttpError)
             {
                this.isHttpError = true;
                this.isLoaded = true;
                Panel.SetActive(true); 
                Debug.Log("{GameLog} => [DailyRewardComponent] - (<color=yellow>Http Error</color>) -> " + request.error);                
             }    
             else
             {
                _LoadSceneRange.Rangeforload();
             }

        }
        public IEnumerator Load(int _range)
        {
          while (LoadInt != 5)
           {
               if(LoadInt == 2)
               {
                 double preopor = _range * 0.01;
                 Debug.Log("(float)preopor = " + (float)preopor);
                 Fill.fillAmount = (float)preopor;

               }

               if(LoadInt == 3)
               {
                 Fill.fillAmount = 1f;
               }

               if(LoadInt == 4)
               {
                Debug.Log("LoadScene");
                int x = PlayerPrefs.GetInt("LoadSavedStringString");
                 if(version == Application_version)
                 {
                   Debug.Log(version + "==" + Application_version);
                   SceneManager.LoadScene(SceneName);
                   PlayerPrefs.SetInt("LoadSavedStringString", 0);
                 }
                 else
                 {
                   Panel_UGV.SetActive(true); 
                   Debug.Log(version + "!=" + Application_version);
                   version_control_False.text = version;
                 }
     
               }

              LoadInt++;
              Debug.Log("LoadInt = " + LoadInt);
              yield return new WaitForSeconds(2f);
           }
           Fill.fillAmount = 1f;
           yield return new WaitForSeconds(2f);
        }

        public void LoadRange(int _range)
        {
          StartCoroutine(Load(_range));
        }

        public void RestartGame()
        {
          SceneManager.LoadScene("LoadScene");
        }

       private void Awake()
        {
          version_control.text = Application.version + " version";
          StartCoroutine(SendRequest());
        }
        void Applicat()
       {
          ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
          Debug.Log(ConfigManager.appConfig.GetString("version"));
          version = ConfigManager.appConfig.GetString("version");
          Debug.Log("version = " + version);

          Application_version = Application.version + "version";
          Debug.Log("Application.version = " + Application_version);
        }
       void Update()
        {
          Applicat();
        }
}

