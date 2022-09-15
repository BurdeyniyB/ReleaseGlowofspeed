using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
   public Sprite skins;
   public int damage;
   private Animator anim;
   public int x = 1;
   public float coroutinetime = 1f;
   private int obstane = 0;
   private string obstanetext;
   private int lvl;
   private const string SelectedSkin = "SelectedSkin";
   private int audio = 0;
   int AudioPrefs = 0;
   private string Prefs = "SettingVibration";
   private int shield;
   private float speedroad;
   private float speedroadtime;

    void Start()
    {
        
        lvl = PlayerPrefs.GetInt(SelectedSkin, 0);
        obstanetext = "obstane" + lvl;
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

        damage = PlayerPrefs.GetInt("bombadamage");
        if (damage <= obstane)
        {
            damage = 1;
        }
        else
        {
            damage = damage - obstane;
        }

     speedroad = PlayerPrefs.GetFloat("RoadUpdateSpeed");
     speedroadtime = (int)(1 / speedroad * 80);
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
        
         anim = GetComponent<Animator>();
         anim.SetTrigger("play");
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
        AudioPlay();
         Invoke("CoinActive", 0.3f);
      }
   }
    void CoinActive()
    {
       if (x != speedroadtime)
       {
           this.gameObject.SetActive(false);
           Invoke("CoinActive", coroutinetime);
           x++;
       }
       else
       {
         Invoke("Invoke", coroutinetime);
         x = 0;
       }
    }
    void AudioPlay()
    {
        PlayerPrefs.SetInt("audiobobm", 1);
        
    }
    void Invoke()
    {
        GetComponent<SpriteRenderer>().sprite = skins;
        this.gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().sprite = skins;
    }
}
