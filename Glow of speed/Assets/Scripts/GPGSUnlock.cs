using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi.SavedGame;
using System;

public class GPGSUnlock : MonoBehaviour
{
    private PlayGamesClientConfiguration clientConfiguration;
    public Text statusTXT;
    public Text descriptionTXT;
    private string name;
    [SerializeField]
    private SkinManager skinManager;

    void Start()
    {
        ConfigurationGPGS();
        SingIntoGPGS(SignInInteractivity.CanPromptOnce, clientConfiguration);
    }
    void Update()
    {
        int GPGSUnlockSave = PlayerPrefs.GetInt("GPGSUnlockSave");
        if(GPGSUnlockSave == 1)
        {
          OpenSave(true);
          PlayerPrefs.SetInt("GPGSUnlockSave", 0);
        }
    }
    internal void ConfigurationGPGS()
    {
        clientConfiguration = new PlayGamesClientConfiguration.Builder()
            .EnableSavedGames()
            .Build();
    }

    internal void SingIntoGPGS(SignInInteractivity interactivity, PlayGamesClientConfiguration configuration)
    {
        configuration = clientConfiguration;
        PlayGamesPlatform.InitializeInstance(configuration);
        PlayGamesPlatform.Activate();

        PlayGamesPlatform.Instance.Authenticate(interactivity, (code) =>
        {
            statusTXT.text = "Authenticate...";
            if (code == SignInStatus.Success)
            {
                statusTXT.text = "Successfully Authenticate";
                descriptionTXT.text = "Hello" + Social.localUser.userName + "You have an ID of" + Social.localUser.id;
                OpenSave(false);
            }
            else
            {
                statusTXT.text = "Failed to Authenticate";
                descriptionTXT.text = "Failed to Authenticate, reson for failure is" + code;
            }
        });
    }
    public void BasicSingInBtn()
    {
        SingIntoGPGS(SignInInteractivity.CanPromptAlways, clientConfiguration);
    }

    public void SingOutBtn()
    {
        PlayGamesPlatform.Instance.SignOut();
        statusTXT.text = "Signed Out";
        descriptionTXT.text = "";
    }

    #region SevedGames
    private bool isSaving;

    public void OpenSave(bool saving)
    {
        if (Social.localUser.authenticated)
        {
            isSaving = saving;
            ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution("MyFaleName", DataSource.ReadCacheOrNetwork,
            ConflictResolutionStrategy.UseLongestPlaytime,
            SaveGameOpen);
        }
    }

