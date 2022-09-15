using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextPosition : MonoBehaviour
{
   public GameObject image;
    public float speedRoad;
    public float positionx;
    public float positiony;
    private bool x = true;
    public float wait;
    private int Stop;
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
                 speedRoad = speedRoad + 0.1f;
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
         if (image.transform.localPosition.x >= -2960f) 
         {
             image.transform.localPosition -= new Vector3 (speedRoad * Time.deltaTime, 0f, 0f); 
         }
            }
    }
}
