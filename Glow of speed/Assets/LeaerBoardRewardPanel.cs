using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaerBoardRewardPanel : MonoBehaviour
{
    public GameObject[] LeaderboardControllerManager;
    public GameObject Panel;
    public void PanelManager()
    {
        for (int i = 0; i < LeaderboardControllerManager.Length; i++)
        {
            LeaderboardControllerManager[i].SetActive(false);
        }
        Panel.SetActive(true);
    }
}
