using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject Panel;
    int sound = 0;
    int AudioPrefs = 0;
    private string Prefs = "SettingSound";
    //нажатие//
    void Start()
    {
        sound =  PlayerPrefs.GetInt("soundPanel");
        AudioPrefs = PlayerPrefs.GetInt(Prefs);
        if (sound == 1)
        {
          if(AudioPrefs == 1)
         {
          GetComponent<AudioSource>().Play();
          Debug.Log("Audiosourse");
          sound = 0;
          PlayerPrefs.SetInt("soundPanel", sound);
         }
          else
          {
          Debug.Log("Audiosourse.False");
          sound = 0;
          PlayerPrefs.SetInt("soundPanel", sound);
          }
        }
    }
    void Update()
    {
        sound =  PlayerPrefs.GetInt("soundPanel");
        AudioPrefs = PlayerPrefs.GetInt(Prefs);
        if (sound == 1)
        {
          if(AudioPrefs == 1)
         {
          GetComponent<AudioSource>().Play();
          Debug.Log("Audiosourse");
          sound = 0;
          PlayerPrefs.SetInt("soundPanel", sound);
         }
          else
          {
          Debug.Log("Audiosourse.False");
          sound = 0;
          PlayerPrefs.SetInt("soundPanel", sound);
          }
        }
    }
     //переход на сцену//
    public void Task()
    {
      Panel.SetActive(true);

      Time.timeScale = 1;
      sound =  PlayerPrefs.GetInt("soundPanel");
      sound = 1;
      PlayerPrefs.SetInt("soundPanel", sound);

      PlayerPrefs.SetInt("GPGSUnlockSave", 1);

    }
     
    public void Task1()
    {
      Panel.SetActive(false);

      Time.timeScale = 1;
      sound =  PlayerPrefs.GetInt("soundPanel");
      sound = 1;
      PlayerPrefs.SetInt("soundPanel", sound);

      PlayerPrefs.SetInt("GPGSUnlockSave", 1);

    }
    
}
