using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinManager", menuName = "Skin Manager")]
public class SkinManager : ScriptableObject
{
    [SerializeField] public Skin[] skins;

    private const string Prefix = "Skin_";
    private const string selectedSkin = "selectedSkin";

    public void selectSkin(int skinIndex) => PlayerPrefs.SetInt(selectedSkin, skinIndex);

    public Skin getSelectedSkin()
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

    public void Unlock(int skinIndex) => PlayerPrefs.SetInt(Prefix + skinIndex, 1);
    public bool IsUnlocked(int skinIndex) => PlayerPrefs.GetInt(Prefix + skinIndex, 0) == 1;
}
