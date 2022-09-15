using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSpeed : MonoBehaviour
{
   public Sprite skins;
   public int damage;
   public int x = 1;
   public RoadUpdate _roadUpdate;
   private int obstane = 0;
   private string obstanetext;
   private int lvl;
   private const string SelectedSkin = "SelectedSkin";
   private int audio = 0;
   int AudioPrefs = 0;
   private string Prefs = "SettingVibration";
   private int shield;

    void Start()
    {
        
        lvl = PlayerPrefs.GetInt(SelectedSkin, 0);
        obstanetext = "poisoning" + lvl;
        obstane = PlayerPrefs.GetInt(obstanetext);
        if (damage <= obstane)
        {
            damage = 1;
        }
        else
        {
            damage = damage - obstane;
        }
        AudioPrefs = PlayerPrefs.GetInt(Prefs);
    }
    void Update()
    {
        AudioPrefs = PlayerPrefs.GetInt(Prefs);

        shield = PlayerPrefs.GetInt("ShieldArena");
        damage = PlayerPrefs.GetInt("speedUpAssel");
        if (damage <= obstane)
        {
            damage = 1;
        }
        else
        {
            damage = damage - obstane;
        }
    }
   void OnTriggerEnter2D(Collider2D other)
   {
     if (other.CompareTag("Player"))
     {
         GetComponent<SpriteRenderer>().sprite = skins;
         Debug.Log(shield);
           _roadUpdate.Accelerator += (float)(damage * 0.15);
         Debug.Log("Speed obstacle " + damage);
        //PlayerPrefs.SetInt("HealthTextManager", damage);
      
        //PlayerPrefs.SetInt("RetractionDamage", 1);
        
         if(AudioPrefs == 1)
       {
           Handheld.Vibrate();
           Debug.Log("Handheld.Vibrate");
       }
       else
       {
           Debug.Log("Handheld.Vibrate.False");
       }
         if(other.GetComponent<Hero>().health <= 0)
        {
          Time.timeScale = 0;
          other.GetComponent<Hero>().health = 0;
        }
        CoinActive();
        AudioPlay();
      }
   }

     void CoinActive()
    {
           //PlayerPrefs.SetInt("audiospikeblody", 1);
           PlayerPrefs.SetInt("SpeedTextManager", damage);
           //this.gameObject.SetActive(false);
    }
   
    void AudioPlay()
    {
        PlayerPrefs.SetInt("SpeedObstacle", 1);
        
    }
}
