using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recovery : MonoBehaviour
{
    public int[] procent;
    public int[] charges;
    public int lvl;
    public string save;
    private string lvlSkintext;
    private string opporutinesSelected = "recovery";
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

    private int lvlrecovery = 1;
    private int procentrecovery;
    private int chargesrecovery;

    void Start()
    {
        lvlSkintext = "lvlSkin" + lvl;
        lvlSkin = PlayerPrefs.GetInt(lvlSkintext);
        Debug.Log("lvlSkin = " + lvlSkin);
        lvlrecovery = PlayerPrefs.GetInt(save);

         for (int i = 0; i < my_x.Length; i++)
        {
            load = "x" + (i + 1);
            Debug.Log("x losd - " + load);
            my_x[i] = PlayerPrefs.GetInt(load);
            Debug.Log("my_x [" + i + "] = " + my_x[i]);
        }
        
        if(lvlrecovery == 0)
        {
            PlayerPrefs.SetInt(save, 1);
        }
        lvlrecovery = PlayerPrefs.GetInt(save);

        if (lvlrecovery <= 5)
        {
            for (int i = 0; i <= procent.Length; i++)
            {
                if (i <= (lvlrecovery - 1))
                {
                    procentrecovery = procent[i];
                    chargesrecovery = charges[i];
                }
            }
        }
        else
        {
                procentrecovery = procent[0];
                chargesrecovery = charges[0];
                lvlrecovery = 1;
        }
        panelLvl.text = "Recovery lvl " + lvlrecovery;
        panelChar.text = "Restores " + procentrecovery + "% max health. Total charges " + chargesrecovery + ".";
        PlayerPrefs.SetInt(save, lvlrecovery);
        if(lvlrecovery >= 5)
        {
          updatepanelsX5.SetActive(false);
        }

    }

    public void PanelsX()
    {
     PlayerPrefs.SetInt("click", 1);
     panelsX[lvlrecovery - 1].SetActive(true);
    }

    public void UpdateClick()
    {
        if(my_x[0] >= x1[lvlrecovery - 1])
        {
         my_x[0] -= x1[lvlrecovery - 1];
         PlayerPrefs.SetInt("x1", my_x[0]);
         Debug.Log("x1 before" + my_x[0]);
          if(my_x[1] >= x2[lvlrecovery - 1])
         {
           my_x[1] -= x2[lvlrecovery - 1];
           PlayerPrefs.SetInt("x2", my_x[1]);
           Debug.Log("x2 before" + my_x[1]);
            if(my_x[2] >= x3[lvlrecovery - 1])
           {
             my_x[2] -= x3[lvlrecovery - 1];
             PlayerPrefs.SetInt("x3", my_x[2]);
             Debug.Log("x3 before" + my_x[2]);
              if(my_x[3] >= x4[lvlrecovery - 1])
             {
               my_x[3] -= x4[lvlrecovery - 1];
               PlayerPrefs.SetInt("x4", my_x[3]);
               Debug.Log("x4 before" + my_x[3]);
                if(my_x[4] >= x5[lvlrecovery - 1])
               {
                 my_x[4] -= x5[lvlrecovery - 1];
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
        lvlrecovery++;
        if (lvlrecovery <= 5)
        {
            for (int i = 0; i <= procent.Length; i++)
            {
                if (i <= (lvlrecovery - 1))
                {
                    procentrecovery = procent[i];
                    chargesrecovery = charges[i];
                }
            }
        }
        else
        {
            procentrecovery = procent[0];
            chargesrecovery = charges[0];
            lvlrecovery = 1;
        }
        panelLvl.text = "Recovery lvl " + lvlrecovery;
        panelChar.text = "Restores " + procentrecovery + "% max health. Total charges " + chargesrecovery + ".";
        PlayerPrefs.SetInt(save, lvlrecovery);
        panelsX[lvlrecovery - 1].SetActive(true);
        panelsX[lvlrecovery - 2].SetActive(false);
        if(lvlrecovery >= 5)
        {
          updatepanelsX5.SetActive(false);
        }

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
        if(lvlSkin >= 30)
        {
        PlayerPrefs.SetString("opportunities", save);
        PlayerPrefs.SetInt(save, lvlrecovery);
        Debug.Log("opportunities = " + save);
        }
        else
        {
        PlayerPrefs.SetString("opportunities", "0");
        }
    }


    public void LvlClick(int lvlrecovery)
    {
        if (lvlrecovery <= 5)
        {
            for (int i = 0; i <= procent.Length; i++)
            {
                if (i <= (lvlrecovery - 1))
                {
                    procentrecovery = procent[i];
                    chargesrecovery = charges[i];
                }
            }
        }
        else
        {
            procentrecovery = procent[0];
            chargesrecovery = charges[0];
            lvlrecovery = 1;
        }
        panelLvl.text = "Recovery lvl " + lvlrecovery;
        panelChar.text = "Restores " + procentrecovery + "% max health. Total charges " + chargesrecovery + ".";

    }

    public void Close()
    {
        lvlrecovery = PlayerPrefs.GetInt(save);
        for (int i = 0; i < panelsX.Length; i++)
            {
              panelsX[i].SetActive(false);
            }

        if (lvlrecovery <= 5)
        {
            for (int i = 0; i <= procent.Length; i++)
            {
                if (i <= (lvlrecovery - 1))
                {
                    procentrecovery = procent[i];
                    chargesrecovery = charges[i];
                }
            }
        }
        else
        {
            procentrecovery = procent[0];
            chargesrecovery = charges[0];
            lvlrecovery = 1;
        }
        panelLvl.text = "Recovery lvl " + lvlrecovery;
        panelChar.text = "Restores " + procentrecovery + "% max health. Total charges " + chargesrecovery + ".";
        PlayerPrefs.SetInt("click", 1);
    }
}
