using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC3Script : MonoBehaviour
{
    public PlayerMovement PlayerScript;
    private AudioSource GameOver;
    // Start is called before the first frame update
    void Start()
    {
        GameOver = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "DeathPlayer")
        {
            PlayerScript.EndGameNow();
            GameOver.Play();
        }
    }
}
