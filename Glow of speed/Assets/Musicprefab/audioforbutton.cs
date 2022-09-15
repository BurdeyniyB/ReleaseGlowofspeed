using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioforbutton : MonoBehaviour
{
    int Audio = 0;
    int sound;
    public string Prefs;
    void Awake()
    {
       PlayerPrefs.SetInt(Prefs, 0);
    }

    void Update()
    {
       sound = PlayerPrefs.GetInt("SettingSound");
        if(sound == 1)
        {
       Audio = PlayerPrefs.GetInt(Prefs);
       if(Audio == 1)
       {
           GetComponent<AudioSource>().Play();
           PlayerPrefs.SetInt(Prefs, 0);
           Debug.Log(Prefs);
       }
        }
    }
}
