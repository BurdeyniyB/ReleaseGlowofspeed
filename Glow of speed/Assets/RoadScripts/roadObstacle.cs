using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadObstacle : MonoBehaviour
{
    //урон получаемый от столкновени с препядствием
    public int damage = 1;
    public bool max;
    private int wallobstane = 0;
    private string wallobstanetext;
    private int lvl;
    private const string SelectedSkin = "SelectedSkin";
    int AudioPrefs = 0;
    private string Prefs = "SettingVibration";
    private int shield;
    void Start()
    {
        lvl = PlayerPrefs.GetInt(SelectedSkin, 0);
        wallobstanetext = "wallobstane" + lvl;
        wallobstane = PlayerPrefs.GetInt(wallobstanetext);
        if (damage <= wallobstane)
        {
            damage = 1;
        }
        else
        {
            damage = damage - wallobstane;
        }
        AudioPrefs = PlayerPrefs.GetInt(Prefs);
    }
    void Update()
    {
        AudioPrefs = PlayerPrefs.GetInt(Prefs);
        
        shield = PlayerPrefs.GetInt("ShieldArena");

        if(max == false)
        {
        damage = PlayerPrefs.GetInt("roaddamage");
        }

        if (damage <= wallobstane)
        {
            damage = 1;
        }
        else
        {
            damage = damage - wallobstane;
        }
    }
   void OnTriggerEnter2D(Collider2D other)
   {
    //обращение к персонажу
     if (other.CompareTag("Player"))
     {
         //берем и вызываем с компонента герой переменую здоровье 
         //важно чтобы скрипт с нужной нам переменой был на игроке
           other.GetComponent<Hero>().health -= damage;
           PlayerPrefs.SetInt("HealthTextManager", damage);
         
         PlayerPrefs.SetInt("RetractionDamage", 1);
         Debug.Log(other.GetComponent<Hero>().health);
         if(AudioPrefs == 1)
       {
           Handheld.Vibrate();
           Debug.Log("Handheld.Vibrate");
       }
       else
       {
           Debug.Log("Handheld.Vibrate.False");
       }
         if(other.GetComponent<Hero>().health == 0)
        {
          Time.timeScale = 0;
        }
     }
   }
}
