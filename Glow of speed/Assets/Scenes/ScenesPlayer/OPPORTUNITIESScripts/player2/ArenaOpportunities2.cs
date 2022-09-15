using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaOpportunities2 : MonoBehaviour
{
   private string opportunities;
   public Text charg;
   public Shield shield;
   public Retraction retraction;
   public Hero hero;
   private int lvl;
   private const string SelectedSkin = "SelectedSkin";
   private string lvlSkintext;
   private int lvlSkin;
   private int secondshield;
   private int chargesshield;
   public GameObject Button;
   private int secondshieldarena;
   private int chargesshieldarena;
   public GameObject ShieldSprite;
   int timenow;

   bool mybool = false;
   private int RetractionDamage;

   //Retraction
   private int chanceretraction;
   private int restoresretraction;
    void Start()
    {
        lvl = PlayerPrefs.GetInt(SelectedSkin, 0);
        lvlSkintext = "lvlSkin" + lvl;
        lvlSkin = PlayerPrefs.GetInt(lvlSkintext);
        opportunities = PlayerPrefs.GetString("opportunities");
        Debug.Log("opportunities = " + opportunities);
        Load();
    }

    void Load()
    {
     if(lvlSkin >= 30)
     {
         PlayerPrefs.SetInt("ShieldArena", 0);
        if(opportunities == "Shield")
        {
          int lvlshield = PlayerPrefs.GetInt(shield.save);
        if (lvlshield <= 5)
        {
            for (int i = 0; i <= shield.second.Length; i++)
            {
                if (i <= (lvlshield - 1))
                {
                    secondshieldarena = shield.second[i];
                    chargesshieldarena = shield.charges[i];
                }
            }
            charg.text = chargesshieldarena.ToString("D1");
        }
        }
        else
     {
         Button.SetActive(false);
     }
     }
     else
     {
         Button.SetActive(false);
     }
    }
    public void Opportunities()
    {
        if(chargesshieldarena > 0)
        {
        GetComponent<AudioSource>().Play();
        chargesshieldarena--;
        charg.text = chargesshieldarena.ToString("D1");
        StartCoroutine(ShieldTime());
        }
    }
    IEnumerator ShieldTime()
    {
        while (secondshieldarena != timenow)
        {
            ShieldSprite.SetActive(true);
            mybool = true;
            timenow++;
            Debug.Log("timenow = " + timenow);
            PlayerPrefs.SetInt("ShieldArena", 1);
            yield return new WaitForSeconds(1f);
        }
        PlayerPrefs.SetInt("ShieldArena", 0);
        ShieldSprite.SetActive(false);
        mybool = false;
    }

    void Update()
    {
        if(mybool == true)
        {
          RetractionDamage = PlayerPrefs.GetInt("RetractionDamage");
          if(RetractionDamage != 0)
          {
              PlayerPrefs.SetInt("RetractionDamage", 0);
              Debug.Log("RetractionDamage = true");
              string uniqueability = PlayerPrefs.GetString("uniqueability");
         if(uniqueability == "Retraction")
         {
           int lvlRetraction = PlayerPrefs.GetInt(retraction.save);
           if (lvlRetraction <= 5)
           {
             Debug.Log(retraction.chance.Length);
             for (int i = 0; i <= retraction.chance.Length; i++)
             {
                 if (i <= (lvlRetraction - 1))
                 {
                    Debug.Log("opportunities5 = " + opportunities);
                    chanceretraction = retraction.chance[i];
                    restoresretraction = retraction.restores[i];
                 }
             }
           }
         }

          int random = Random.Range(0, 101);
          if(random <= chanceretraction)
              {
                  Debug.Log("chanceretraction = true");
                  hero.health += (int)(hero.healthsatrt * restoresretraction / 100);
              }
          }
        }
    }
}
