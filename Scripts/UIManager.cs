using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public  class UIManager : MonoBehaviour { 


    public static UIManager instance;

    public  Text scoreText;

    public GameObject endGamePanel;
    public GameObject tapToStartButton;

    private void Awake()
    {
        instance = this;
        endGamePanel.SetActive(false);
        tapToStartButton.SetActive(true);
    }

    public  void ShowScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowEndGamePanel()
    {
        endGamePanel.SetActive(true);
    }

    public void RestartGameBtn()
    {
        SceneFader.instance.FadeOut("Game");
        FindObjectOfType<AudioManager>().Play("Button");
    }
    public void MenuBtn()
    {
        SceneFader.instance.FadeOut("Menu");
        FindObjectOfType<AudioManager>().Play("Button");
    }

    public void StartGame()
    {
        GameManager.instance.StartGame();
        tapToStartButton.SetActive(false);
    }

}
