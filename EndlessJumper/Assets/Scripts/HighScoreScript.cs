using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    private int Score;

    public Text Lvl1;
    public Text Lvl2;
    public Text Lvl3;


    
    // Start is called before the first frame update
    void Start()
    {
        ReadTextToFile1();
        ReadTextToFile2();
        ReadTextToFile3();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReadTextToFile1()
    {
        Score = PlayerPrefs.GetInt("HIGHSCORE1");
        Lvl1.text = Score.ToString();
        
    }

    private void ReadTextToFile2()
    {
        Score = PlayerPrefs.GetInt("HIGHSCORE2");
        Lvl2.text = Score.ToString();
    }


    private void ReadTextToFile3()
    {
        Score = PlayerPrefs.GetInt("HIGHSCORE3");
        Lvl3.text = Score.ToString();
    }
}
