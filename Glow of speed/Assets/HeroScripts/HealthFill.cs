using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthFill : MonoBehaviour
{
    public Image bar;
    public float fill;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       bar.fillAmount = fill; 
       fill = fill - 0.0001f;
    }
}
