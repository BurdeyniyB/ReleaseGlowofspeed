using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Retraction : MonoBehaviour
{
    public int[] chance;
    public int[] restores;
    public int lvl;
    public string save;
    private string lvlSkintext;
    private string opporutinesSelected = "Retraction";
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

    private int lvlRetraction = 1;
    private int procentrecovery;
    private int chargesrecovery;

    void Start()
    {
        lvlSkintext = "lvlSkin" + lvl;
        lvlSkin = PlayerPrefs.GetInt(lvlSkintext);
        Debug.Log("lvlSkin = " + lvlSkin);
        lvlRetraction = PlayerPrefs.GetInt(save);

         for (int i = 0; i < my_x.Length; i++)
        {
            load = "x" + (i + 1);
            Debug.Log("x losd - " + load);
            my_x[i] = PlayerPrefs.GetInt(load);
            Debug.Log("my_x [" + i + "] = " + my_x[i]);
        }

        if(lvlRetraction == 0)
        {
            PlayerPrefs.SetInt(save, 1);
        }
        lvlRetraction = PlayerPrefs.GetInt(save);


        if (lvlRetraction <= 5)
        {
            for (int i = 0; i <= chance.Length; i++)
            {
                if (i <= (lvlRetraction - 1))
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
                lvlRetraction = 1;
        }

        panelLvl.text = "Retraction lvl " + (lvlRetraction);
        panelChar.text = "When colliding with an obstacle, if the ''shield'' ability is used with " + procentrecovery + "%, restores " + chargesrecovery + "% health.";
        PlayerPrefs.SetInt(save, lvlRetraction);
        if(lvlRetraction >= 5)
        {
          updatepanelsX5.SetActive(false);
        }
    }

    public void PanelsX()
    {
     PlayerPrefs.SetInt("click", 1);
     panelsX[lvlRetraction - 1].SetActive(true);
    }

    public void UpdateClick()
    {
        if(my_x[0] >= x1[lvlRetraction - 1])
        {
         my_x[0] -= x1[lvlRetraction - 1];
         PlayerPrefs.SetInt("x1", my_x[0]);
         Debug.Log("x1 before" + my_x[0]);
          if(my_x[1] >= x2[lvlRetraction - 1])
         {
           my_x[1] -= x2[lvlRetraction - 1];
           PlayerPrefs.SetInt("x2", my_x[1]);
           Debug.Log("x2 before" + my_x[1]);
            if(my_x[2] >= x3[lvlRetraction - 1])
           {
             my_x[2] -= x3[lvlRetraction - 1];
             PlayerPrefs.SetInt("x3", my_x[2]);
             Debug.Log("x3 before" + my_x[2]);
              if(my_x[3] >= x4[lvlRetraction - 1])
             {
               my_x[3] -= x4[lvlRetraction - 1];
               PlayerPrefs.SetInt("x4", my_x[3]);
               Debug.Log("x4 before" + my_x[3]);
                if(my_x[4] >= x5[lvlRetraction - 1])
               {
                 my_x[4] -= x5[lvlRetraction - 1];
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
        lvlRetraction++;
        PlayerPrefs.SetInt("UpdateLvl", 1);
        if (lvlRetraction <= 5)
        {
            for (int i = 0; i <= chance.Length; i++)
            {
                if (i <= (lvlRetraction - 1))
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
            lvlRetraction = 1;
        }
        panelLvl.text = "Retraction lvl " + (lvlRetraction);
        panelChar.text = "When colliding with an obstacle, if the ''shield'' ability is used with " + procentrecovery + "%, restores " + chargesrecovery + "% health.";
        PlayerPrefs.SetInt(save, lvlRetraction);
        panelsX[lvlRetraction - 1].SetActive(true);
        panelsX[lvlRetraction - 2].SetActive(false);
        if(lvlRetraction >= 5)
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
        if(lvlSkin >= 60)
        {
        PlayerPrefs.SetString("uniqueability", save);
        PlayerPrefs.SetInt(save, lvlRetraction);
        Debug.Log("uniqueability = " + save);
        }
        else
        {
        PlayerPrefs.SetString("uniqueability", "0");
        }
    }

    public void LvlClick(int lvlRetraction)
    {
        if (lvlRetraction <= 5)
        {
            for (int i = 0; i <= chance.Length; i++)
            {
                if (i <= (lvlRetraction - 1))
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
            lvlRetraction = 1;
        }
        panelLvl.text = "Retraction lvl " + (lvlRetraction);
        panelChar.text = "When colliding with an obstacle, if the ''shield'' ability is used with " + procentrecovery + "%, restores " + chargesrecovery + "% health.";
    }

    public void Close()
    {
        lvlRetraction = PlayerPrefs.GetInt(save);

        for (int i = 0; i < panelsX.Length; i++)
            {
              panelsX[i].SetActive(false);
            }
            
        if (lvlRetraction <= 5)
        {
            for (int i = 0; i <= chance.Length; i++)
            {
                if (i <= (lvlRetraction - 1))
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
            lvlRetraction = 1;
        }
        panelLvl.text = "Retraction lvl " + (lvlRetraction);
        panelChar.text = "When colliding with an obstacle, if the ''shield'' ability is used with " + procentrecovery + "%, restores " + chargesrecovery + "% health.";
    }
}
