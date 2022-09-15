using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Luckyornot : MonoBehaviour
{
    public int[] chance;
    public int[] restores;
    public int lvl;
    public string save;
    private string lvlSkintext;
    private string opporutinesSelected = "Lucky";
    private int lvlSkin;
    public Text panelLvl;
    public Text panelChar;

    public int[] x1;
    public int[] x2;
    public int[] x3;
    public int[] x4;
    public int[] x5;
    public int[] my_x;
    public GameObject[] panelsX;
    public GameObject updatepanelsX5;
    private int SuccessUpdate;
    private string load;

    private int lvlLucky = 1;
    private int procentrecovery;
    private int chargesrecovery;

    void Start()
    {
        lvlSkintext = "lvlSkin" + lvl;
        lvlSkin = PlayerPrefs.GetInt(lvlSkintext);
        Debug.Log("lvlSkin = " + lvlSkin);
        lvlLucky = PlayerPrefs.GetInt(save);

         for (int i = 0; i < my_x.Length; i++)
        {
            load = "x" + (i + 1);
            Debug.Log("x losd - " + load);
            my_x[i] = PlayerPrefs.GetInt(load);
            Debug.Log("my_x [" + i + "] = " + my_x[i]);
        }

        if(lvlLucky == 0)
        {
            PlayerPrefs.SetInt(save, 1);
        }
        lvlLucky = PlayerPrefs.GetInt(save);


        if (lvlLucky <= 5)
        {
            for (int i = 0; i <= chance.Length; i++)
            {
                if (i <= (lvlLucky - 1))
                {
                    procentrecovery = chance[i];
                    chargesrecovery = restores[i];
                }
            }
        }
        else
        {
                procentrecovery = chance[0];
                chargesrecovery = restores[0];
                lvlLucky = 1;
        }

        panelLvl.text = "Lucky or not? lvl " + (lvlLucky);
        panelChar.text = "When using recovery with a " + procentrecovery + "% chance, restores " + chargesrecovery + "% of recovery.";
        PlayerPrefs.SetInt(save, lvlLucky);

    }

    public void PanelsX()
    {
     PlayerPrefs.SetInt("click", 1);
     panelsX[lvlLucky - 1].SetActive(true);
    }

    public void UpdateClick()
    {
        if(my_x[0] >= x1[lvlLucky - 1])
        {
         my_x[0] -= x1[lvlLucky - 1];
         PlayerPrefs.SetInt("x1", my_x[0]);
         Debug.Log("x1 before" + my_x[0]);
          if(my_x[1] >= x2[lvlLucky - 1])
         {
           my_x[1] -= x2[lvlLucky - 1];
           PlayerPrefs.SetInt("x2", my_x[1]);
           Debug.Log("x2 before" + my_x[1]);
            if(my_x[2] >= x3[lvlLucky - 1])
           {
             my_x[2] -= x3[lvlLucky - 1];
             PlayerPrefs.SetInt("x3", my_x[2]);
             Debug.Log("x3 before" + my_x[2]);
              if(my_x[3] >= x4[lvlLucky - 1])
             {
               my_x[3] -= x4[lvlLucky - 1];
               PlayerPrefs.SetInt("x4", my_x[3]);
               Debug.Log("x4 before" + my_x[3]);
                if(my_x[4] >= x5[lvlLucky - 1])
               {
                 my_x[4] -= x5[lvlLucky - 1];
                 PlayerPrefs.SetInt("x5", my_x[4]);
                 Debug.Log("x5 before" + my_x[4]);
                 SuccessUpdate = 1;
               }
             }
           }
         }
        }
        if(SuccessUpdate == 1)
        {
          Debug.Log("Success = true");
          PlayerPrefs.SetInt("UpdateLvl", 1);
        lvlLucky++;
        if (lvlLucky <= 5)
        {
            for (int i = 0; i <= chance.Length; i++)
            {
                if (i <= (lvlLucky - 1))
                {
                    procentrecovery = chance[i];
                    chargesrecovery = restores[i];
                }
            }
        }
        }
        else
        {
            procentrecovery = chance[0];
            chargesrecovery = restores[0];
            lvlLucky = 1;
        }
        panelLvl.text = "Lucky or not? lvl " + lvlLucky;
        panelChar.text = "When using recovery with a " + procentrecovery + "% chance, restores " + chargesrecovery + "% of recovery.";
        PlayerPrefs.SetInt(save, lvlLucky);
        panelsX[lvlLucky - 1].SetActive(true);
        panelsX[lvlLucky - 2].SetActive(false);
         if(lvlLucky >= 5)
                {
                  updatepanelsX5.SetActive(false);
                }
                else
                {
                  Debug.Log("Success = false");
                }
    }
     public void Selected()
    {
        lvlSkin = PlayerPrefs.GetInt(lvlSkintext);
        PlayerPrefs.SetInt("clickselected", 1);
        if(lvlSkin >= 60)
        {
        PlayerPrefs.SetString("uniqueability", save);
        PlayerPrefs.SetInt(save, lvlLucky);
        Debug.Log("uniqueability = " + save);
        }
        else
        {
        PlayerPrefs.SetString("uniqueability", "0");
        }
    }
    public void LvlClick(int lvlLucky)
    {
        if (lvlLucky <= 5)
        {
            for (int i = 0; i <= chance.Length; i++)
            {
                if (i <= (lvlLucky - 1))
                {
                    procentrecovery = chance[i];
                    chargesrecovery = restores[i];
                }
            }
        }
        else
        {
            procentrecovery = chance[0];
            chargesrecovery = restores[0];
            lvlLucky = 1;
        }
       panelLvl.text = "Lucky or not? lvl " + lvlLucky;
       panelChar.text = "When using recovery with a " + procentrecovery + "% chance, restores " + chargesrecovery + "% of recovery.";
    }

    public void Close()
    {
        lvlLucky = PlayerPrefs.GetInt(save);
        Debug.Log("lvlLucky = " + lvlLucky);

        for (int i = 0; i < panelsX.Length; i++)
            {
              panelsX[i].SetActive(false);
            }

        if (lvlLucky <= 5)
        {
            for (int i = 0; i <= chance.Length; i++)
            {
                if (i <= (lvlLucky - 1))
                {
                    procentrecovery = chance[i];
                    chargesrecovery = restores[i];
                }
            }
        }
        else
        {
            procentrecovery = chance[0];
            chargesrecovery = restores[0];
            lvlLucky = 1;
        }
        Debug.Log("lvlLucky Lucky or not? lvl = " + lvlLucky);
        panelLvl.text = "Lucky or not? lvl " + lvlLucky;
        panelChar.text = "When using recovery with a " + procentrecovery + "% chance, restores " + chargesrecovery + "% of recovery.";
        PlayerPrefs.SetInt("click", 1);
    }
}
