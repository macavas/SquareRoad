using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;

    public GameObject deathEffect;

    public bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Time.timeScale = 0f;
        isAlive = false;
        score = 0;
        UIManager.instance.ShowScore(score);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        isAlive = true;
    }
    
    public void IncreaseScore()
    {
        score++;
        UIManager.instance.ShowScore(score);
        if(score % 10 == 0)
        {
            PlayerMovement.instance.IncreaseSpeed();
        }
    }

    public void EndGame(Vector3 effPos)
    {
        CheckHighScore();
        StartCoroutine(DeathAnimation(effPos));
    }

    private void CheckHighScore()
    {
        int oldScore = PlayerPrefs.GetInt("HighScore", 0);
        if(oldScore < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
    
    IEnumerator DeathAnimation(Vector3 effPos)
    {
        GameObject effect = Instantiate(deathEffect, effPos, Quaternion.identity);
        isAlive = false;
        FindObjectOfType<AudioManager>().Play("Death");
        yield return new WaitForSecondsRealtime(1f);
        Destroy(effect);
        UIManager.instance.ShowEndGamePanel();
    }
}
