using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedOpp : MonoBehaviour
{
    public Image Button;
    public Color selectColor;
    public string Select_Opp;
    private string Selected_Opp;
    void Start()
    {
       Selected_Opp = PlayerPrefs.GetString("opportunities"); 
       Debug.Log("Selected_Opp = " + Selected_Opp);     
       if(Select_Opp == Selected_Opp)  
       {
         Button.color = selectColor;
       }
    }


    public void Select()
    {
        Button.color = selectColor;
    }
}
