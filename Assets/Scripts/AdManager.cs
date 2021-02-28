using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    private string playStoreID = "3701239";
    private string appStoreId = "3701238";

    private string inerstitialAd = "video";

    public bool isTargetPlayStore;
    public bool isTestAd;

    private void Start()
    {
        InitializeAdvertisment();
    }

    private void InitializeAdvertisment()
    {
        if (isTargetPlayStore) { Advertisement.Initialize(playStoreID, isTestAd); return; }
        Advertisement.Initialize(appStoreId, isTestAd);
    }

    public void PlayInerstitialAd()
    {
        if (!Advertisement.IsReady(inerstitialAd)) { return;  }
        Advertisement.Show(inerstitialAd);
    }
}
