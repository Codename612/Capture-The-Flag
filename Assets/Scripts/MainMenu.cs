using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject AdManagement;
    private AdManager AdManager;

    void Awake()
    {
        AdManager = AdManagement.GetComponent<AdManager>();
    }

    public void Play()
    {
        AdManager.PlayInerstitialAd();
        SceneManager.LoadScene("Game");
    }
}
