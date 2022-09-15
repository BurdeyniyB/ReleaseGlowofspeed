using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrue : MonoBehaviour
{
    int Audio = 0;
    public int save;
    public string Prefs;

    void Update()
    {
       Debug.Log("save = " + save + "Audio" + Audio);

       Audio = PlayerPrefs.GetInt(Prefs);
       Debug.Log("Audio = " + Audio);
       if((Audio != save))
       {
       Debug.Log("SettingMusic function");
       save = Audio;
       Debug.Log("save = " + save);
       if(Audio == 1)
       {
           GetComponent<AudioSource>().Play();
           Debug.Log("SettingMusicTrue");
       }
       else
       {

           GetComponent<AudioSource>().Pause();
           Debug.Log("SettingMusicFalse");
       }
       }
     }
}
