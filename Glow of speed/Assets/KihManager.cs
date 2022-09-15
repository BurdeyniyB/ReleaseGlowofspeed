using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class KihManager : MonoBehaviour
{
    public Text[] x;
    private string load;
    private int LoadX;
     void Update()
    {
        for (int i = 1; i <= x.Length; i++)
        {
            load = "x" + i;
            Debug.Log("x losd - " + load);
            LoadX = PlayerPrefs.GetInt(load);
            x[i - 1].text = LoadX.ToString("D1");
        }
    }
}
