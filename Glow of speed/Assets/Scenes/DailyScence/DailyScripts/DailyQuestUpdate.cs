using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DailyQuestUpdate : MonoBehaviour
{
    [Header("Все квесты")]
   public GameObject[] Quest;
   public string SaveRewardUpadete;
   private int Save;
   public float betweenx;
   public float posx = 0f;
   private int ClickForpadate = 0;
   int x;
   int y;
   int z;
   int first = 0;
     void Start()
    {
      first = PlayerPrefs.GetInt("ClickForpadate");

     ClickForpadate = PlayerPrefs.GetInt("ClickForpadate");
     Save = PlayerPrefs.GetInt("Earneg");
     if (Save == 0)
     {
        for(int i = 1; i <= 3; i++) 
        {
        x = PlayerPrefs.GetInt("QuestUpdateX");

        if (i == 2)
          {
           x = PlayerPrefs.GetInt("QuestUpdateY");
          }
          if (i == 3)
          {
           x = PlayerPrefs.GetInt("QuestUpdateZ");
          }
          float pos = posx + betweenx * i;
          Quest[x].transform.localPosition = new Vector3(pos, 0f, 0f);
        }
     }
     else
     {
     Save = PlayerPrefs.GetInt(SaveRewardUpadete);
     Debug.Log("Save = " + Save);
     if (Save == 1)
     {
         Debug.Log("Save 1 True");
        for(int i = 1; i <= 3; i++) 
        {
          x = Random.Range(0, Quest.Length);
          if (i == 2)
          {
            while(x == y)
            {
             x = Random.Range(0, Quest.Length);
            }
          }
          if (i == 3)
          {
              while(x == y || x == z)
            {
             x = Random.Range(0, Quest.Length);
            }

          }
          float pos = posx + betweenx * i;
          Quest[x].transform.localPosition = new Vector3(pos, 0f, 0f);
          Debug.Log("x = " + x);
          if (i == 1)
          {
            y = x;
            Debug.Log("y = " + y);
          }
          if (i == 2)
          {
            z = x;
            Debug.Log("y = " + y);
            Debug.Log("z = " + z);
          }
        }
        PlayerPrefs.SetInt("ClickForpadate", 0);
        PlayerPrefs.SetInt("QuestUpdateX", x);
        PlayerPrefs.SetInt("QuestUpdateY", y);
        PlayerPrefs.SetInt("QuestUpdateZ", z);
     }   
     else
     {
       Save = PlayerPrefs.GetInt("Earneg");
     if (Save == 1)
     {
         Debug.Log("Save 2 True");
       for(int i = 1; i <= 3; i++) 
        {
          int x = Random.Range(0, Quest.Length);
          Quest[x].transform.localPosition += new Vector3(posx, 0f, 0f);
          posx = posx + betweenx;
        }
       PlayerPrefs.SetInt(SaveRewardUpadete, 1);
       PlayerPrefs.SetInt("ClickForpadate", 0);
     }
     }
     }
    }

}
