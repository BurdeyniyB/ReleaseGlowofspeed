using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject Panel;
    public GameObject timeobject1;
    public int x = 4;
    public float coroutinetime = 1f;
    int Stop = 1;
    private Text timetext;
   void Start()
    {
      PlayerPrefs.SetInt("StopRoad", Stop);
      timetext = GameObject.Find("TimeMenu").GetComponent<Text>();
      timeobject1.SetActive(false);
    }
    void Update()
    {

    }
    void CoinActive()
    {
       if (x != 1)
       {
         timeobject1.SetActive(true);
           x--;
           Debug.Log(x);
           timetext.text = x.ToString("D1");
           Invoke("CoinActive", coroutinetime);
           Panel.SetActive(false);
       }
       else
       {
         x = 4;
         Invoke("Invoke", 0);
       }
    }
    public void MenuLeave()
    {
      Stop = 0;
      PlayerPrefs.SetInt("StopRoad", Stop);
      Panel.SetActive(true);
    }
    public void Continue()
    {
        CoinActive();
    }
    void Invoke()
    {
        timeobject1.SetActive(false);
         Debug.Log("fff");
         Stop = 1;
         PlayerPrefs.SetInt("StopRoad", Stop);
         Panel.SetActive(false);
    }
}
