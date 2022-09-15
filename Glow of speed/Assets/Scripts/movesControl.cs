using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class movesControl : MonoBehaviour
{
     public Button PlayButton;
     public Button PlayButtonfalse;
     public GameObject control;
     public GameObject controlroad;
     private Text timertext;
     private int num = 3;
    void Start()
    {
        timertext = GameObject.Find("Number").GetComponent<Text>();
        PlayButton.onClick.AddListener (Task);
        PlayButtonfalse.onClick.AddListener (Taskfalse);
    }
    void Task()
    {
        Time.timeScale = 0;
        control.SetActive(true);
        controlroad.SetActive(false);
    }
    void Taskfalse(){
        Time.timeScale = 1;
        timertext.text = num.ToString("D1");
        Invoke( "EnableGO", 1f );
    }
    void EnableGO()
    {
      control.SetActive(false);
      controlroad.SetActive(true);
    }
}
