using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessLevel : MonoBehaviour
{
    public int NeedLvl;
    public GameObject button;
    public GameObject image;
    private int ClientLvlLoadSave;

    void Update()
    {
        ClientLvlLoadSave = PlayerPrefs.GetInt("LvlClient");
        if(NeedLvl > ClientLvlLoadSave)
        {
           image.SetActive(true);
           button.SetActive(false); 
        }
        else
        {
            image.SetActive(false);
            button.SetActive(true);
        }
    }
}
