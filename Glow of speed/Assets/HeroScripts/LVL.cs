using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LVL : MonoBehaviour
{
    private const string SelectedSkin = "SelectedSkin";
    string Selected = "Selected";
    private string LVLtext;
    public Text Healthtext;
    public Text Obstanetext;
    public Text Wallobstanetext;
    public Text Speedtext;
    public Text LvlSkintext;
    public Text Coinstext;
    public Text ClientLvlLoadSavetext;
    public Text Moneytext;
    public Text Poisoningtext;
    public Text Critical_damagetext;
    public Text Chance_of_crit_damagetext;

    private int health = 100;
    private int obstane = 0;
    private int wallobstane = 0;
    private float speed = 0;
    private int poisoning = 0;
    private int critical_damage = 0;
    private int chance_of_crit_damage = 0;
    public double delta;
    private int lvlSkin = 0;
    private int coins = 0;

    private string healthtext;
    private string obstanetext;
    private string wallobstanetext;
    private string speedtext;
    private string poisoningtext;
    private string critical_damagetext;
    private string chance_of_crit_damagetext;
    private string lvlSkintext;

    public int helthN;
    public int obstaneN;
    public int wallobstaneN;
    public int poisoningN;
    public int critical_damageN;
    public int chance_of_crit_damageN;

    public int lvl;
    private int ClientLvlLoadSave;
    private int costUpdate;
    
    void Start()
    {
         ClientLvlLoadSave = PlayerPrefs.GetInt("LvlClient");
         healthtext = "health" + lvl;
         obstanetext = "obstane" + lvl;
         wallobstanetext = "wallobstane" + lvl;
         speedtext = "speed" + lvl;
         poisoningtext = "poisoning" + lvl;
         critical_damagetext = "critical_damage" + lvl;
         chance_of_crit_damagetext = "chance_of_crit_damage" + lvl;
         lvlSkintext = "lvlSkin" + lvl;

         health = PlayerPrefs.GetInt(healthtext);
         obstane = PlayerPrefs.GetInt(obstanetext);
         wallobstane = PlayerPrefs.GetInt(wallobstanetext);
         speed = PlayerPrefs.GetFloat(speedtext);
         poisoning = PlayerPrefs.GetInt(poisoningtext);
         critical_damage = PlayerPrefs.GetInt(critical_damagetext);
         chance_of_crit_damage = PlayerPrefs.GetInt(chance_of_crit_damagetext);
         lvlSkin = PlayerPrefs.GetInt(lvlSkintext);
         if (health < 100)
         {
             health = 100;
         }
         if (lvlSkin <= 0)
         {
             lvlSkin = 1;
         }
         if (speed <= 0)
         {
             speed = 1;
         }
         Download();
         Debug.Log("Health Start" + health);
         coins = PlayerPrefs.GetInt("Money");
          
          Cost();
          LVLHealth();

         ClientLvlLoadSavetext.text = ClientLvlLoadSave.ToString("D1");
         Healthtext.text = health.ToString("D1");
         Obstanetext.text = obstane.ToString("D1");
         Wallobstanetext.text = wallobstane.ToString("D1");
         Speedtext.text = speed.ToString();
         Poisoningtext.text = poisoning.ToString("D1");
         Critical_damagetext.text = critical_damage.ToString("D1");
         Chance_of_crit_damagetext.text = chance_of_crit_damage.ToString("D1");
         Debug.Log("krat = " + (lvlSkin%5));
         
    }
    
    public void Cost()
    {
        costUpdate = 100 + lvlSkin * lvlSkin;
        Debug.Log("costUpdate = " + costUpdate);
        Coinstext.text = costUpdate.ToString("D1");
        if(lvlSkin >= 100)
        {
          Coinstext.text = "Max Lvl";
        }
    }
    void LVLHealth()
    {
      LVLtext = Selected + lvl;
      Debug.Log(LVLtext);
       PlayerPrefs.SetString(LVLtext, LVLtext);
    }
    public void LVLHealthButton()
    {
      if(ClientLvlLoadSave > lvlSkin)
      {
          if(coins>costUpdate)
        {
         coins -= costUpdate; 
         Moneytext.text = coins.ToString("D1");
         PlayerPrefs.SetInt("Money", coins);
      GetComponent<AudioSource>().Play();
      Debug.Log(LVLtext);
      if (lvlSkin < 100)
      {
          lvlSkin++;
      }
      
       Cost();
      double Deltax = 1;
      if (lvlSkin >= 30 && lvlSkin < 60)
      {
          Deltax = Deltax + delta * 0.5;
          speed = speed + (float)Deltax * (lvlSkin);
          health = health + (helthN * 2);
          if (lvlSkin % 5 == 0)
          {
              obstane = obstane + obstaneN * 2;
              Debug.Log("obstane");
              poisoning = poisoning + poisoningN;
              Debug.Log("poisoning");
              if (lvlSkin % 10 == 0)
              {
                  wallobstane = wallobstane + wallobstaneN * 2;
                  Debug.Log("wallobstane");
              }
          }
      }
      if (lvlSkin >= 60 && lvlSkin < 80)
      {
          Deltax = Deltax + delta * 0.1;
          speed = speed + (float)Deltax * (lvlSkin);
          health = health + (helthN * 3);
          if (lvlSkin % 5 == 0)
          {
              obstane = obstane + obstaneN * 3;
              Debug.Log("obstane");
              poisoning = poisoning + poisoningN * 2;
              Debug.Log("poisoning");
              if (lvlSkin % 10 == 0)
              {
                  wallobstane = wallobstane + wallobstaneN * 3;
                  Debug.Log("wallobstane");
              }
          }
      } 
        if (lvlSkin >= 80 && lvlSkin < 90)
      {
          Deltax = Deltax + delta * 0.15;
          speed = speed + (float)Deltax * (lvlSkin);
          health = health + (helthN * 4);
          critical_damage = critical_damage + critical_damageN;
          Debug.Log("critical_damage");
          chance_of_crit_damage = chance_of_crit_damage + chance_of_crit_damageN;
          Debug.Log("chance_of_crit_damage");

          if (lvlSkin % 5 == 0)
          {
              obstane = obstane + obstaneN * 4;
              Debug.Log("obstane");
              poisoning = poisoning + poisoningN *3;
              Debug.Log("poisoning");
              if (lvlSkin % 10 == 0)
              {
                  wallobstane = wallobstane + wallobstaneN * 4;
                  Debug.Log("wallobstane");
              }
          }
      }
      if (lvlSkin >= 90 && lvlSkin <= 100)
      {
          Deltax = Deltax + delta * 0.25;
          speed = speed + (float)Deltax * (lvlSkin);
          health = health + (helthN * 5);
          critical_damage = critical_damage + critical_damageN * 2;
          Debug.Log("critical_damage");
          chance_of_crit_damage = chance_of_crit_damage + chance_of_crit_damageN * 2;
          Debug.Log("chance_of_crit_damage");
          if (lvlSkin % 5 == 0)
          {
              obstane = obstane + obstaneN * 5;
              Debug.Log("obstane");
              poisoning = poisoning + poisoningN * 4;
              Debug.Log("poisoning");
              if (lvlSkin % 10 == 0)
              {
                  wallobstane = wallobstane + wallobstaneN * 5;
                  Debug.Log("wallobstane");
              }
          }
      }
      if (lvlSkin >= 0 && lvlSkin < 30)
      {
          speed = speed + (float)delta * (lvlSkin);
          health = health + helthN;
          if (lvlSkin % 5 == 0)
          {
              obstane = obstane + obstaneN;
              Debug.Log("obstane");
              if (lvlSkin % 10 == 0)
              {
                  wallobstane = wallobstane + wallobstaneN;
                  Debug.Log("wallobstane");
              }
          }
      }
      if (lvlSkin >= 20 && lvlSkin < 30)
      {
          if (lvlSkin % 5 == 0)
          {
              poisoning = poisoning + poisoningN;
              Debug.Log("poisoning");
          }
      }
      PlayerPrefs.SetInt(healthtext, health);
      PlayerPrefs.SetInt(obstanetext, obstane);
      PlayerPrefs.SetInt(wallobstanetext, wallobstane);
      PlayerPrefs.SetFloat(speedtext, speed);
      PlayerPrefs.SetInt(poisoningtext, poisoning);
      PlayerPrefs.SetInt(critical_damagetext, critical_damage);
      PlayerPrefs.SetInt(chance_of_crit_damagetext, chance_of_crit_damage);
      PlayerPrefs.SetInt(lvlSkintext, lvlSkin);
      Debug.Log("Health " + health);
      }
    else
      {
         Coinstext.text = "No required level";
      }
    }
  }
    
    void Download()
    {
     int SaveLvl = lvlSkin;
     if(health == 100 && lvlSkin > 1 &&  speed == 1)
     {
      for(int i = 2; i <= SaveLvl; i++)
      {
        lvlSkin = i;
  
              Debug.Log(LVLtext);
      if (lvlSkin < 100)
      {
          lvlSkin++;
      }
      
       Cost();
      double Deltax = 1;
      if (lvlSkin >= 30 && lvlSkin < 60)
      {
          Deltax = Deltax + delta * 0.5;
          speed = speed + (float)Deltax * (lvlSkin);
          health = health + (helthN * 2);
          if (lvlSkin % 5 == 0)
          {
              obstane = obstane + obstaneN * 2;
              Debug.Log("obstane");
              poisoning = poisoning + poisoningN;
              Debug.Log("poisoning");
              if (lvlSkin % 10 == 0)
              {
                  wallobstane = wallobstane + wallobstaneN * 2;
                  Debug.Log("wallobstane");
              }
          }
      }
      if (lvlSkin >= 60 && lvlSkin < 80)
      {
          Deltax = Deltax + delta * 0.1;
          speed = speed + (float)Deltax * (lvlSkin);
          health = health + (helthN * 3);
          if (lvlSkin % 5 == 0)
          {
              obstane = obstane + obstaneN * 3;
              Debug.Log("obstane");
              poisoning = poisoning + poisoningN * 2;
              Debug.Log("poisoning");
              if (lvlSkin % 10 == 0)
              {
                  wallobstane = wallobstane + wallobstaneN * 3;
                  Debug.Log("wallobstane");
              }
          }
      } 
        if (lvlSkin >= 80 && lvlSkin < 90)
      {
          Deltax = Deltax + delta * 0.15;
          speed = speed + (float)Deltax * (lvlSkin);
          health = health + (helthN * 4);
          critical_damage = critical_damage + critical_damageN;
          Debug.Log("critical_damage");
          chance_of_crit_damage = chance_of_crit_damage + chance_of_crit_damageN;
          Debug.Log("chance_of_crit_damage");

          if (lvlSkin % 5 == 0)
          {
              obstane = obstane + obstaneN * 4;
              Debug.Log("obstane");
              poisoning = poisoning + poisoningN *3;
              Debug.Log("poisoning");
              if (lvlSkin % 10 == 0)
              {
                  wallobstane = wallobstane + wallobstaneN * 4;
                  Debug.Log("wallobstane");
              }
          }
      }
      if (lvlSkin >= 90 && lvlSkin <= 100)
      {
          Deltax = Deltax + delta * 0.25;
          speed = speed + (float)Deltax * (lvlSkin);
          health = health + (helthN * 5);
          critical_damage = critical_damage + critical_damageN * 2;
          Debug.Log("critical_damage");
          chance_of_crit_damage = chance_of_crit_damage + chance_of_crit_damageN * 2;
          Debug.Log("chance_of_crit_damage");
          if (lvlSkin % 5 == 0)
          {
              obstane = obstane + obstaneN * 5;
              Debug.Log("obstane");
              poisoning = poisoning + poisoningN * 4;
              Debug.Log("poisoning");
              if (lvlSkin % 10 == 0)
              {
                  wallobstane = wallobstane + wallobstaneN * 5;
                  Debug.Log("wallobstane");
              }
          }
      }
      if (lvlSkin >= 0 && lvlSkin < 30)
      {
          speed = speed + (float)delta * (lvlSkin);
          health = health + helthN;
          if (lvlSkin % 5 == 0)
          {
              obstane = obstane + obstaneN;
              Debug.Log("obstane");
              if (lvlSkin % 10 == 0)
              {
                  wallobstane = wallobstane + wallobstaneN;
                  Debug.Log("wallobstane");
              }
          }
      }
      if (lvlSkin >= 20 && lvlSkin < 30)
      {
          if (lvlSkin % 5 == 0)
          {
              poisoning = poisoning + poisoningN;
              Debug.Log("poisoning");
          }
      }
      PlayerPrefs.SetInt(healthtext, health);
      PlayerPrefs.SetInt(obstanetext, obstane);
      PlayerPrefs.SetInt(wallobstanetext, wallobstane);
      PlayerPrefs.SetFloat(speedtext, speed);
      PlayerPrefs.SetInt(poisoningtext, poisoning);
      PlayerPrefs.SetInt(critical_damagetext, critical_damage);
      PlayerPrefs.SetInt(chance_of_crit_damagetext, chance_of_crit_damage);
      PlayerPrefs.SetInt(lvlSkintext, lvlSkin);
      Debug.Log("Health " + health);

      }
     }
    }
    void Update()
    {
        Healthtext.text = health.ToString("D1");
        Obstanetext.text = obstane.ToString("D1");
        Wallobstanetext.text = wallobstane.ToString("D1");
        Speedtext.text = speed.ToString();
        Poisoningtext.text = poisoning.ToString("D1");
        Critical_damagetext.text = critical_damage.ToString("D1");
        Chance_of_crit_damagetext.text = chance_of_crit_damage.ToString("D1");
        LvlSkintext.text = lvlSkin.ToString("D1");
    }

    public void Reset()
    {
          lvlSkin = 1;
          speed = 1;
          health = 100;
          obstane = 0;
          wallobstane = 0;
          poisoning = 0;
          critical_damage = 0;
          chance_of_crit_damage = 0;

      PlayerPrefs.SetInt(healthtext, health);
      PlayerPrefs.SetInt(obstanetext, obstane);
      PlayerPrefs.SetInt(wallobstanetext, wallobstane);
      PlayerPrefs.SetFloat(speedtext, speed);
      PlayerPrefs.SetInt(poisoningtext, poisoning);
      PlayerPrefs.SetInt(critical_damagetext, critical_damage);
      PlayerPrefs.SetInt(chance_of_crit_damagetext, chance_of_crit_damage);
      PlayerPrefs.SetInt(lvlSkintext, lvlSkin);
    }
}
