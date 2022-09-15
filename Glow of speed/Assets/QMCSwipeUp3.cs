using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;


public class QMCSwipeUp3 : MonoBehaviour, IDragHandler, IBeginDragHandler
{
   public GameObject Player;
   public int GameObjectLength;
   public GameObject[] DamageText;
   public int SwipeAudio = 0;
   public float Xswipe;
   public float Yswipe;
   public float DeltaDamageText;

   public void OnBeginDrag(PointerEventData eventData)

{
     SwipeAudio = PlayerPrefs.GetInt("SwipeAudio");
     if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))

     {

            if (eventData.delta.x < 0)  {
                if (Player.transform.localPosition.x < 22f )
                {
                  Player.transform.localPosition += new Vector3 (Xswipe, 0f, 0f);
                  SwipeAudio = 1;
                  Debug.Log("Swipe");
                  PlayerPrefs.SetInt("SwipeAudio", SwipeAudio);
                  for (int i = 0; i <= GameObjectLength; i++)
                  {
                      DamageText[i].transform.localPosition += new Vector3 (Xswipe * DeltaDamageText, 0f, 0f);
                  }
                }
            }
            else {
                if (Player.transform.localPosition.x > -18f )
                {
                  Player.transform.localPosition -= new Vector3 (Xswipe, 0f, 0f);
                  SwipeAudio = 1;
                  Debug.Log("Swipe");
                  PlayerPrefs.SetInt("SwipeAudio", SwipeAudio);
                  for (int i = 0; i <= GameObjectLength; i++)
                  {
                      DamageText[i].transform.localPosition -= new Vector3 (Xswipe * DeltaDamageText, 0f, 0f);
                  }
                }
            }
     }

     else

     {

            if (eventData.delta.y < 0)  { 
                 if (Player.transform.localPosition.y < 0f )
                {
                  Player.transform.localPosition += new Vector3 (0f, Yswipe, 0f);
                  SwipeAudio = 1;
                  Debug.Log("Swipe");
                  PlayerPrefs.SetInt("SwipeAudio", SwipeAudio);
                    for (int i = 0; i <= GameObjectLength; i++)
                  {
                      DamageText[i].transform.localPosition += new Vector3 (0f, Yswipe * DeltaDamageText, 0f);
                  }
                }
            }
            else  {
                if (Player.transform.localPosition.y > -3f )
                {
                  Player.transform.localPosition -= new Vector3 (0f, Yswipe, 0f);
                  SwipeAudio = 1;
                  Debug.Log("Swipe");
                  PlayerPrefs.SetInt("SwipeAudio", SwipeAudio);
                    for (int i = 0; i <= GameObjectLength; i++)
                  {
                      DamageText[i].transform.localPosition -= new Vector3 (0f, Yswipe * DeltaDamageText, 0f);
                  }
                }
            }
     }
}
 public void OnDrag(PointerEventData eventData)

{
}

}
