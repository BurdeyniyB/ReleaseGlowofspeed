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

    private int lvlRetraction = 1;
    private int procentrecovery;
    private int chargesrecovery;

    void Start()
    {
        lvlSkintext = "lvlSkin" + lvl;
        lvlSkin = PlayerPrefs.GetInt(lvlSkintext);
        Debug.Log("lvlSkin = " + lvlSkin);
        lvlRetraction = PlayerPrefs.GetInt(save);
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
    }

    public void UpdateClick()
    {
        lvlRetraction++;
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
