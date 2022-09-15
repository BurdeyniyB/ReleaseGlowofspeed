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

    private int lvlshield = 1;
    private int secondshield;
    private int chargesshield;

    void Start()
    {
        lvlSkintext = "lvlSkin" + lvl;
        lvlSkin = PlayerPrefs.GetInt(lvlSkintext);
        Debug.Log("lvlSkin = " + lvlSkin);
        lvlshield = PlayerPrefs.GetInt(save);
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

    }

    public void UpdateClick()
    {
        lvlshield++;
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
}
