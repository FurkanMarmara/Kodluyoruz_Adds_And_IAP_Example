using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAdsController : MonoBehaviour,IUnityAdsListener
{
    private string _gameID = "1234567";
    private AdsPlacementTypes _placement = AdsPlacementTypes.bannerPlacement;

    private void Start()
    {
        Advertisement.Initialize(_gameID, true);
    }

    private void ShowBannerAds()
    {

        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(_placement.ToString());
    }

    public void OnUnityAdsDidError(string message)
    {
       
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }


}
