using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Text ScoreText;

    public Sprite soundOff;
    public Sprite soundOn;
    public Image soundButtonImage;
    
    void Start()
    {
        Time.timeScale = 1f;
        ScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            soundButtonImage.sprite = soundOn;
        }
        else
        {
            soundButtonImage.sprite = soundOff;
        }
    }
    
    public void StartGameBtn()
    {
        SceneFader.instance.FadeOut("Game");
        FindObjectOfType<AudioManager>().Play("Button");
    }


    public void SoundButton()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            PlayerPrefs.SetInt("Sound", 0);
            soundButtonImage.sprite = soundOff;
            FindObjectOfType<AudioManager>().Play("Button");
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
            soundButtonImage.sprite = soundOn;
            FindObjectOfType<AudioManager>().Play("Button");
        }
    }
    



}
