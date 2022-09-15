using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsRewardClaim : MonoBehaviour 
{
    private string RewardedUnitId = "ca-app-pub-1202178251247646/6146537843";
    private RewardedAd rewardedAd;
    private void OnEnable()
    {
        rewardedAd = new RewardedAd(RewardedUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(adRequest);
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
    }
    
    private void HandleUserEarnedReward(object sender, Reward e)
    {
        int money = PlayerPrefs.GetInt("Money");
        int CoinForRace = PlayerPrefs.GetInt("coinsforonerace");
        PlayerPrefs.SetInt("Money", money + CoinForRace);
        PlayerPrefs.SetInt("coinsforonerace", CoinForRace * 2);
    }

    public void ShowAd()
    {
        if (rewardedAd.IsLoaded())
            rewardedAd.Show();
    }
}
