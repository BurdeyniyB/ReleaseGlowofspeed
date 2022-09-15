using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinShopItem : MonoBehaviour
{
  [SerializeField] private SkinManager skinManager;
  [SerializeField] private int skinIndex;
  [SerializeField] private Button buyButton;
  [SerializeField] private Text costText;
  public Text moneytext;
  public Text diamondtext;
  public int money;
  public int diamond;
  private Skin skin;
  public int coins;
  public string SaveText;

  void Update()
  {
    coins = PlayerPrefs.GetInt(SaveText, 0);
    money = PlayerPrefs.GetInt("Money");
    diamond = PlayerPrefs.GetInt("diamonds");
  }

  void Start()
  {
      for (int i = 0; i <= skinManager.skins.Length; i++)
      {
          if (skinManager.IsUnlocked(i))
          {
              Debug.Log("IsUnlocked = " + i);
          }
      }
    coins = PlayerPrefs.GetInt("Money", 0);
    money = PlayerPrefs.GetInt("Money");
    diamond = PlayerPrefs.GetInt("diamonds");

    moneytext.text = money.ToString("D1");

    diamondtext.text = diamond.ToString("D1");

    coins = PlayerPrefs.GetInt(SaveText, 0);
    skin = skinManager.skins[skinIndex];
    Debug.Log("LVLskinsint");
    GetComponent<Image>().sprite = skin.sprite;

    if (skinManager.IsUnlocked(skinIndex))
    {
      buyButton.gameObject.SetActive(false);
    }
    else
    {
      buyButton.gameObject.SetActive(true);
      costText.text = skin.cost.ToString();
      if (skin.cost == 0 && !skinManager.IsUnlocked(skinIndex))
      {
          if(SaveText == "Money")
          {
          PlayerPrefs.SetInt("Money", coins - skin.cost);
          money = coins - skin.cost;
          skinManager.Unlock(skinIndex);
          buyButton.gameObject.SetActive(false);
          skinManager.SelectSkin(skinIndex);
          moneytext.text = money.ToString("D1");
          }

          if(SaveText == "diamonds")
          {
          PlayerPrefs.SetInt("diamonds", coins - skin.cost);
          diamond = coins - skin.cost;
          skinManager.Unlock(skinIndex);
          buyButton.gameObject.SetActive(false);
          skinManager.SelectSkin(skinIndex);
          diamondtext.text = diamond.ToString("D1");
          }
      }
    }
  }

  public void OnSkinPressed()
  {
      if (skin.cost == 0 && !skinManager.IsUnlocked(skinIndex))
      {
          if(SaveText == "Money")
          {
          PlayerPrefs.SetInt("Money", coins - skin.cost);
          money = coins - skin.cost;
          skinManager.Unlock(skinIndex);
          buyButton.gameObject.SetActive(false);
          skinManager.SelectSkin(skinIndex);
          moneytext.text = money.ToString("D1");
          }

          if(SaveText == "diamonds")
          {
          PlayerPrefs.SetInt("diamonds", coins - skin.cost);
          diamond = coins - skin.cost;
          skinManager.Unlock(skinIndex);
          buyButton.gameObject.SetActive(false);
          skinManager.SelectSkin(skinIndex);
          diamondtext.text = diamond.ToString("D1");
          }
      }
    if (skinManager.IsUnlocked(skinIndex))
    {
      skinManager.SelectSkin(skinIndex);
    }
  }

  public void OnBuyButtonPressed()
  {
    // Unlock the skin
    if (coins >= skin.cost && !skinManager.IsUnlocked(skinIndex))
    {
      if(SaveText == "Money")
          {
          PlayerPrefs.SetInt("Money", coins - skin.cost);
          money = coins - skin.cost;
          skinManager.Unlock(skinIndex);
          buyButton.gameObject.SetActive(false);
          skinManager.SelectSkin(skinIndex);
          moneytext.text = money.ToString("D1");
          PlayerPrefs.SetInt("BuyInStore", 1);
          }

          if(SaveText == "diamonds")
          {
          PlayerPrefs.SetInt("diamonds", coins - skin.cost);
          diamond = coins - skin.cost;
          skinManager.Unlock(skinIndex);
          buyButton.gameObject.SetActive(false);
          skinManager.SelectSkin(skinIndex);
          diamondtext.text = diamond.ToString("D1");
          PlayerPrefs.SetInt("BuyInStore", 1);
          }
    }
    else
    {
      Debug.Log("Not enough coins :(");
    }
  }
}