    private void SaveGameOpen(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            if (isSaving)
            {
                byte[] myData = System.Text.ASCIIEncoding.ASCII.GetBytes(GetSavingString());
                SavedGameMetadataUpdate updateForMetadata = new SavedGameMetadataUpdate.Builder().WithUpdatedDescription("I have updated my game at: " + DateTime.Now.ToString()).Build();

                ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta, updateForMetadata, myData, SaveCallBack);
            }
            else
            {
                ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(meta, LoadCallBack);
            }
        }
        else
        {
            
        }
    }

    private void LoadCallBack(SavedGameRequestStatus status, byte[] data)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            string loadedData = System.Text.ASCIIEncoding.ASCII.GetString(data);

            LoadSavedStringString(loadedData);
        }
    }

    public void LoadSavedStringString(string cloudData)
    {
        string[] cloudStringArr = cloudData.Split('|');

        //Money
        int money = int.Parse(cloudStringArr[0]);
        PlayerPrefs.SetInt("Money", money);
       

        //Record
        int record = int.Parse(cloudStringArr[1]);
        PlayerPrefs.SetInt("bestrecord", record);
        

        //SkinsUnlock
        for (int i = 0; i < skinManager.skins.Length; i++)
        {
            int a = i + 2;
            string b = cloudStringArr[a];
            if (b == "true")
            {
                Debug.Log("IsUnlocked = " + i);
                skinManager.Unlock(i);
            }
        }
        
        //Name
        name = cloudStringArr[skinManager.skins.Length + 2];
        PlayerPrefs.SetString("GameName", name);

        //SkinLvl
        for (int i = 0; i < skinManager.skins.Length; i++)
        {
            int a = i + skinManager.skins.Length + 3;
            int b = int.Parse(cloudStringArr[a]);
            Debug.Log("IsSkin = " + i);
            string lvlSkintext = "lvlSkin" + i;
            PlayerPrefs.SetInt(lvlSkintext, b);
        }
        //arens
        int arena2 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 4]);
        PlayerPrefs.SetInt("bestrecordarena2", arena2);
        int arena3 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 5]);
        PlayerPrefs.SetInt("bestrecordarena3", arena3);
        int arena4 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 6]);
        PlayerPrefs.SetInt("bestrecordarena4", arena4);
        int arena5 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 7]);
        PlayerPrefs.SetInt("bestrecordarena5", arena5);

        int diamonds = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 8]);
        PlayerPrefs.SetInt("diamonds", diamonds);
        
        int Ticket = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 9]);
        PlayerPrefs.SetInt("Ticket", Ticket);

        //x
        int x1 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 10]);
        PlayerPrefs.SetInt("x1", x1);
        int x2 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 11]);
        PlayerPrefs.SetInt("x2", x2);
        int x3 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 12]);
        PlayerPrefs.SetInt("x3", x3);
        int x4 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 13]);
        PlayerPrefs.SetInt("x4", x4);
        int x5 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 14]);
        PlayerPrefs.SetInt("x5", x5);

        int ClientLvlLoadSave = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 15]);
        PlayerPrefs.SetInt("LvlClient", ClientLvlLoadSave);
        int ProgresXPLevelClient = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 16]);
        PlayerPrefs.SetInt("ProgresXPLevelClient", ProgresXPLevelClient);

        //QRB
        int QRB1 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 17]);
        PlayerPrefs.SetInt("QRB1", QRB1);
        int QRB2 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 18]);
        PlayerPrefs.SetInt("QRB2", QRB2);
        int QRB3 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 19]);
        PlayerPrefs.SetInt("QRB3", QRB3);
        int QRB4 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 20]);
        PlayerPrefs.SetInt("QRB4", QRB4);

        //QMC
        int QMC1 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 21]);
        PlayerPrefs.SetInt("QMC1", QMC1);
        int QMC2 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 22]);
        PlayerPrefs.SetInt("QMC2", QMC2);
        int QMC3 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 23]);
        PlayerPrefs.SetInt("QMC3", QMC3);
        int QMC4 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 24]);
        PlayerPrefs.SetInt("QMC4", QMC4);

        //QTT
        int BestResultQTT1 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 25]);
        PlayerPrefs.SetInt("BestResultQTT1", BestResultQTT1);
        int BestResultQTT2 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 26]);
        PlayerPrefs.SetInt("BestResultQTT2", BestResultQTT2);
        int BestResultQTT3 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 27]);
        PlayerPrefs.SetInt("BestResultQTT3", BestResultQTT3);
        int BestResultQTT4 = int.Parse(cloudStringArr[skinManager.skins.Length + skinManager.skins.Length + 28]);
        PlayerPrefs.SetInt("BestResultQTT4", BestResultQTT4);

        PlayerPrefs.SetInt("LoadSavedStringString", 1);
    }
    //Save in Bytes
    public string GetSavingString()
    {
        string dataToSave = "";


        //Money
        int money = PlayerPrefs.GetInt("Money");
        dataToSave += money;
        dataToSave += "|";
        

        //Record
        int record = PlayerPrefs.GetInt("bestrecord");
        dataToSave += record;
        dataToSave += "|";
        

        //SkinUnlock
        
        for (int i = 0; i < skinManager.skins.Length; i++)
        {
            if (skinManager.IsUnlocked(i))
            {
                Debug.Log("IsUnlocked = " + i);
                dataToSave += "true";
                dataToSave += "|";
            }
            else
            {
                dataToSave += "false";
                dataToSave += "|";
            }
        }
        //Name
        name = PlayerPrefs.GetString("GameName");
        dataToSave += name;
        dataToSave += "|";
        
        //SkinLvl
        for (int i = 0; i < skinManager.skins.Length; i++)
        {
            if (skinManager.IsUnlocked(i))
            {
                Debug.Log("IsSkin = " + i);
                string lvlSkintext = "lvlSkin" + i;
                int lvlSkin = PlayerPrefs.GetInt(lvlSkintext);
                dataToSave += lvlSkin;
                dataToSave += "|";
            }
            else
            {
                dataToSave += 0;
                dataToSave += "|";
            }
        }
        
        //arens
        int arena1 = PlayerPrefs.GetInt("bestrecord");
         dataToSave += arena1;
         dataToSave += "|";
        int arena2 = PlayerPrefs.GetInt("bestrecordarena2");
         dataToSave += arena2;
         dataToSave += "|";
        int arena3 = PlayerPrefs.GetInt("bestrecordarena3");
         dataToSave += arena3;
         dataToSave += "|";
        int arena4 = PlayerPrefs.GetInt("bestrecordarena4");
         dataToSave += arena4;
         dataToSave += "|";
        int arena5 = PlayerPrefs.GetInt("bestrecordarena5");
         dataToSave += arena5;
         dataToSave += "|";

       
        int diamonds = PlayerPrefs.GetInt("diamonds");
         dataToSave += diamonds;
         dataToSave += "|";

        int Ticket = PlayerPrefs.GetInt("Ticket");
         dataToSave += Ticket;
         dataToSave += "|";

        //x
        int x1 = PlayerPrefs.GetInt("x1");
         dataToSave += x1;
         dataToSave += "|";

        int x2 = PlayerPrefs.GetInt("x2");
         dataToSave += x2;
         dataToSave += "|";

        int x3 = PlayerPrefs.GetInt("x3");
         dataToSave += x3;
         dataToSave += "|";

        int x4 = PlayerPrefs.GetInt("x4");
         dataToSave += x4;
         dataToSave += "|";

        int x5 = PlayerPrefs.GetInt("x5");
         dataToSave += x5;
         dataToSave += "|";
        //lvl
        int ClientLvlLoadSave = PlayerPrefs.GetInt("LvlClient");
         dataToSave += ClientLvlLoadSave;
         dataToSave += "|";
        int ProgresXPLevelClient = PlayerPrefs.GetInt("ProgresXPLevelClient");
         dataToSave += ProgresXPLevelClient;
         dataToSave += "|";

         //QRB
         int QRB1 = PlayerPrefs.GetInt("QRB1");
         dataToSave += QRB1;
         dataToSave += "|";
         int QRB2 = PlayerPrefs.GetInt("QRB2");
         dataToSave += QRB2;
         dataToSave += "|";
         int QRB3 = PlayerPrefs.GetInt("QRB3");
         dataToSave += QRB3;
         dataToSave += "|";
         int QRB4 = PlayerPrefs.GetInt("QRB4");
         dataToSave += QRB4;
         dataToSave += "|";

         //QMC
         int QMC1 = PlayerPrefs.GetInt("QMC1");
         dataToSave += QMC1;
         dataToSave += "|";
         int QMC2 = PlayerPrefs.GetInt("QMC2");
         dataToSave += QMC2;
         dataToSave += "|";
         int QMC3 = PlayerPrefs.GetInt("QMC3");
         dataToSave += QMC3;
         dataToSave += "|";
         int QMC4 = PlayerPrefs.GetInt("QMC4");
         dataToSave += QMC4;
         dataToSave += "|";

         //QTT
         int BestResultQTT1 = PlayerPrefs.GetInt("BestResultQTT1");
         dataToSave += BestResultQTT1;
         dataToSave += "|";
         int BestResultQTT2 = PlayerPrefs.GetInt("BestResultQTT2");
         dataToSave += BestResultQTT2;
         dataToSave += "|";
         int BestResultQTT3 = PlayerPrefs.GetInt("BestResultQTT3");
         dataToSave += BestResultQTT3;
         dataToSave += "|";
         int BestResultQTT4 = PlayerPrefs.GetInt("BestResultQTT4");
         dataToSave += BestResultQTT4;
         dataToSave += "|";


        PlayerPrefs.SetInt("GetSavingString", 1);
        return dataToSave;
    }
    private void SaveCallBack(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        if (status == SavedGameRequestStatus.Success)
        {
           
        }
        else
        {
           
        }
    }
    #endregion
}
