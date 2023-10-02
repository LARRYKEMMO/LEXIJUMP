using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MenuManager : MonoBehaviour
{
    public GameObject FadeObject;
    public LevelLoaderScript LevelObject;
    private int TempScore = 0;
    private string filePath1 = "Assets/DataBase/UNLOCK.txt";
    // Start is called before the first frame update
    void Start()
    {
        TempScore = PlayerPrefs.GetInt("UNLOCK");
        //Invoke("DisableFade", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void MoveToHS()
    {
        SceneManager.LoadScene("HighScoreScene");
    }

    public void MoveToSplash()
    {
        SceneManager.LoadScene("SplashScreen");
    }

    public void MoveToLevel1()
    {
        TempScore = PlayerPrefs.GetInt("UNLOCK");
        if(TempScore.Equals(0))
        {
            SceneManager.LoadScene("Level1");

        }
        else if(TempScore.Equals(1))
        {
            SceneManager.LoadScene("SelectionScene");
        }
    }

    public void MoveToLevel1Final()
    {
        LevelObject.LoadNextLevel3();
    }

    public void GoTo1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void MoveToLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void MoveToLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void Quit()
    {
        Application.Quit();
    }

    

    private void ReadTextToFile3(string path)
    {
        try
        {
            // Read the text from the file.
            string fileContents = System.IO.File.ReadAllText(path);
            TempScore = Convert.ToInt32(fileContents);
            //Debug.Log("Text read from file: \n" + Score);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error reading from file: " + e.Message);
        }
    }

    private void DisableFade()
    {
        FadeObject.SetActive(false);
    }
}
