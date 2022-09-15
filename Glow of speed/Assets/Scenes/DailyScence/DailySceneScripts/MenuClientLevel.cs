using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuClientLevel : MonoBehaviour
{
    public Text LvlClientText;
    private int ClientLvlLoadSave;
    void Start()
    {
        ClientLvlLoadSave = PlayerPrefs.GetInt("LvlClient");
        if(ClientLvlLoadSave == 0)
        {
          ClientLvlLoadSave = 1;
          PlayerPrefs.SetInt("LvlClient", ClientLvlLoadSave);
        }
        
        LvlClientText.text = ClientLvlLoadSave.ToString("D1");
    }
}
