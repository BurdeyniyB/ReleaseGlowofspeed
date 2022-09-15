using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerNewDayUpdateDQ : MonoBehaviour
{
    public UpdateDailyQuest[] _updateDailyQuest;

    private int NewDay;
    public string NewDayLoadString;

    void Update()
    {
        NewDay = PlayerPrefs.GetInt(NewDayLoadString);
        Debug.Log("New Day = " + NewDay);
        if(NewDay == 1)
        {
            for (int i = 0; i < _updateDailyQuest.Length; i++)
            {
             _updateDailyQuest[i].NewDayVoid(i);   
             Debug.Log("New Day task " + i);
            }
           PlayerPrefs.SetInt(NewDayLoadString, 0);
           Debug.Log("New Day");
        }
        else
        {
            Debug.Log("False New Day");
        }
    }
}
