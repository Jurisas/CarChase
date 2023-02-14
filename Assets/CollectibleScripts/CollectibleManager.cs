using UnityEngine;

[CreateAssetMenu(fileName = "CollectibleManager", menuName = "Collectible Manager")]
public class CollectibleManager : ScriptableObject
{
    [SerializeField] public Collectibles[] skins;

    private const string Prefix = "Collectible_";

    public void AddFlower(int id)
    {
        int number = PlayerPrefs.GetInt(skins[id].name);
        PlayerPrefs.SetInt(skins[id].name,number+1);
    }
    
    public int GetFlower(int id)
    {
        return PlayerPrefs.GetInt(skins[id].name);
    }

    public void Unlock(int skinIndex) => PlayerPrefs.SetInt(Prefix + skinIndex, 1);
    public bool IsUnlocked(int skinIndex) => PlayerPrefs.GetInt(Prefix + skinIndex, 0) == 1;

}