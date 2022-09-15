using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadUpdate : MonoBehaviour
{
   private List<GameObject> ReadyRoad = new List<GameObject>();

   [Header("Все участкм дороги")]
   public GameObject[] Road;

   public bool[] roadNumbers;

   [Header("Текущая длина дороги")]
   public int currentRoadLength = 0;

   [Header("Максимальная длиа дороги")]
   public int maxmunRoadLegth = 6;

   [Header("Дистанция между дорогами")]
   public float distanceBetweenRoads;

   [Header("Скорость перемещения дороги")]
   public float speedRoad = 5;
   [Header("Постояная скорость перемещения дороги")]
   public float constspeedRoad = 10;
   
   [Header("Позиция Х при которой исчезает дорога")]
   public float maximumPositionX = -15;

   [Header("Задержка")]
   public float wait;

   [Header("Зона ожидаия")]
   public Vector3 waitingZona = new Vector3(-40, 0, 0);

   private int currentRoadNumber = -1;

   private int lastRoadNumber = -1;

   [Header("Статус генерации")]
   public string roadGenerationStatus = "Generatration";

   [Header("Рекорд")]
   public int record;
   [Header("Скорость ускорения дороги")]
   public float speedRoadAcceleration;
   private bool x = true;
   private int bestrecord;
   private int b = 1;
   private Text recordtext;
   private Text bestrecordtext;
   public float waitrecord;
   int Stop = 1;
   float speedRoad1;
   private int recordinrace;

   private float speed = 0;
   private double speedtime;
   private string speedtext;
   private int lvl;
   private const string SelectedSkin = "SelectedSkin";
   private string lvlSkintext;
   private int lvlSkin = 0;
   private string speedtextlvl;
   private double SpeedLvlManager;
   [Header("Текс для сохранения рекорда")]
   public string bestrecord_str;
   [Header("Accelerator")]
   public float Accelerator = 0;
   public float max_Accelerator = 0;
   [Header("Arena r")]
   public int Arena_r = 0;


void Start()
    {
        Accelerator = 0;
        Debug.Log("Accelerato TimeFlow = " + Accelerator);
        StartRaceArena();
        recordinrace = PlayerPrefs.GetInt("recordinrace");
        speedRoad1 = speedRoad;
        PlayerPrefs.SetFloat("RoadUpdateSpeed", speedRoad1);
        recordtext = GameObject.Find("record").GetComponent<Text>();
        recordtext.text = record.ToString();
        bestrecordtext = GameObject.Find("bestrecord").GetComponent<Text>();
        bestrecord = PlayerPrefs.GetInt(bestrecord_str);
        bestrecordtext.text = bestrecord.ToString();

        lvl = PlayerPrefs.GetInt(SelectedSkin, 0);
        speedtext = "speed" + lvl;
        speed = PlayerPrefs.GetFloat(speedtext);
        speedtime = speed / 50000;
        Debug.Log("Arena Sprite speed = " + speed);

        lvl = PlayerPrefs.GetInt(SelectedSkin, 0);
        lvlSkintext = "lvlSkin" + lvl;
        lvlSkin = PlayerPrefs.GetInt(lvlSkintext);
        Debug.Log("lvlSkin = " + lvlSkin);

        speedtextlvl = "speed" + lvl;    
        SpeedLvlManager = PlayerPrefs.GetFloat(speedtextlvl);  

        StartCoroutine(TimeFlow());
        StartCoroutine(Record());
 
        Debug.Log("My speed = " + (float)SpeedLvlManager);
        Debug.Log("My speed 1 = " + speedRoad1);
        Debug.Log("My speed speedRoadAcceleration = " + speedRoadAcceleration);
    }

   IEnumerator TimeFlow()
    {
        while(x){
            if(Stop == 1)
            {
            speedRoad1 = PlayerPrefs.GetFloat("RoadUpdateSpeed");
            if(SpeedLvlManager < speedRoadAcceleration)
            {
              speedRoad1 = (float)((float)speedRoad1 + ((speedRoadAcceleration - (float)SpeedLvlManager) * 0.001));
              if(speedRoad1 < 0.13)
              {
                speedRoad1 = (float)((float)speedRoad1 + 0.13);
              }
              if(speedRoad1 > 0.4)
              {
                speedRoad1 = (float)((float)speedRoad1 + 0.4);
              }
            }
            else
            {
              speedRoad1 = (float)((float)speedRoad1 + (0.1));
            }
            Debug.Log("My speed TimeFlow = " + speedRoad1);

            if(max_Accelerator >= Accelerator)   
            {
               Debug.Log("Accelerato TimeFlow = " + Accelerator);
               speedRoad1 += Accelerator;
            }    
            Accelerator = 0;
            speedRoad = speedRoad1;
            }
            else
            {
               speedRoad = 0; 
            }

            yield return new WaitForSeconds(wait);
        }
    }
    IEnumerator Record()
    {
      Debug.Log("Status IEnumerator Record = " + Stop);
        while(x){
          Debug.Log("Status IEnumerator Record x = " + x);
           if(Stop == 1)
            {
            recordvoid();
            }
            yield return new WaitForSeconds(waitrecord);
        }
    }
    private void recordvoid()
    {
      Debug.Log("Status recordvoid = " + Stop);
        waitrecord = waitrecord - 0.001f - (float)speedtime * 0.1f;
        speedtime = speedtime * 0.92;
      if(Stop == 1)
      {
        Debug.Log("Status Stop = " + Stop);
          if(lvlSkin < 1)
          {
            record = record + 1;
          }
          else
          {
            record = record + lvlSkin + (int)(Arena_r * lvlSkin * 0.01);
          }
        recordinrace = recordinrace + lvlSkin;
        PlayerPrefs.SetInt("recordinonerace", record);
        PlayerPrefs.SetInt("recordinrace", recordinrace);
      }
      bestrecord = PlayerPrefs.GetInt(bestrecord_str);
      if (record > bestrecord)
      {
          bestrecord = record;
          PlayerPrefs.SetInt(bestrecord_str, bestrecord);
      }
    }
     void Update()
    {
        int StopRecord = PlayerPrefs.GetInt("StopRoad");
        if (StopRecord > Stop)
        {
          Debug.Log("Status IEnumerator Record Update");
          StartCoroutine(Record());
        }
        PlayerPrefs.SetFloat("RoadUpdateSpeed", speedRoad1);
        Stop = PlayerPrefs.GetInt("StopRoad");
        recordtext.text = record.ToString("D1");
        bestrecordtext.text = bestrecord.ToString("D1");
        Debug.Log("Status IEnumerator Record x = " + x);
        if(Stop == 0)
        {
               speedRoad = 0; 
        }
        else
        {
            speedRoad1 = PlayerPrefs.GetFloat("RoadUpdateSpeed");
            speedRoad = speedRoad1;
        }
    }
   private void FixedUpdate()
   {
      if (roadGenerationStatus == "Generatration")
      {
        if (currentRoadLength != maxmunRoadLegth)
        {
          currentRoadNumber = Random.Range(0, Road.Length - 1);

          if (currentRoadNumber != lastRoadNumber)
          {
              if (currentRoadNumber < Road.Length / 2)
              {
                if (roadNumbers[currentRoadNumber] != true)
                {
                    if (lastRoadNumber != (Road.Length / 2) + currentRoadNumber)
                    {
                        RoadCreation();
                    }
                    else if (lastRoadNumber != (Road.Length / 2) + currentRoadNumber && currentRoadLength == Road.Length - 1)
                    {
                        RoadCreation();
                    }
                }
              }
              else if (currentRoadNumber >= Road.Length / 2)
              {
                   if (roadNumbers[currentRoadNumber] != true)
                   {
                        if (lastRoadNumber != currentRoadNumber - (Road.Length / 2))
                     {
                        RoadCreation();
                     }
                        else if (lastRoadNumber !=  currentRoadNumber - (Road.Length / 2)  && currentRoadLength == Road.Length - 1)
                     {
                        RoadCreation();
                     }
                   }
              }
          }
        }

        MovingRoad();
        if (ReadyRoad.Count != 0)
        {
            RemovingRoad();
        }
      }
   }

         public void StartRaceArena()
        {
          if (roadGenerationStatus == "Generatration")
      {
        if (currentRoadLength != maxmunRoadLegth)
        {
          currentRoadNumber = Road.Length - 1;

          if (currentRoadNumber != lastRoadNumber)
          {
              if (currentRoadNumber < Road.Length / 2)
              {
                if (roadNumbers[currentRoadNumber] != true)
                {
                    if (lastRoadNumber != (Road.Length / 2) + currentRoadNumber)
                    {
                        RoadCreation();
                    }
                    else if (lastRoadNumber != (Road.Length / 2) + currentRoadNumber && currentRoadLength == Road.Length - 1)
                    {
                        RoadCreation();
                    }
                }
              }
              else if (currentRoadNumber >= Road.Length / 2)
              {
                   if (roadNumbers[currentRoadNumber] != true)
                   {
                        if (lastRoadNumber != currentRoadNumber - (Road.Length / 2))
                     {
                        RoadCreation();
                     }
                        else if (lastRoadNumber !=  currentRoadNumber - (Road.Length / 2)  && currentRoadLength == Road.Length - 1)
                     {
                        RoadCreation();
                     }
                   }
              }
          }
        }

        MovingRoad();
        if (ReadyRoad.Count != 0)
        {
            RemovingRoad();
        }
      }
   }

   private void MovingRoad()
   {
     foreach (GameObject readyRoad in ReadyRoad)
     {
         readyRoad.transform.localPosition -= new Vector3 (speedRoad * Time.fixedDeltaTime, 0f, 0f);  
     }
   }
   private void RemovingRoad()
   { 
     if (ReadyRoad[0].transform.localPosition.x < maximumPositionX)
     {
         int i;
         i = ReadyRoad[0].GetComponent<Road>().number;
         roadNumbers[i] = false;
         ReadyRoad[0].transform.localPosition = waitingZona;
         ReadyRoad.RemoveAt(0);
         currentRoadLength--;
     }
   }
   private void RoadCreation()
   {
    if (ReadyRoad.Count > 0)
    {
        Road[currentRoadNumber].transform.localPosition = ReadyRoad[ReadyRoad.Count - 1].transform.position + new Vector3(distanceBetweenRoads, 0f, 0f);
    }
    else if (ReadyRoad.Count == 0)
    {
        Road[currentRoadNumber].transform.localPosition = new Vector3(0f, 0f, 0f);
    }
    Road[currentRoadNumber].GetComponent<Road>().number = currentRoadNumber;

    roadNumbers[currentRoadNumber] = true;

    lastRoadNumber = currentRoadNumber;

    ReadyRoad.Add(Road[currentRoadNumber]);

    currentRoadLength++;
   }
}
