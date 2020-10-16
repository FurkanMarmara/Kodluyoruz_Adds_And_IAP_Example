using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAdsController : MonoBehaviour, IUnityAdsListener
{
    /*
    private string _gameID = "1234567";
    private AdsPlacementTypes _placement = AdsPlacementTypes.rewardedVideo;


    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameID, true);
    }
    */
    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                //Dont give player reward.
                break;
            case ShowResult.Skipped:
                //Dont give player reward.
                break;
            case ShowResult.Finished:
                Debug.Log("Reward to player,money to me");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }


    private void OnDisable()
    {
        Advertisement.RemoveListener(this);
    }

}
