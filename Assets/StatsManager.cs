using UnityEngine;

public class StatsManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static float _highscore;
    private static int _coins;
    void Start()
    {
        _highscore = PlayerPrefs.GetFloat ("highscore", _highscore);
        _coins = PlayerPrefs.GetInt ("coins", _coins);
    }
}
