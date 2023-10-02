using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private DontDestroyScript DDScript;
    private SoundManagerScript SMScript;
    public GameObject CameraCollider3;
    public GameObject GameOver;
    public GameObject TextObject;
    public GameObject Trail1;
    public GameObject Trail2;
    public GameObject Trail3;
    public GameObject Trail4;
    public Sprite DeadSprite;
    public GameObject TurboObject;
    private SpriteRenderer SpriteRenderer;
    private Rigidbody2D rb;
    private BoxCollider2D CCC;
    private int speed = 5;
    public float horizontal;
    private bool facingRight = false;
    //private bool moveUp = false;
    private Animator animator;
    private bool isDeath = false;
    private bool End = false;
    private string TargetSceneName;
    private Scene CurrentScene;
    public bool Boost = false;
    public float BoostTimer = 0;
    private TileSpawn TileSpawnScript;
    private ShatteredScript SScript;
    public GameObject FadeObject;
    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DisableFade", 0.5f);
        SimpleInput.Init();
        TileSpawnScript = FindObjectOfType<TileSpawn>();
        SScript = FindObjectOfType<ShatteredScript>();
        CurrentScene = SceneManager.GetActiveScene();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        SMScript = FindAnyObjectByType<SoundManagerScript>();
        DDScript = FindAnyObjectByType<DontDestroyScript>();
        if(DDScript != null)
        {
            DDScript.DestroyAudioMenu();

        }
    }

    // Update is called once per frame
    void Update()
    {


        if (Boost == true)
        {
            TileSpawnScript.TriggerTiles();
            rb.gravityScale = 0;
            TurboObject.SetActive(true);
            Vector3 newPosition = transform.position + Vector3.up * 0.5f * Time.deltaTime;
            transform.position = newPosition;
            Trail1.SetActive(true);
            Trail2.SetActive(true);
            Trail3.SetActive(true);
            Trail4.SetActive(false);
            BoostTimer -= 0.01f;

            if(BoostTimer < 0)
            {
                SMScript.StopBoost();
                Boost = false;
                TileSpawnScript.UnTriggerTiles();
                rb.gravityScale = 1;
                Trail1.SetActive(false);
                Trail2.SetActive(false);
                Trail3.SetActive(false);
                Trail4.SetActive(true);
                TurboObject.SetActive(false);
            }
        }

        if (isDeath == false)
        {
            horizontal = SimpleInput.GetAxis("Horizontal");
            Flip();
        }
        
        if(gameObject.transform.position.y <= CameraCollider3.transform.position.y + 6)
        {
            gameObject.tag = "DeathPlayer";
            CCC = CameraCollider3.GetComponent<BoxCollider2D>();
            CCC.isTrigger = false;
            

        }

        if(End == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if(facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Boost == true)
        {
            if(collision.collider.tag == "StopBoost")
            {
                BoostTimer = 0;
            }
        }
    }

    public void EndGameNow()
    {
        SpriteRenderer.sprite = DeadSprite;
        animator.SetBool("Death", true);
        isDeath = true;
        GameOver.SetActive(true);
        TextObject.SetActive(true);
        End = true;
        
    }

    public void lastMinuteSave()
    {
        gameObject.tag = "Player";
        CCC = CameraCollider3.GetComponent<BoxCollider2D>();
        CCC.isTrigger = true;
    }

    public void NegativeHorizontal()
    {
        Debug.Log("Here");
        horizontal = -1;
    }

    public void PositiveHorizontal()
    {
        horizontal = 1;
    }

    private void DisableFade()
    {
        FadeObject.SetActive(false);
    }
}
