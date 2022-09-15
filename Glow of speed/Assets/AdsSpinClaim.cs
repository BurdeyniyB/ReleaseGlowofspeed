using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsSpinClaim : MonoBehaviour
{
    private string RewardedUnitId = "ca-app-pub-1202178251247646/6969213661";
    private RewardedAd rewardedAd;
    public GameObject button;
    public GameObject buttonads;
    private void OnEnable()
    {
        rewardedAd = new RewardedAd(RewardedUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(adRequest);
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
    }
    
    private void HandleUserEarnedReward(object sender, Reward e)
    {
        Debug.Log("Spin true");
        button.SetActive(true);
        buttonads.SetActive(false);
    }

    public void ShowAd()
    {
        if (rewardedAd.IsLoaded())
            rewardedAd.Show();
    }
}
