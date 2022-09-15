using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTextManager : MonoBehaviour
{
    public Text[] DamageText;
    public GameObject[] DamageTextObject;
    int time;
    int damage;
    int DamageSave;
    int IEnumeratorTextTrue;
    int IEnumeratorTextTrue1;
    int IEnumeratorTextTrue2;
    public string Namedamage;
    public bool Plus;

    void Update()
    {
     IEnumeratorTextTrue = PlayerPrefs.GetInt("IEnumeratorTextTrue");
     IEnumeratorTextTrue1 = PlayerPrefs.GetInt("IEnumeratorTextTrue1");
     IEnumeratorTextTrue2 = PlayerPrefs.GetInt("IEnumeratorTextTrue2");

     damage = PlayerPrefs.GetInt(Namedamage);
     Debug.Log(damage);

     if(damage != 0)
     {
         Debug.Log("damagetrue");
         DamageSave = damage;
         damage = 0;
         PlayerPrefs.SetInt(Namedamage, damage);

         Damage(DamageSave);
     }
    } 
    public void Damage(int DamageSave)
    {
        Debug.Log("damagetrue");
        int x = Random.Range(0, DamageTextObject.Length);
        Debug.Log("Random.Range = " + x);
        for(int i = 0; i < DamageTextObject.Length; i++)
        {
         if(i == x)
         {
             
               PlayerPrefs.SetInt("IEnumeratorTextTrue", 1);
               StartCoroutine(TextTrue(i, DamageSave));
             
         }
        }
    }

    IEnumerator TextTrue(int i, int DamageSave)
    {
      Debug.Log("TextTrue");
      if(Plus)
      {
      DamageText[i].text = "+ " + DamageSave;
      }
      else 
      {
      DamageText[i].text = "- " + DamageSave;
      }
      DamageTextObject[i].SetActive(true);
      while(time != 1)
      {
          time++;
          yield return new WaitForSeconds(0.09f);
      }
      DamageTextObject[i].SetActive(false);
      time = 0;
      PlayerPrefs.SetInt("IEnumeratorTextTrue", 0);
    }
}
