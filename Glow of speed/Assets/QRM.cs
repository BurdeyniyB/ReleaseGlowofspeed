using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class QRM : MonoBehaviour
{
    public Text timer;
    private int My_Time = 0;
    public int star;
    private int Stop;
    bool x = true;
    public LevelManager _levelmanager;
    public string Save;
    private int BestResult;
    public string BestResultSave;

    void Start()
    {
        BestResult = PlayerPrefs.GetInt(BestResultSave);
        StartCoroutine(TimeFlow());
    }

    void Update()
    {
        Stop = PlayerPrefs.GetInt("StopRoad");
    }

     IEnumerator TimeFlow()
    {
        while(x){
            if(Stop == 1)
            {
                Debug.Log("QRMTimeFlow");
               if(My_Time < star)
               {
                   Debug.Log("QRMTimeFlow");
                   My_Time++;
                   PlayerPrefs.SetInt(Save, My_Time);
                   if(BestResult < My_Time)
                   {
                      PlayerPrefs.SetInt(BestResultSave, My_Time);
                   }
                   timer.text = "S : " + My_Time.ToString("D1");
               }
               else
               {
                  _levelmanager.Task();
               }
            }
    
            yield return new WaitForSeconds(1f);
        }
    }
}
