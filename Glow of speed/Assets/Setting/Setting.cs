using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    int sound;
    int music;
    int vibration;
    public GameObject[] Zamok;
    void Update()
    {
        sound = PlayerPrefs.GetInt("SettingSound");
        music = PlayerPrefs.GetInt("SettingMusic");
        vibration = PlayerPrefs.GetInt("SettingVibration");

      if(sound == 0)
      {
       Zamok[0].SetActive(true);
      }
      else
      {
        Zamok[0].SetActive(false);
      }

      if(music == 0)
      {
       Zamok[1].SetActive(true);
      }
      else
      {
        Zamok[1].SetActive(false);
      }

      if(vibration == 0)
      {
       Zamok[2].SetActive(true);
      }
      else
      {
        Zamok[2].SetActive(false);
      }
    }

    public void Sound()
    {
      if(sound == 0)
      {
       sound = 1;
       PlayerPrefs.SetInt("SettingSound", sound);
       Debug.Log("SettingSound = " + sound);
      }
      else
      {
       sound = 0;
       PlayerPrefs.SetInt("SettingSound", sound);
       Debug.Log("SettingSound = " + sound);
      }
    }

    public void Music()
    {
      if(music == 0)
      {
       music = 1;
       PlayerPrefs.SetInt("SettingMusic", music);
       Debug.Log("SettingMusic = " + music);
      }
      else
      {
       music = 0;
       PlayerPrefs.SetInt("SettingMusic", music);
       Debug.Log("SettingMusic = " + music);
      }
    }
    public void Vibration()
    {
      if(vibration == 0)
      {
       vibration = 1;
       PlayerPrefs.SetInt("SettingVibration", vibration);
       Debug.Log("SettingVibration = " + vibration);
      }
      else
      {
       vibration = 0;
       PlayerPrefs.SetInt("SettingVibration", vibration);
       Debug.Log("SettingVibration = " + vibration);
      }
    }
}
