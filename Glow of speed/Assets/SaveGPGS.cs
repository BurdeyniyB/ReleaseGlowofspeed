using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveGPGS : MonoBehaviour
{
    int x;
    string LoadScene;
    void Update()
    {
        x = PlayerPrefs.GetInt("GetSavingString");
        if(x == 1)
        {
            PlayerPrefs.SetInt("GetSavingString", 0);
            LoadScene = PlayerPrefs.GetString("LoadSceneforsave");
            Invoke("Task", 2f);
        }
    }
    void Task()
    {
      SceneManager.LoadScene(LoadScene);
    }
}
