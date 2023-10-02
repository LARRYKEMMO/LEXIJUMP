using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEffect : MonoBehaviour
{
    private PlayerMovement playerScript;
    private SoundManagerScript SMScript;
    private float Bounce = 8f;
    public GameObject Player;
    private Rigidbody2D Rigidbody;
    private ParticleScript Pscript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindAnyObjectByType<PlayerMovement>();
        SMScript = FindAnyObjectByType<SoundManagerScript>();
        Pscript = FindAnyObjectByType<ParticleScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null)
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "DeathPlayer")
            {
                Pscript.PlayParticle(gameObject.transform.position);
                playerScript.lastMinuteSave();
                SMScript.PlayBoing();
                Rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
                Rigidbody.AddForce(Vector2.up * Bounce, ForceMode2D.Impulse);
            }
        }
    }
}
