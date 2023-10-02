using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("MoveToSplash", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToSplash()
    {
        SceneManager.LoadScene("SplashScreen");
    }
}
