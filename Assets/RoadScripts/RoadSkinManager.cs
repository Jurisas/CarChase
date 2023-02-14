using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoadSkinManager", menuName = "Road Skin Manager")]
public class RoadSkinManager : ScriptableObject
{
    [SerializeField] public Roads[] skins;

    private const string Prefix = "RoadSkin_";
    private const string selectedSkin = "RoadSelectedSkin";

    public void selectSkin(int skinIndex) => PlayerPrefs.SetInt(selectedSkin, skinIndex);

    public Roads getSelectedSkin()
    {
        int skinIndex = PlayerPrefs.GetInt(selectedSkin, 0);
        if (skinIndex >= 0 && skinIndex < skins.Length)
        {
            return skins[skinIndex];
        }
        else
        {
            return null;
        }
    }

    public int SkinIndex()
    {
        return PlayerPrefs.GetInt(selectedSkin, 0);
    }
    public GameObject TrafficCar()
    {
        return getSelectedSkin().car;
    }

    public void Unlock(int skinIndex) => PlayerPrefs.SetInt(Prefix + skinIndex, 1);
    public bool IsUnlocked(int skinIndex) => PlayerPrefs.GetInt(Prefix + skinIndex, 0) == 1;
}