using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControler : MonoBehaviour
{
    public int bombadamage;
    public int spikedamage;
    public int spiketoxicant;
    public int roaddamage;
    public int speedUpAssel;
    public int circledamage;
    public int circlecritdamage;
    void Update()
    {
       PlayerPrefs.SetInt("bombadamage", bombadamage); 
       PlayerPrefs.SetInt("spikedamage", spikedamage); 
       PlayerPrefs.SetInt("spiketoxicant", spiketoxicant); 
       PlayerPrefs.SetInt("roaddamage", roaddamage);
       PlayerPrefs.SetInt("speedUpAssel", speedUpAssel);
       PlayerPrefs.SetInt("circledamage", circledamage);
       PlayerPrefs.SetInt("circlecritdamage", circlecritdamage);
    }
}
