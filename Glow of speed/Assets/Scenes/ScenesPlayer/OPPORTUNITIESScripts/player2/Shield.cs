using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
   public int[] second;
    public int[] charges;
    public int lvl;
    public string save;
    private string lvlSkintext;
    private string opporutinesSelected = "shield";
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

    private int lvlshield = 1;
    private int secondshield;
    private int chargesshield;

    void Start()
    {
        lvlSkintext = "lvlSkin" + lvl;
        lvlSkin = PlayerPrefs.GetInt(lvlSkintext);
        Debug.Log("lvlSkin = " + lvlSkin);
        lvlshield = PlayerPrefs.GetInt(save);

         for (int i = 0; i < my_x.Length; i++)
        {
            load = "x" + (i + 1);
            Debug.Log("x losd - " + load);
            my_x[i] = PlayerPrefs.GetInt(load);
            Debug.Log("my_x [" + i + "] = " + my_x[i]);
        }

        if(lvlshield == 0)
        {
            PlayerPrefs.SetInt(save, 1);
        }
        lvlshield = PlayerPrefs.GetInt(save);

        if (lvlshield <= 5)
        {
            for (int i = 0; i <= second.Length; i++)
            {
                if (i <= (lvlshield - 1))
                {
                    secondshield = second[i];
                    chargesshield = charges[i];
                }
            }
        }
        else
        {
                secondshield = second[0];
                chargesshield = charges[0];
                lvlshield = 1;
        }
        panelLvl.text = "Shield lvl " + lvlshield;
        panelChar.text = "Grants damage immunity for " + secondshield + " seconds of charges per game " + chargesshield + ".";
        PlayerPrefs.SetInt(save, lvlshield);
        if(lvlshield >= 5)
        {
          updatepanelsX5.SetActive(false);
        }

    }

    public void PanelsX()
    {
     PlayerPrefs.SetInt("click", 1);
     panelsX[lvlshield - 1].SetActive(true);
    }

    public void UpdateClick()
    {
        if(my_x[0] >= x1[lvlshield - 1])
        {
         my_x[0] -= x1[lvlshield - 1];
         PlayerPrefs.SetInt("x1", my_x[0]);
         Debug.Log("x1 before" + my_x[0]);
          if(my_x[1] >= x2[lvlshield - 1])
         {
           my_x[1] -= x2[lvlshield - 1];
           PlayerPrefs.SetInt("x2", my_x[1]);
           Debug.Log("x2 before" + my_x[1]);
            if(my_x[2] >= x3[lvlshield - 1])
           {
             my_x[2] -= x3[lvlshield - 1];
             PlayerPrefs.SetInt("x3", my_x[2]);
             Debug.Log("x3 before" + my_x[2]);
              if(my_x[3] >= x4[lvlshield - 1])
             {
               my_x[3] -= x4[lvlshield - 1];
               PlayerPrefs.SetInt("x4", my_x[3]);
               Debug.Log("x4 before" + my_x[3]);
                if(my_x[4] >= x5[lvlshield - 1])
               {
                 my_x[4] -= x5[lvlshield - 1];
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
        lvlshield++;
        PlayerPrefs.SetInt("UpdateLvl", 1);
        if (lvlshield <= 5)
        {
            for (int i = 0; i <= second.Length; i++)
            {
                if (i <= (lvlshield - 1))
                {
                    secondshield = second[i];
                    chargesshield = charges[i];
                }
            }
        }
        }
        else
        {
            secondshield = second[0];
            chargesshield = charges[0];
            lvlshield = 1;
        }
        panelLvl.text = "Shield lvl " + lvlshield;
        panelChar.text = "Grants damage immunity for " + secondshield + " seconds of charges per game " + chargesshield + ".";
        PlayerPrefs.SetInt(save, lvlshield);
        panelsX[lvlshield - 1].SetActive(true);
        panelsX[lvlshield - 2].SetActive(false);
        if(lvlshield >= 5)
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
        if(lvlSkin >= 30)
        {
        PlayerPrefs.SetString("opportunities", save);
        PlayerPrefs.SetInt(save, lvlshield);
        Debug.Log("opportunities = " + save);
        }
        else
        {
        PlayerPrefs.SetString("opportunities", "0");
        }
    }


    public void LvlClick(int lvlshield)
    {
        if (lvlshield <= 5)
        {
            for (int i = 0; i <= second.Length; i++)
            {
                if (i <= (lvlshield - 1))
                {
                    secondshield = second[i];
                    chargesshield = charges[i];
                }
            }
        }
        else
        {
            secondshield = second[0];
            chargesshield = charges[0];
            lvlshield = 1;
        }
        panelLvl.text = "Shield lvl " + lvlshield;
        panelChar.text = "Grants damage immunity for " + secondshield + " seconds of charges per game " + chargesshield + ".";

    }

    public void Close()
    {
        lvlshield = PlayerPrefs.GetInt(save);

        for (int i = 0; i < panelsX.Length; i++)
            {
              panelsX[i].SetActive(false);
            }
            
        if (lvlshield <= 5)
        {
            for (int i = 0; i <= second.Length; i++)
            {
                if (i <= (lvlshield - 1))
                {
                    secondshield = second[i];
                    chargesshield = charges[i];
                }
            }
        }
        else
        {
            secondshield = second[0];
            chargesshield = charges[0];
            lvlshield = 1;
        }
        panelLvl.text = "Shield lvl " + lvlshield;
        panelChar.text = "Grants damage immunity for " + secondshield + " seconds of charges per game " + chargesshield + ".";
        PlayerPrefs.SetInt("click", 1);
    }
}
