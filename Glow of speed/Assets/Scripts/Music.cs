using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Music : MonoBehaviour
{
    bool music = true;

    void Awake(){
        music = true;
         Debug.Log(music);
         if (music == false) {
            AudioListener.pause = true;
             Debug.Log(music);
        }
        else
        {
            AudioListener.pause = false; Debug.Log(music);
        }
    }
    void Update(){
         music = PlayerPrefs.GetInt("foo")==1?true:false;
         if (music == false) {
             AudioListener.pause = false;
        }
        else
        {
            AudioListener.pause = true;
           
        }
    }
    public void onClick()
    {   
        
        if (music == false) {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
        music=! music;
        PlayerPrefs.SetInt("foo",  music?1:0);
    }

}