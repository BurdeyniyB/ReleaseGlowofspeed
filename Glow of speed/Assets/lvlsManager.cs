using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvlsManager : MonoBehaviour
{
    public Text[] LvlSkintext;
    public GameObject[] Zamok;
    private string lvlSkin_string;
    private int lvlSkin;
    public SkinManager skinManager;
    void Start()
    {
        for(int i = 0; i < LvlSkintext.Length; i++)
        {
          lvlSkin_string = "lvlSkin" + i;
          lvlSkin = PlayerPrefs.GetInt(lvlSkin_string);
          if(lvlSkin == 0)
          {
           lvlSkin = 1;
           PlayerPrefs.SetInt(lvlSkin_string, 1);
          }
          LvlSkintext[i].text = lvlSkin.ToString();
        }

        for (int i = 0; i < skinManager.skins.Length; i++)
        {
            if (skinManager.IsUnlocked(i))
            {
                Debug.Log("IsUnlocked = " + i);
                Zamok[i].SetActive(false);
            }
            else
            {
                Zamok[i].SetActive(true);
            }
        }
    }
}
