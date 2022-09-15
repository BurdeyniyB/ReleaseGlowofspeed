using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagerQuest : MonoBehaviour
{
    public string[] SceneName;
    public Button PlayButton;
    int sound = 0;
    int AudioPrefs = 0;
    private string Prefs = "SettingSound";
    private int random;
    //нажатие//
    void Start()
    {
        sound =  PlayerPrefs.GetInt("sound");
        AudioPrefs = PlayerPrefs.GetInt(Prefs);
        if (sound == 1)
        {
          if(AudioPrefs == 1)
         {
          GetComponent<AudioSource>().Play();
          Debug.Log("Audiosourse");
          sound = 0;
          PlayerPrefs.SetInt("sound", sound);
         }
          else
          {
          Debug.Log("Audiosourse.False");
          sound = 0;
          PlayerPrefs.SetInt("sound", sound);
          }
        }
        PlayButton.onClick.AddListener (Task);
    }

     //переход на сцену//
    public void Task()
    {
      Time.timeScale = 1;
      sound =  PlayerPrefs.GetInt("sound");
      sound = 1;
      PlayerPrefs.SetInt("sound", sound);

      PlayerPrefs.SetInt("GPGSUnlockSave", 1);
      
      int NewQuest = PlayerPrefs.GetInt("NewQuest");
        if (NewQuest == 1)
        {
            PlayerPrefs.SetInt("NewQuest", 0);
            int randomload = PlayerPrefs.GetInt("QuestSceneSave");
            while (randomload == random)
            {
              random = Random.Range(0, SceneName.Length);
            }
            PlayerPrefs.SetInt("QuestSceneSave", random);
        }
        else
        {
            random = PlayerPrefs.GetInt("QuestSceneSave");
        }

      SceneManager.LoadScene(SceneName[random]);
      int Stop = 1;
      PlayerPrefs.SetInt("StopRoad", Stop);
    }
    
}