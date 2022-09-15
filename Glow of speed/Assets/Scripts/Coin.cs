using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //количество монет которое будет зачислятся при столкновении с префабом монеты
    public int coin = 1;
    public int x = 1;
    public int audio = 0;
    public float coroutinetime = 1f;
    private float speedroad;
    private float speedroadtime;

   void Update()
   {
     speedroad = PlayerPrefs.GetFloat("RoadUpdateSpeed");
     speedroadtime = (int)(1 / speedroad * 80);
   }

   void OnTriggerEnter2D(Collider2D other)
   {
    //обращение к персонажу
     if (other.CompareTag("Player"))
     {
         //берем и вызываем с компонента герой переменую здоровье 
         //важно чтобы скрипт с нужной нам переменой был на игроке
         other.GetComponent<Hero>().money += coin;
         PlayerPrefs.SetInt("Money", other.GetComponent<Hero>().money);
         CoinActive();
         AudioPlay();
         this.gameObject.SetActive(false);
     }
   }
    void CoinActive()
    {
       if (x != speedroadtime)
       {
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
        audio++;
        PlayerPrefs.SetInt("audio", audio);
    }
    void Invoke()
    {
      this.gameObject.SetActive(true);
    }
}
   