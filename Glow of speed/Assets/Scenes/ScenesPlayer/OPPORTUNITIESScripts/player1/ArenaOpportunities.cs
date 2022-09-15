using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArenaOpportunities : MonoBehaviour
{
    private string opportunities;
    public Text charg;
    public Hero hero;
    public Recovery script;
    public Luckyornot luckyornot;
    private int lvl;
    private const string SelectedSkin = "SelectedSkin";
    private string lvlSkintext;
    private int lvlSkin;
    public Animator anim;
    //Recovery
    private int procentrecovery;
    private int chargesrecovery;
    //Luckyornot?
    int chanceluckyornot;
    int restoresluckyornot;


    public GameObject Button;
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
        if(opportunities == "recovery")
        {
          int lvlrecovery = PlayerPrefs.GetInt(script.save);
        if (lvlrecovery <= 5)
        {
            Debug.Log(script.procent.Length);
            for (int i = 0; i <= script.procent.Length; i++)
            {
                if (i <= (lvlrecovery - 1))
                {
                    Debug.Log("opportunities5 = " + opportunities);
                    procentrecovery = script.procent[i];
                    Debug.Log("procentrecovery = " + procentrecovery);
                    chargesrecovery = script.charges[i];
                    Debug.Log("chargesrecover = " + chargesrecovery);
                }
            }
            charg.text = chargesrecovery.ToString("D1");
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
        //Recovery
         if(opportunities == "recovery")
         {
           if(chargesrecovery > 0)
           {
            anim.SetTrigger("play");
         string uniqueability = PlayerPrefs.GetString("uniqueability");
         if(uniqueability == "Luckyornot")
         {
           int lvlLucky = PlayerPrefs.GetInt(luckyornot.save);
           if (lvlLucky <= 5)
           {
             Debug.Log(luckyornot.chance.Length);
             for (int i = 0; i <= luckyornot.chance.Length; i++)
             {
                 if (i <= (lvlLucky - 1))
                 {
                    Debug.Log("opportunities5 = " + opportunities);
                    chanceluckyornot = luckyornot.chance[i];
                    restoresluckyornot = luckyornot.restores[i];
                 }
             }
           }
         }
              anim.SetTrigger("play");
              int random = Random.Range(0, 101);
              GetComponent<AudioSource>().Play();
              chargesrecovery--;
              float recoveryHealthHero = hero.healthsatrt;
              float recoveryHealth = recoveryHealthHero / 100 * procentrecovery;
              Debug.Log("random = " + random);
              Debug.Log("chanceluckyornot = " + chanceluckyornot);
              if(random <= chanceluckyornot)
              {
                  Debug.Log("chanceluckyornot = true");
                  recoveryHealth = recoveryHealth / 100 * restoresluckyornot;
              }
              Debug.Log("recoveryHealthHero = " + recoveryHealthHero);
              hero.health += (int)recoveryHealth;
              charg.text = chargesrecovery.ToString("D1");
           }
         }
        //End Recovery

    }
}
