using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlClient : MonoBehaviour
{
    public Text LvlClientText;
    public Text ProgresLine;
    public Text NewLevelText;
    public Image bar;
    public GameObject NewLevelPanal;
    public int[] CoefficientForNextLevel;
    private int ClientLvlLoadSave;
    private int ProgresXPLevelClient;
    private int NumberXPLvlNextLevel = 15;
    
    void Start()
    {
        ClientLvlLoadSave = PlayerPrefs.GetInt("LvlClient");
        if(ClientLvlLoadSave == 0)
        {
          ClientLvlLoadSave = 1;
          PlayerPrefs.SetInt("LvlClient", ClientLvlLoadSave);
        }

        ProgresXPLevelClient = PlayerPrefs.GetInt("ProgresXPLevelClient");
        Debug.Log("StartProgresXPLevelClient = " + ProgresXPLevelClient);
        XPForNextLevel();
        LvlClientText.text = ClientLvlLoadSave.ToString("D1");
    }

    void Update()
    {      
      if(ClientLvlLoadSave == 100)
       {
         bar.fillAmount = 1;  
         ProgresLine.text = "Max lvl";
       }
       else
       {
      ProgresXPLevelClient = PlayerPrefs.GetInt("ProgresXPLevelClient");
      ProgresLine.text = ProgresXPLevelClient.ToString("D1") + " / " + NumberXPLvlNextLevel.ToString("D1");
      Debug.Log("UpdatesProgresXPLevelClient = " + ProgresXPLevelClient);
      
      if(ProgresXPLevelClient >= NumberXPLvlNextLevel)
      {
          Debug.Log("New level");
          ProgresXPLevelClient = ProgresXPLevelClient - NumberXPLvlNextLevel;
          PlayerPrefs.SetInt("ProgresXPLevelClient", ProgresXPLevelClient);
          ClientLvlLoadSave++;
          if(ClientLvlLoadSave > 100)
          {
              ClientLvlLoadSave = 1;
          }
          LvlClientText.text = ClientLvlLoadSave.ToString("D1");
          PlayerPrefs.SetInt("LvlClient", ClientLvlLoadSave);
          NewLevelText.text = "New Level " + ClientLvlLoadSave + " !";
          NewLevelPanal.SetActive(true);
          XPForNextLevel();
      }

       if (ProgresXPLevelClient != 0)
       {
        bar.fillAmount = (float)((double)ProgresXPLevelClient / (double)NumberXPLvlNextLevel);  
       }
       else
       {
        bar.fillAmount = 0;
       }
      }
    }

    public void CloseNewLevelPanal()
    {
        NewLevelPanal.SetActive(false);
    }

    public void RandomXP()
    {
        //ProgresXPLevelClient = ProgresXPLevelClient + Random.Range(0, NumberXPLvlNextLevel);
        ProgresXPLevelClient = ProgresXPLevelClient + 300000;
        PlayerPrefs.SetInt("ProgresXPLevelClient", ProgresXPLevelClient);
        ProgresLine.text = ProgresXPLevelClient.ToString("D1") + " / " + NumberXPLvlNextLevel.ToString("D1");
        Debug.Log("ProgresXPLevelClient = " + ProgresXPLevelClient);
    }

    public void ResetResult()
    {
        ProgresXPLevelClient = 0;
        PlayerPrefs.SetInt("ProgresXPLevelClient", 0);
        ClientLvlLoadSave = 0;
        PlayerPrefs.SetInt("LvlClient", ClientLvlLoadSave);
        LvlClientText.text = ClientLvlLoadSave.ToString("D1");
        ProgresLine.text = ProgresXPLevelClient.ToString("D1") + " / " + NumberXPLvlNextLevel.ToString("D1");
    }

    void XPForNextLevel()
    {
       ClientLvlLoadSave = PlayerPrefs.GetInt("LvlClient");
       
       if(ClientLvlLoadSave > 0 && ClientLvlLoadSave <= 10)
       {
       NumberXPLvlNextLevel = (15 + CoefficientForNextLevel[0]) * ClientLvlLoadSave;
       }

       if(ClientLvlLoadSave > 10 && ClientLvlLoadSave <= 20)
       {
       NumberXPLvlNextLevel = (15 + CoefficientForNextLevel[1]) * ClientLvlLoadSave;
       }

       if(ClientLvlLoadSave > 20 && ClientLvlLoadSave <= 30)
       {
       NumberXPLvlNextLevel = (15 + CoefficientForNextLevel[2]) * ClientLvlLoadSave;
       }

       if(ClientLvlLoadSave > 30 && ClientLvlLoadSave <= 40)
       {
       NumberXPLvlNextLevel = (15 + CoefficientForNextLevel[3]) * ClientLvlLoadSave;
       }

       if(ClientLvlLoadSave > 40 && ClientLvlLoadSave <= 50)
       {
       NumberXPLvlNextLevel = (15 + CoefficientForNextLevel[4]) * ClientLvlLoadSave;
       }

       if(ClientLvlLoadSave > 50 && ClientLvlLoadSave <= 60)
       {
       NumberXPLvlNextLevel = (15 + CoefficientForNextLevel[5]) * ClientLvlLoadSave;
       }

       if(ClientLvlLoadSave > 60 && ClientLvlLoadSave <= 70)
       {
       NumberXPLvlNextLevel = (15 + CoefficientForNextLevel[6]) * ClientLvlLoadSave;
       }

       if(ClientLvlLoadSave > 70 && ClientLvlLoadSave <= 80)
       {
       NumberXPLvlNextLevel = (15 + CoefficientForNextLevel[7]) * ClientLvlLoadSave;
       }

       if(ClientLvlLoadSave > 80 && ClientLvlLoadSave <= 90)
       {
       NumberXPLvlNextLevel = (15 + CoefficientForNextLevel[8]) * ClientLvlLoadSave;
       }

       if(ClientLvlLoadSave > 90 && ClientLvlLoadSave <= 100)
       {
       NumberXPLvlNextLevel = (15 + CoefficientForNextLevel[9]) * ClientLvlLoadSave;
       }

       ProgresLine.text = ProgresXPLevelClient.ToString("D1") + " / " + NumberXPLvlNextLevel.ToString("D1");
       if (ProgresXPLevelClient != 0)
       {
        bar.fillAmount = (float)(ProgresXPLevelClient / NumberXPLvlNextLevel);  
       }
       else
       {
        bar.fillAmount = 0;
       }
       if(ClientLvlLoadSave == 100)
       {
         bar.fillAmount = 1;  
         ProgresLine.text = "Max lvl";
       }
    }

    
}
