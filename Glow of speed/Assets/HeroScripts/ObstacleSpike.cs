using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpike : MonoBehaviour
{
   public Sprite skins;
   public int damage;
   public int toxicant;
   private Animator anim;
   public int x = 1;
   float coroutinetime = 0.5f;
   private int obstane = 0;
   private int poisoning = 0;
   private string obstanetext;
   private string poisoningtext;
   private int lvl;
   private const string SelectedSkin = "SelectedSkin";
   private int audio = 0;
   int AudioPrefs = 0;
   private string Prefs = "SettingVibration";
   private int shield;
   public Hero hero;

    void Start()
    {
        
        lvl = PlayerPrefs.GetInt(SelectedSkin, 0);
        obstanetext = "obstane" + lvl;
        obstane = PlayerPrefs.GetInt(obstanetext);
        poisoningtext = "poisoning" + lvl;
        poisoning = PlayerPrefs.GetInt(poisoningtext);
        if (damage <= obstane)
        {
            damage = 1;
        }
        else
        {
            damage = damage - obstane;
        }

        if (toxicant <= poisoning)
        {
            toxicant = 1;
        }
        else
        {
            toxicant = toxicant - poisoning;
        }

        AudioPrefs = PlayerPrefs.GetInt(Prefs);
    }
    void Update()
    {
        AudioPrefs = PlayerPrefs.GetInt(Prefs);

        shield = PlayerPrefs.GetInt("ShieldArena");

        damage = PlayerPrefs.GetInt("spikedamage");
        if (damage <= obstane)
        {
            damage = 1;
        }
        else
        {
            damage = damage - obstane;
        }

        toxicant = PlayerPrefs.GetInt("spiketoxicant");
        if (toxicant <= poisoning)
        {
            toxicant = 1;
        }
        else
        {
            toxicant = toxicant - poisoning;
        }

    }
   void OnTriggerEnter2D(Collider2D other)
   {
     if (other.CompareTag("Player"))
     {
         GetComponent<SpriteRenderer>().sprite = skins;
         if(shield == 0)
        {
           other.GetComponent<Hero>().health -= damage;
           PlayerPrefs.SetInt("HealthTextManager", damage);
        }
        PlayerPrefs.SetInt("RetractionDamage", 1);
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
         Invoke("CoinActive", 0.3f);
         AudioPlay();
      }
   }
    void CoinActive()
    {
       if (x != 3)
       {
           hero.health -= toxicant;
           PlayerPrefs.SetInt("audiospikeblody", 1);
           PlayerPrefs.SetInt("SpikeTextManager", toxicant);
           //this.gameObject.SetActive(false);
           Invoke("CoinActive", coroutinetime);
           x++;
       }
       else
       {
         hero.health -= toxicant;
         PlayerPrefs.SetInt("audiospikeblody", 1);
         PlayerPrefs.SetInt("SpikeTextManager", toxicant);
         Invoke("Invoke", coroutinetime);
         x = 0;
       }
    }
    void AudioPlay()
    {
        audio++;
        PlayerPrefs.SetInt("audiospike", audio);
    }
    void Invoke()
    {
        GetComponent<SpriteRenderer>().sprite = skins;
        //this.gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().sprite = skins;
    }
}
