#define TEST
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour,IUnityAdsListener
{

    public static AdsManager instance;

    #region Singleton
    private void Awake()
    {
        if (instance!=null)
        {
            instance = this;
            return;
        }
        else
        {
            if (instance != this)
            {
                Destroy(instance);
            }
        }
        instance = this;

    }
    #endregion

#if UNITY_IOS
    private string _gameID = "1234567";
#elif UNITY_ANDROID
    private string _gameID = "1234567";
    #else
    private string _gameID = "1234567";
    #endif

    #if TEST
    private bool _isTest = true;
#else
    private bool _isTest = false;
#endif


    private void Start()
    {
        Advertisement.Initialize(_gameID, true);
        Advertisement.AddListener(this);
    }

    public void ShowAds(AdsPlacementTypes adsType)
    {
        switch (adsType)
        {
            case AdsPlacementTypes.rewardedVideo:
                if (Advertisement.IsReady(adsType.ToString()))
                {
                    Advertisement.Show(adsType.ToString());
                }
                else
                {
                    Debug.Log("Havuzda rewarded reklam yok");
                }
                break;
            case AdsPlacementTypes.bannerPlacement:
                Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                Advertisement.Banner.Show(adsType.ToString());
                break;
            case AdsPlacementTypes.intersitialAds:
                if (Advertisement.IsReady())
                {
                    Advertisement.Show();
                }
                else
                {
                    Debug.LogWarning("Havuz Boş");
                }
                break;
        }
    }

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
