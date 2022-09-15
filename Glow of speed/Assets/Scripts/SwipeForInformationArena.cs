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
public class SwipeForInformationArena : MonoBehaviour, IDragHandler, IBeginDragHandler
{
   public LevelManager _LevelManager;
   public LevelManager _LevelManager1;
   public int SwipeAudio = 0;


   public void OnBeginDrag(PointerEventData eventData)

{

     if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))

     {

            if (eventData.delta.x < 0)  
            {
                Debug.Log("swipeRight");
                _LevelManager.Task();
            }
            else 
            {
                 Debug.Log("swipeLeft");
                _LevelManager1.Task();
            }
     }
}
 public void OnDrag(PointerEventData eventData)

{
}

}
