using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleFire : MonoBehaviour
{
   public Sprite skins;
   public int damage;
   public int critdamage;
   private int chance_critdamage = 100;
   private Animator anim;
   public int x = 1;
   public float coroutinetime = 1f;
   private int obstane = 0;
   private int obstanecritdamage;
   private int obstanechance_critdamage = 100;
   private string obstanetext;
   private string obstanecritdamagetext;
   private string obstanechance_critdamagetext;
   private int lvl;
   private const string SelectedSkin = "SelectedSkin";
   private int audio = 0;
   int AudioPrefs = 0;
   private string Prefs = "SettingVibration";
   private int shield;
   private int Randomfire;

    void Start()
    {
        
        lvl = PlayerPrefs.GetInt(SelectedSkin, 0);
        obstanetext = "obstane" + lvl;
        obstane = PlayerPrefs.GetInt(obstanetext);

        obstanecritdamagetext = "critical_damage" + lvl;
        obstanecritdamage = PlayerPrefs.GetInt(obstanecritdamagetext);

        obstanechance_critdamagetext = "chance_of_crit_damage" + lvl;
        obstanechance_critdamage = PlayerPrefs.GetInt(obstanechance_critdamagetext);

        if (damage <= obstane)
        {
            damage = 1;
        }
        else
        {
            damage = damage - obstane;
        }

        if (critdamage <= obstanecritdamage)
        {
            critdamage = 1;
        }
        else
        {
            critdamage = critdamage - obstanecritdamage;
        }

        if (chance_critdamage <= obstanechance_critdamage)
        {
            chance_critdamage = 1;
        }
        else
        {
            chance_critdamage = chance_critdamage - obstanechance_critdamage;
        }

        AudioPrefs = PlayerPrefs.GetInt(Prefs);
    }
    void Update()
    {
        AudioPrefs = PlayerPrefs.GetInt(Prefs);

        shield = PlayerPrefs.GetInt("ShieldArena");

        damage = PlayerPrefs.GetInt("circledamage");
        if (damage <= obstane)
        {
            damage = 1;
        }
        else
        {
            damage = damage - obstane;
        }

        critdamage = PlayerPrefs.GetInt("circlecritdamage");
        if (critdamage <= obstanecritdamage)
        {
            critdamage = 1;
        }
        else
        {
            critdamage = critdamage - obstanecritdamage;
        }

    }
   void OnTriggerEnter2D(Collider2D other)
   {
     if (other.CompareTag("Player"))
     {
         GetComponent<SpriteRenderer>().sprite = skins;
         Debug.Log(shield);
         if(shield == 0)
        {
            Debug.Log("damage");
           other.GetComponent<Hero>().health -= damage;
           PlayerPrefs.SetInt("HealthTextManager", damage);
        }
        PlayerPrefs.SetInt("RetractionDamage", 1);
        Randomfire = Random.Range(0, 100);
        if(Randomfire <= chance_critdamage)
        if(shield == 0)
        {
            Debug.Log("critdamage = " + critdamage);
           other.GetComponent<Hero>().health -= critdamage;
           PlayerPrefs.SetInt("FireTextManager", critdamage);
        }
        
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
           PlayerPrefs.SetInt("FireTextManager", damage);
           //this.gameObject.SetActive(false);
    }
   
    void AudioPlay()
    {
        PlayerPrefs.SetInt("audiobobm", 1);
    }
}
