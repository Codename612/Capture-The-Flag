using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Canvas PauseUI;
    [SerializeField]
    private Canvas GameUI;
    [SerializeField]
    private Canvas GameFinishedUI;

    public Text winText;

    public GameObject AdManagement;
    private AdManager AdManager;

    [HideInInspector]
    public string winner = null;

    void Awake()
    {
        AdManager = AdManagement.GetComponent<AdManager>();
    }

    void Start()
    {
        Resume();
    }

    void Update()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        PauseUI.gameObject.SetActive(true);
        GameUI.gameObject.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PauseUI.gameObject.SetActive(false);
        GameUI.gameObject.SetActive(true);
        GameFinishedUI.gameObject.SetActive(false);
    }

    public void ReturnToMenu()
    {
        AdManager.PlayInerstitialAd();
        SceneManager.LoadScene("Main Menu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        winText.text = winner + " Wins!";
        Time.timeScale = 0f;
        GameUI.gameObject.SetActive(false);
        GameFinishedUI.gameObject.SetActive(true);
    }
}
