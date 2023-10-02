using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ScoreScript : MonoBehaviour
{
    private string filePath1 = "Assets/DataBase/LVL.txt";
    private string filePath2 = "Assets/DataBase/SCORE1.txt";
    private string filePath6 = "Assets/DataBase/SCORE2.txt";
    private string filePath7 = "Assets/DataBase/SCORE3.txt";

    private string filePath3 = "Assets/DataBase/HIGHSCORE1.txt";
    private string filePath4 = "Assets/DataBase/HIGHSCORE2.txt";
    private string filePath5 = "Assets/DataBase/HIGHSCORE3.txt";

    private string filePath10 = "Assets/DataBase/UNLOCK.txt";

    public GameObject char1;
    public GameObject char2;
    public GameObject char3;

    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public GameObject Star4;
    public GameObject Star5;
    public GameObject Star6;
    public GameObject Star7;
    public GameObject Star8;
    public GameObject Star9;
    public GameObject Star10;

    public Text Value;
    public Text ValueHS;
    private int FinalScore = 0;
    private int HighScore = 0;
    private int TempScore2 = 0;
    public int Score = 0;
    public int TempScore = 0;
    public string SceneString;
    public string ScoreString;
    public GameObject Next;
    private int Index = 0;
    private AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioClip ScoreClip;
    public AudioClip HighScoreClip;
    private int PlayCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ReadTextToFile3();

        if (TempScore == 1)
        {
            HighScore = PlayerPrefs.GetInt("HIGHSCORE1", 0);
            Score = PlayerPrefs.GetInt("SCORE1");
            ReadTextToFile2();
        }
        else if (TempScore == 2)
        {
            HighScore = PlayerPrefs.GetInt("HIGHSCORE2", 0);
            Score = PlayerPrefs.GetInt("SCORE2");
            ReadTextToFile2();
        }
        else if (TempScore == 3)
        {
            HighScore = PlayerPrefs.GetInt("HIGHSCORE3", 0);
            Score = PlayerPrefs.GetInt("SCORE3");
            ReadTextToFile2();
        }

        
        Score = Score * 50;
        Index = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
            
            if (FinalScore < Score)
            {
                FinalScore++;
                Value.text = FinalScore.ToString();
                Debug.Log(FinalScore);
            }
            else if (FinalScore.Equals(Score))
            {
                Next.SetActive(true);
                Debug.Log(FinalScore);
                audioSource2.Stop();

            if (Score >= TempScore2)
            {
                if (PlayCounter < 1)
                {
                    audioSource.clip = HighScoreClip;
                    audioSource.Play();
                    PlayCounter++;
                }
                char3.SetActive(true);
            }
            else if (Score < TempScore2 && Score > 0)
            {
                if (PlayCounter < 1)
                {
                    audioSource.clip = ScoreClip;
                    audioSource.Play();
                    PlayCounter++;
                }
                char2.SetActive(true);
            }
            else if (Score < 0)
            {
                if (PlayCounter < 1)
                {
                    audioSource.clip = ScoreClip;
                    audioSource.Play();
                    PlayCounter++;
                }
                char1.SetActive(true);
            }

                //Invoke("Transition", 5f);
                
            }
        

    }

    public void Transition()
    {
        if (TempScore == 1)
        {
            SceneManager.LoadScene("Level2");
        }
        else if (TempScore == 2)
        {
            SceneManager.LoadScene("Level3");
        }
        else if (TempScore == 3)
        {
            PlayerPrefs.SetInt("UNLOCK", 1);
            SceneManager.LoadScene("EndScene");
        }

    }

    //private void ReadTextToFile1()
    //{
    //    //try
    //    //{
    //    //    // Read the text from the file.
    //    //    string fileContents = System.IO.File.ReadAllText(path);
    //    //    Score = Convert.ToInt32(fileContents);
    //    //    Debug.Log("SCORE: " + Score);
    //    //    Debug.Log("Text read from file: \n" + Score);
    //    //}
    //    //catch (System.Exception e)
    //    //{
    //    //    Debug.LogError("Error reading from file: " + e.Message);
    //    //}
    //}

    private void ReadTextToFile2()
    {

        if (TempScore == 1)
        {
            TempScore2 = PlayerPrefs.GetInt("HIGHSCORE1");
        }
        else if (TempScore == 2)
        {
            TempScore2 = PlayerPrefs.GetInt("HIGHSCORE2");
        }
        else if (TempScore == 3)
        {
            TempScore2 = PlayerPrefs.GetInt("HIGHSCORE3");
        }


        if ((Score * 50) > TempScore2)
        {
            Debug.Log("SCORE2: " + HighScore);
            HighScore = Score * 50;
            Debug.Log("HIGHSCORE: " + HighScore);
            ValueHS.text = HighScore.ToString();
            EnableStars();

            if (TempScore == 1)
            {
                PlayerPrefs.SetInt("HIGHSCORE1", HighScore);
            }
            else if (TempScore == 2)
            {
                PlayerPrefs.SetInt("HIGHSCORE2", HighScore);
            }
            else if (TempScore == 3)
            {
                PlayerPrefs.SetInt("HIGHSCORE3", HighScore);
            }
        }
        else
        {
            ValueHS.text = TempScore2.ToString();
        }
        //try
        //{

        //    Debug.Log("Text read from file: \n" + Score);
        //}
        //catch (System.Exception e)
        //{
        //    Debug.LogError("Error reading from file: " + e.Message);
        //}
    }

    private void ReadTextToFile3()
    {
        TempScore = PlayerPrefs.GetInt("LVL");
        //try
        //{
        //    // Read the text from the file.
        //    string fileContents = System.IO.File.ReadAllText(path);
        //    TempScore = Convert.ToInt32(fileContents);
        //    Debug.Log("Text read from file: \n" + Score);
        //}
        //catch (System.Exception e)
        //{
        //    Debug.LogError("Error reading from file: " + e.Message);
        //}
    }


    private void WriteTextToFile(string path, string text)
    {
        try
        {
            // Create a StreamWriter to write to the file.
            using (StreamWriter writer = new StreamWriter(path))
            {
                // Write the text to the file.
                writer.WriteLine(text);
            }

            Debug.Log("Text written to file: " + path);
        }
        catch (Exception e)
        {
            Debug.LogError("Error writing to file: " + e.Message);
        }
    }

    private void EnableStars()
    {
        Star1.SetActive(true);
        Star2.SetActive(true);
        Star3.SetActive(true);
        Star4.SetActive(true);
        Star5.SetActive(true);
        Star6.SetActive(true);
        Star7.SetActive(true);
        Star8.SetActive(true);
        Star9.SetActive(true);
        Star10.SetActive(true);
    }

    private void DisableStars()
    {
        Star1.SetActive(true);
        Star2.SetActive(true);
        Star3.SetActive(true);
        Star4.SetActive(true);
        Star5.SetActive(true);
        Star6.SetActive(true);
        Star7.SetActive(true);
        Star8.SetActive(true);
        Star9.SetActive(true);
        Star10.SetActive(true);
    }
}
