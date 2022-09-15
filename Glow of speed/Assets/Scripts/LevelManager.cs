using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public string SceneName;
    public Button PlayButton;
    int sound = 0;
    int AudioPrefs = 0;
    private string Prefs = "SettingSound";
    public bool Save_Scene = false;
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
      PlayerPrefs.SetString("LoadSceneforsave", SceneName);

      
      if(Save_Scene == true)
      {
        SceneManager.LoadScene("SaveScene");
      }
      else
      {
       SceneManager.LoadScene(SceneName);
      }
      int Stop = 1;
      PlayerPrefs.SetInt("StopRoad", Stop);
    }
    
}
