using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLeaderboard : MonoBehaviour
{
    public GameObject[] Panel;
    public GameObject[] LeaderboardControllerManager;
    private int num;
    public string SceneName;
    void Awake()
    { 
       num = PlayerPrefs.GetInt("GameLeaderboardNum");
       LeaderboardControllerManager[num].SetActive(true);
       Panel[num].SetActive(true);
    }
    public void PanelManager()
    {
        Panel[0].SetActive(true);
        Panel[1].SetActive(false);
        Panel[2].SetActive(false);
        Panel[3].SetActive(false);
        PlayerPrefs.SetInt("GameLeaderboardNum", 0);
        SceneManager.LoadScene(SceneName);
    }

    public void Panel2Manager()
    {
        Panel[0].SetActive(false);
        Panel[1].SetActive(true);
        Panel[2].SetActive(false);
        Panel[3].SetActive(false);
        PlayerPrefs.SetInt("GameLeaderboardNum", 1);
        SceneManager.LoadScene(SceneName);
    }
    public void Panel3Manager()
    {
        Panel[0].SetActive(false);
        Panel[1].SetActive(false);
        Panel[2].SetActive(true);
        Panel[3].SetActive(false);
        PlayerPrefs.SetInt("GameLeaderboardNum", 2);
        SceneManager.LoadScene(SceneName);
    }
}
