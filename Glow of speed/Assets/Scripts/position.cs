using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class position : MonoBehaviour
{
    public GameObject image;
    public float speedRoad;
    public float positionx;
    public float positiony;
    private bool x = true;
    public float wait;
    public bool nodelta;
    private int Stop;

    private int Education1;
    private int Education2;
    private int Education3;
    private int Education4;
    private int Education5;

    private int SwipeRight;
    private int SwipeLeft;
    private int SwipeUp;
    private int SwipeDown;

    public GameObject Education1GameObject;
    public GameObject Education2GameObject;
    public GameObject Education3GameObject;
    public GameObject Education4GameObject;

    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(TimeFlow());
    }
    IEnumerator TimeFlow()
    {
        while(x){
            if (Time.deltaTime != 0)
            {
                if(Stop == 1)
               {
                 if(nodelta == false)
                 {
                 speedRoad = speedRoad + 0.1f;
                 }
               }
            }
            else
            {
                speedRoad = 0;
            }
            yield return new WaitForSeconds(wait);
        }
    }
    // Update is called once per frame
    void Update()
    {
         Stop = PlayerPrefs.GetInt("StopRoad");
         if(Stop == 1)
            {
         image.transform.localPosition -= new Vector3 (speedRoad * Time.deltaTime, 0f, 0f); 
         if (image.transform.localPosition.x <= -2960f) 
         {
             positionx = 2960f + 2960f + image.transform.localPosition.x;
             image.transform.localPosition = new Vector3(positionx, positiony, 0f);
         }
            }
                 if(nodelta == true)
                 {
                  Education1 = PlayerPrefs.GetInt("Education1");
                  Education2 = PlayerPrefs.GetInt("Education2");
                  Education3 = PlayerPrefs.GetInt("Education3");
                  Education4 = PlayerPrefs.GetInt("Education4");
                  Education5 = PlayerPrefs.GetInt("Education5");

                  SwipeRight = PlayerPrefs.GetInt("SwipeRight");
                  SwipeLeft = PlayerPrefs.GetInt("SwipeLeft");
                  SwipeUp = PlayerPrefs.GetInt("SwipeUp");
                  SwipeDown = PlayerPrefs.GetInt("SwipeDown");

                  if(Education1 == 1)
                  {
                   speedRoad = 0;
                   Education1GameObject.SetActive(true);
                   if(SwipeUp == 1)
                   {
                   speedRoad = 8;
                   Education1GameObject.SetActive(false);
                   PlayerPrefs.SetInt("SwipeUp", 0);
                   PlayerPrefs.SetInt("Education1", 0);
                   }
                  }

                  if(Education2 == 1)
                  {
                   speedRoad = 0;
                   Education2GameObject.SetActive(true);
                   if(SwipeDown == 1)
                   {
                   speedRoad = 8;
                   Education2GameObject.SetActive(false);
                   PlayerPrefs.SetInt("SwipeDown", 0);
                   PlayerPrefs.SetInt("Education2", 0);
                   }
                  }

                  if(Education3 == 1)
                  {
                   speedRoad = 0;
                   Education3GameObject.SetActive(true);
                   if(SwipeRight == 1)
                   {
                   speedRoad = 8;
                   Education3GameObject.SetActive(false);
                   PlayerPrefs.SetInt("SwipeRight", 0);
                   PlayerPrefs.SetInt("Education3", 0);
                   }
                  }

                  if(Education4 == 1)
                  {
                   speedRoad = 0;
                   Education4GameObject.SetActive(true);
                   if(SwipeRight == 1 || SwipeDown == 1 || SwipeUp == 1 || SwipeLeft == 1)
                   {
                   speedRoad = 8;
                   Education4GameObject.SetActive(false);
                   PlayerPrefs.SetInt("SwipeRight", 0);
                   PlayerPrefs.SetInt("SwipeLeft", 0);
                   PlayerPrefs.SetInt("SwipeUp", 0);
                   PlayerPrefs.SetInt("SwipeDown", 0);
                   PlayerPrefs.SetInt("Education4", 0);
                   }
                  }

                  if(Education5 == 1)
                  {
                   PlayerPrefs.SetInt("Education5", 0);
                   SceneManager.LoadScene("rewardforArena 1");
                  }

                   PlayerPrefs.SetInt("SwipeRight", 0);
                   PlayerPrefs.SetInt("SwipeLeft", 0);
                   PlayerPrefs.SetInt("SwipeUp", 0);
                   PlayerPrefs.SetInt("SwipeDown", 0);
                 }
    }
}
