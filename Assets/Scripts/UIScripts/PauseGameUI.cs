using System;
using UnityEngine;
using UnityEngine.UI;
public class PauseGameUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button closeButton;
    void Awake()
    {
        resumeButton.onClick.AddListener(() =>
        {
            GameManager.Instance.TogglePauseGame();
        });
        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        optionsButton.onClick.AddListener(() =>
        {
            Hide();
            OptionsUI.Instance.Show(Show);
        });
        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });
        resetButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });
    }
    void Start()
    {
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnPaused += GameManager_OnGameUnPaused;
        Hide();
    }
    void GameManager_OnGamePaused(object sender, EventArgs e)
    {
        Show();
    }
    void GameManager_OnGameUnPaused(object sender, EventArgs e)
    {
        Hide();
    }
    void Show()
    {
        gameObject.SetActive(true);
        resumeButton.Select();
    }
    void Hide()
    {

        gameObject.SetActive(false);
    }
}
