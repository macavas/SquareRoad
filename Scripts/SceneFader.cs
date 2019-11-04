using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public static SceneFader instance;

    public Animator fadeAnim;
    public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void FadeOut(string lvlName)
    {
        levelName = lvlName;
        fadeAnim.SetTrigger("FadeOut");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }

}
