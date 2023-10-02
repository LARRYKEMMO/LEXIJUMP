using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "LogoScreen")
        {
            Invoke("LoadNextLevel", 2f);
        }
        else if(SceneManager.GetActiveScene().name == "SplashScreen")
        {
            Invoke("LoadNextLevel2", 2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    LoadNextLevel();
        //}
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel("SplashScreen"));
    }

    public void LoadNextLevel2()
    {
        StartCoroutine(LoadLevel("MenuScene"));
    }

    public void LoadNextLevel3()
    {
        StartCoroutine(LoadLevel("Level1"));
    }

    public void LoadNextLevel4()
    {
        StartCoroutine(LoadLevel("SelectionScene"));
    }

    IEnumerator LoadLevel(string LevelName)
    {
        //transition.SetTrigger("StartFade");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(LevelName);
    }
}
