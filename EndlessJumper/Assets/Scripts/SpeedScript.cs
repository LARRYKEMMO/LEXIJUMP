using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedScript : MonoBehaviour
{
    private SoundManagerScript SMScript;
    private float Bounce = 10f;
    private Rigidbody2D Rigidbody;
    private Scene CurrentScene;
    // Start is called before the first frame update
    private PlayerMovement playerScript;
 
    void Start()
    {
        CurrentScene = SceneManager.GetActiveScene();
        playerScript = FindObjectOfType<PlayerMovement>();
        SMScript = FindAnyObjectByType<SoundManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SMScript.PlaySpeed();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if(playerScript.Boost == false)
            {
                Rigidbody.AddForce(Vector2.up * Bounce, ForceMode2D.Impulse);
            }
            Invoke("DisplayPowerUp", 0.2f);
            //Destroy(gameObject);
        }
    }

    private void DisplayPowerUp()
    {
        SMScript.PlayBoost();
        playerScript.Boost = true;
        playerScript.BoostTimer += 5;
        //    collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
