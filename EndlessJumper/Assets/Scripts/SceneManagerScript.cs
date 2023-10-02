using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("MoveToMenu", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void MoveToSplash()
    {
        SceneManager.LoadScene("SplashScreen");
    }

    public void MoveToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
