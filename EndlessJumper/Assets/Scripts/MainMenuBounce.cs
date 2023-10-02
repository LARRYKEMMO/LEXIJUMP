using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuBounce : MonoBehaviour
{
    private MainMenuTile2Script Tile2Script;
    private float Bounce = 10f;
    public GameObject Player;
    private Rigidbody2D Rigidbody;
    private int Jumper = 0;
    public GameObject Background;
    private SpriteRenderer SPTile;
    private SpriteRenderer SPRBackground;
    public Sprite TileSprite1;
    public Sprite TileSprite2;
    public Sprite TileSprite3;
    public Sprite BSprite1;
    public Sprite BSprite2;
    public Sprite BSprite3;
    // Start is called before the first frame update
    void Start()
    {
        SPTile = GetComponent<SpriteRenderer>();
        SPRBackground = Background.GetComponent<SpriteRenderer>();
        Tile2Script = FindAnyObjectByType<MainMenuTile2Script>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null)
        {
            if (collision.gameObject.tag == "Player")
            {
                Jumper++;
                Rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
                Rigidbody.AddForce(Vector2.up * Bounce, ForceMode2D.Impulse);
                
                if(Jumper == 1)
                {
                    Tile2Script.Switch = 2;
                    SPTile.sprite = TileSprite2;
                    SPRBackground.sprite = BSprite2;
                    //Invoke("ResetSprites", 2f);
                }
                else if(Jumper == 2)
                {
                    ResetSprites();
                }
                else if(Jumper == 3)
                {
                    ResetSpritesFinal();
                }
            }
        }
    }

    private void ResetSprites()
    {
        Tile2Script.Switch = 3;
        SPTile.sprite = TileSprite3;
        SPRBackground.sprite = BSprite3;
        //Jumper = 0;
    }

    private void ResetSpritesFinal()
    {
        Tile2Script.Switch = 1;
        SPTile.sprite = TileSprite1;
        SPRBackground.sprite = BSprite1;
        Jumper = 0;
    }
}
