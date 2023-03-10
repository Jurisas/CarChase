using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoadShopController : MonoBehaviour
{
    [SerializeField] private Image selectedSkin;
    [SerializeField] private RoadSkinManager skinManager;

    private void Update()
    {
        selectedSkin.sprite = skinManager.getSelectedSkin().sprite;
        selectedSkin.SetNativeSize();
    }
    

}