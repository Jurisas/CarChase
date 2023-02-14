using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private CollectibleManager skinManager;
    [SerializeField] private int skinIndex;
    [SerializeField] private Button Button;
    [SerializeField] private Text costText;
    [SerializeField] private Text Name;
    public Text coinsText;

    private Collectibles skin;

    private void Start()
    {
        skin = skinManager.skins[skinIndex];

        GetComponent<Image>().sprite = skin.sprite;
        Name.text = skin.name;

        if (skinManager.IsUnlocked(skinIndex))
        {
            Button.gameObject.SetActive(true);
            costText.text = PlayerPrefs.GetInt(skinManager.skins[skinIndex].name) + " of " + skin.amount.ToString();
        }
        else
        {
            Button.gameObject.SetActive(true);
            costText.text = PlayerPrefs.GetInt(skinManager.skins[skinIndex].name) + " of " + skin.amount.ToString();
        }
    }
    

    public void OnBuyButtonPressed()
    {
        int coins = PlayerPrefs.GetInt(skinManager.skins[skinIndex].name);

        if (coins >= skin.amount)
        {
            PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")+500);
            PlayerPrefs.SetInt(skinManager.skins[skinIndex].name,coins-skin.amount);
            Button.gameObject.SetActive(true);
        }
    }
}