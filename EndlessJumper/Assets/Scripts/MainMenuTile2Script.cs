using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTile2Script : MonoBehaviour
{
    public int Switch = 1;
    private SpriteRenderer SPTile;
    public Sprite TileSprite1;
    public Sprite TileSprite2;
    public Sprite TileSprite3;

    // Start is called before the first frame update
    void Start()
    {
        SPTile = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Switch == 1)
        {
            SPTile.sprite = TileSprite1;
        }
        else if(Switch == 2)
        {
            SPTile.sprite = TileSprite2;
        }
        else if(Switch == 3)
        {
            SPTile.sprite = TileSprite3;
        }
    }

}
