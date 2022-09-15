using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public GameObject hero;
    public int health = 100;
    public Text timertext;
    //количество денег
    public int money;
    public Text moneytext;
    public Image bar;
    private float fill;
    private int audio;
    private const string SelectedSkin = "SelectedSkin";
    string Selected = "Selected";
    private string LVLtext;
    int LVL;
    private string healthtext;
    private int lvl;
    public float healthsatrt;
    private int coinsforonerace;
    private int recordinonerace;
    private int moneyinrace;
    public string SceneName;
    private int sound;
    void Start()
    {
          LVLHealth();

        //в переменую денег мы вставляем сораненые данные
         money = PlayerPrefs.GetInt("Money");

         timertext.text = health.ToString("D1");
         moneytext.text = moneyinrace.ToString("D1");

         coinsforonerace = PlayerPrefs.GetInt("Money");
         moneyinrace = PlayerPrefs.GetInt("moneyinrace");
    }
    void LVLHealth()
    {
      LVL = PlayerPrefs.GetInt(SelectedSkin, 0);
      LVLtext = Selected + LVL;
      Debug.Log(LVLtext);
      for(int i = 0; i <= 20; i++)
      {
        if (i == LVL)
        {
         lvl = PlayerPrefs.GetInt(SelectedSkin, 0);
        healthtext = "health" + lvl;
         health = PlayerPrefs.GetInt(healthtext);
         if (health < 100)
         {
             health = 100;
         }
          healthsatrt = health;
        }
      }
    }
    void Update()
    {
        money = PlayerPrefs.GetInt("Money");
        MoneyInRace();
        moneytext.text = moneyinrace.ToString("D1");
        fill = health / healthsatrt;
        bar.fillAmount = fill;


        PlayerPrefs.SetInt("coinsforonerace", money - coinsforonerace);
        //Debug.Log("coinsforonerace = " + (money - coinsforonerace));

        sound = PlayerPrefs.GetInt("SettingSound");
        if(sound == 1)
        {
          audio = PlayerPrefs.GetInt("audio");
        if (audio != 0)
        {
          GetComponent<AudioSource>().Play();
          audio = 0;
          PlayerPrefs.SetInt("audio", audio);
        }
        }
        
        if (health <= 0)
        {
          Destroy(hero);
          timertext.text = "0";
          moneyinrace = moneyinrace + (money - coinsforonerace);
          Debug.Log("moneyinrace = " + moneyinrace);
          PlayerPrefs.SetInt("moneyinrace", moneyinrace);
          SceneManager.LoadScene(SceneName);
        }
        else
        {
          timertext.text = health.ToString("D1");
        }
    }
    public void MoneyInRace()
    {
      moneyinrace = (money - coinsforonerace);
      PlayerPrefs.SetInt("moneyinrace", moneyinrace);
    }
    public void Kill()
    {
        health--;
        Debug.Log(health);
        timertext.text = health.ToString("D1");

        if(health == 0)
        {
          Time.timeScale = 0;
        }
    } 
}
