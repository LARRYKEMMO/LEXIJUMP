using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;
using System;

public class TransitionScript : MonoBehaviour
{
    private int score = 0;
    private int TextScene;
    private string filePath1 = "Assets/DataBase/LVL.txt";
    
    private string filePath2 = "Assets/DataBase/SCORE1.txt";
    private string filePath3 = "Assets/DataBase/SCORE2.txt";
    private string filePath7 = "Assets/DataBase/SCORE3.txt";

    private string filePath4 = "Assets/DataBase/LVL1.txt";
    private string filePath5 = "Assets/DataBase/LVL2.txt";
    private string filePath6 = "Assets/DataBase/LVL3.txt";

    private Material material;
    private SpriteRenderer Renderer;
    private Color newColor;
    private string TargetSceneName;
    private Scene CurrentScene;
    private bool Fade = false;
    private PlayerMovement PlayerScript;
    private ScoreScript SScript;
    private TileSpawn TSScript;
    private SoundManagerScript SMScript;
    // Start is called before the first frame update
    void Start()
    {
        PlayerScript = FindObjectOfType<PlayerMovement>();
        SScript = FindObjectOfType<ScoreScript>();
        TSScript = FindObjectOfType<TileSpawn>();
        SMScript = FindAnyObjectByType<SoundManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Fade == true)
        {
            float ImageValue = newColor.a;
            newColor.a = ImageValue - 0.05f;
            material.color = newColor;
            if(newColor.a < 0)
            {
                Fade = false;
                CurrentScene = SceneManager.GetActiveScene();
                TargetSceneName = CurrentScene.name;
                if(TargetSceneName.Equals("Level1"))
                {
                    TextScene = 1;
                }
                //SScript.SceneString = CurrentScene.name;
                SceneManager.LoadScene("ScoreScene");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            SMScript.PlayVortex();
            PlayerScript.Boost = false;
            PlayerScript.TurboObject.SetActive(false);
            collision.collider.GetComponent<Rigidbody2D>().gravityScale = 0;
            score = (TSScript.LetterCounterInteger - TSScript.LetterCounter ) - ((int)(TSScript.TimeScore) / 100);
            Debug.Log("Score " + score);
            if(TSScript.LetterCounterInteger == 5)
            {
                PlayerPrefs.SetInt("LVL", 1);
                WriteTextToFile(filePath1, "1");
                WriteTextToFile(filePath4, "1");
                PlayerPrefs.SetInt("SCORE1", score);
                WriteTextToFile(filePath2, score.ToString());
            }
            else if(TSScript.LetterCounterInteger == 21)
            {
                PlayerPrefs.SetInt("LVL", 2);
                WriteTextToFile(filePath1, "2");
                WriteTextToFile(filePath5, "2");
                PlayerPrefs.SetInt("SCORE2", score);
                WriteTextToFile(filePath3, score.ToString());
            }
            else if(TSScript.LetterCounterInteger == 26)
            {
                PlayerPrefs.SetInt("LVL", 3);
                WriteTextToFile(filePath1, "3");
                WriteTextToFile(filePath6, "3");
                PlayerPrefs.SetInt("SCORE3", score);
                WriteTextToFile(filePath7, score.ToString());
            }
            Renderer = collision.collider.GetComponent<SpriteRenderer>();
            material = Renderer.material;
            newColor = material.color;
            Fade = true;
        }
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

}
