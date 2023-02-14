using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class RoadSkinShopItem : MonoBehaviour
{
    [SerializeField] private RoadSkinManager skinManager;
    [SerializeField] private int skinIndex;
    [SerializeField] private Button buyButton;
    [SerializeField] private Text costText;
    [SerializeField] private Text roadName;
    public Text coinsText;

    private Roads skin;

    private void Start()
    {
        skin = skinManager.skins[skinIndex];

        GetComponent<Image>().sprite = skin.sprite;
        roadName.text = skin.name;
        
        if (skinManager.IsUnlocked(skinIndex))
        {
            buyButton.gameObject.SetActive(false);
            costText.text = skin.price.ToString();
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            costText.text = skin.price.ToString();
        }
    }

    public void OnSkinPressed()
    {
        if (skinManager.IsUnlocked(skinIndex))
        {
            skinManager.selectSkin(skinIndex);
        }
    }

    public void OnBuyButtonPressed()
    {
        int coins = PlayerPrefs.GetInt("coins");

        if (coins >= skin.price && !skinManager.IsUnlocked(skinIndex))
        {
            PlayerPrefs.SetInt("coins", coins-skin.price);
            coinsText.text = "COINS: " + PlayerPrefs.GetInt("coins");
            skinManager.Unlock(skinIndex);
            buyButton.gameObject.SetActive(false);
            skinManager.selectSkin(skinIndex);
        }
    }
}