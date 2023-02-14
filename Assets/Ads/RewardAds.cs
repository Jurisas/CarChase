using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

// how to start a rewarded ad in unity games after pressign a button
[RequireComponent (typeof (Button))]
public class RewardAds : MonoBehaviour, IUnityAdsListener {

    #if UNITY_IOS
    private string gameId = "4599712";
    #elif UNITY_ANDROID
    private string gameId = "4599713";
    #endif

    Button myButton;
    public string myPlacementId = "Rewarded_Android";

    void Start () {   
        myButton = GetComponent <Button> ();

        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady (myPlacementId); 

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener (ShowRewardedVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener (this);
        Advertisement.Initialize (gameId, true);
    }

    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo () {
        Advertisement.Show (myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady (string placementId) {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId) {        
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished) {
            // Reward the user for watching the ad to completion.
            int getCoins = PlayerPrefs.GetInt("coins");
            if (getCoins > 500)
            {
                PlayerPrefs.SetInt("coins", getCoins + (getCoins / 10));
            }
            else
            {
                PlayerPrefs.SetInt("coins", getCoins + 50);
            }
        } else if (showResult == ShowResult.Skipped) {
            // Do not reward the user for skipping the ad.
        } else if (showResult == ShowResult.Failed) {
            Debug.LogWarning ("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError (string message) {
        // Log the error.
    }

    public void OnUnityAdsDidStart (string placementId) {
        // Optional actions to take when the end-users triggers an ad.
    } 
}