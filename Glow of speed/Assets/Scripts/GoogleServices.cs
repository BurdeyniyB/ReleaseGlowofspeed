using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine.SocialPlatforms;
using System;
using System.Text;
using UnityEngine.UI;

public class GoogleServices : MonoBehaviour
{
    private bool IsSaving;
    public string testStrig = "Hello";
    public int testInt = 95404530;
    public bool testBool = true;
    private DateTime startDateTime;
    public Text text;
    private void Awake()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        .EnableSavedGames()
        .RequestEmail()
        .RequestServerAuthCode(false)
        // requests an ID token be generated.  This OAuth token can be used to
        //  identify the player to other services such as Firebase.
        .RequestIdToken()
        .Build();
    PlayGamesPlatform.InitializeInstance(config);
    // recommended for debugging:
    PlayGamesPlatform.DebugLogEnabled = true;
    // Activate the Google Play Games platform
    PlayGamesPlatform.Activate();

    PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) =>
    {
        if(result == SignInStatus.Success)
        {
          startDateTime = DateTime.Now;
          Open(false);
        }
        else
        {
            Debug.Log("jdjdjdjjd");
        }
    });
    }
    
    public void Open(bool saving)
    {
      text.text = "NO SAVE";
      IsSaving = saving;
      OpenSavedGame("Test");
    }
    public void OpenSavedGame(string filename) {
        text.text = "NO SAVE1";
        ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
        savedGameClient.OpenWithAutomaticConflictResolution(filename, DataSource.ReadCacheOrNetwork,
            ConflictResolutionStrategy.UseLongestPlaytime, OnSavedGameOpened);
            text.text = "NO SAVE2";
    }

    public void OnSavedGameOpened(SavedGameRequestStatus status, ISavedGameMetadata game) {
        if (status == SavedGameRequestStatus.Success) {
            if(IsSaving)
            {
                string data = testStrig + ";" + testInt + ";" + testBool;
                byte[] saveData = Encoding.UTF8.GetBytes(data);
                SaveGame(game, saveData);
            }
            else if(IsSaving == false)
            {
                LoadGameData(game);
            }
        } else {
            // handle error
        }
    }

    void SaveGame (ISavedGameMetadata game, byte[] savedData) {
        TimeSpan currentSpan = DateTime.Now - startDateTime;
        TimeSpan totalPlaytime = game.TotalTimePlayed + currentSpan;
        ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;

        SavedGameMetadataUpdate.Builder builder = new SavedGameMetadataUpdate.Builder();
        builder = builder
            .WithUpdatedPlayedTime(totalPlaytime)
            .WithUpdatedDescription("Saved game at " + DateTime.Now);
        SavedGameMetadataUpdate updatedMetadata = builder.Build();
        savedGameClient.CommitUpdate(game, updatedMetadata, savedData, OnSavedGameWritten);
    }

    public void OnSavedGameWritten (SavedGameRequestStatus status, ISavedGameMetadata game) {
        if (status == SavedGameRequestStatus.Success) {
            Debug.Log("Save TRUE");
            text.text = "Save TRUE";
        } else {
            // handle error
        }
    }

        void LoadGameData (ISavedGameMetadata game) {
        ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
        savedGameClient.ReadBinaryData(game, OnSavedGameDataRead);
    }

    public void OnSavedGameDataRead (SavedGameRequestStatus status, byte[] data) {
        if (status == SavedGameRequestStatus.Success) {
            if(data.Length > 0)
            {
               string dataGoogle = Encoding.ASCII.GetString(data);

               string[] s = dataGoogle.Split(';');
               text.text = s[0] + " " + s[1] + " " + s[2];

               Debug.Log("True save");
            }
            else
            {
                Debug.Log("NO DATA, FIRST SAVE");
                text.text = "NO SAVE";
            }
        } else {
            // handle error
        }
    } 
}
