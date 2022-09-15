using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class education : MonoBehaviour
{
    public string SaveText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
 void OnTriggerEnter2D(Collider2D other)
   {
     if (other.CompareTag("Player"))
     {
        PlayerPrefs.SetInt(SaveText, 1);
        Debug.Log(SaveText);
     }
   }
}
