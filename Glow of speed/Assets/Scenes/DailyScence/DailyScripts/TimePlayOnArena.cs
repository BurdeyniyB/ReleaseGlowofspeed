using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePlayOnArena : MonoBehaviour
{
    public string Loadstring;
    private int numClick;
    //time_play_on_arena
    void Start()
    {
        numClick = PlayerPrefs.GetInt(Loadstring);
    }

    public void TouchButton()
    {
       numClick++;
       PlayerPrefs.SetInt(Loadstring, numClick);
    }
}
