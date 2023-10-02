using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineColliderScript : MonoBehaviour
{
    private int LetterIndex;
    public bool CollidedWithPlayer = false;
    public GameObject MainLetter;
    private PlayerMovement PScript;
    private TileSpawn TileScript;
    private StarScript starScript;
    private LAScript LetterAudioScript;

    // Start is called before the first frame update
    void Start()
    {
        TileScript = FindAnyObjectByType<TileSpawn>();
        PScript = FindObjectOfType<PlayerMovement>();
        starScript = FindAnyObjectByType<StarScript>();
        LetterAudioScript = FindAnyObjectByType<LAScript>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && PScript.Boost == true)
        {
            //Debug.Log("I've Collided with player !!!!!!!!!!!!!!!!");
            starScript.letterPosition = gameObject.transform.position;
            ChooseSound();
            Destroy(MainLetter);
            TileScript.DeleteLetter();

        }
    }

    private void ChooseSound()
    {
        LetterIndex = TileScript.Letters.IndexOf(MainLetter);
        if (TileScript.LetterCounterInteger == 5)
        {
            if (LetterIndex == 0)
            {
                LetterAudioScript.PlayAudioA();
            }
            else if (LetterIndex == 1)
            {
                LetterAudioScript.PlayAudioE();
            }
            else if (LetterIndex == 2)
            {
                LetterAudioScript.PlayAudioI();
            }
            else if (LetterIndex == 3)
            {
                LetterAudioScript.PlayAudioO();
            }
            else if (LetterIndex == 4)
            {
                LetterAudioScript.PlayAudioU();
            }
        }
        else if(TileScript.LetterCounterInteger == 21)
        {
            if (LetterIndex == 0)
            {
                LetterAudioScript.PlayAudioB();
            }
            else if (LetterIndex == 1)
            {
                LetterAudioScript.PlayAudioC();
            }
            else if (LetterIndex == 2)
            {
                LetterAudioScript.PlayAudioD();
            }
            else if (LetterIndex == 3)
            {
                LetterAudioScript.PlayAudioF();
            }
            else if (LetterIndex == 4)
            {
                LetterAudioScript.PlayAudioJ();
            }
            else if (LetterIndex == 5)
            {
                LetterAudioScript.PlayAudioH();
            }
            else if (LetterIndex == 6)
            {
                LetterAudioScript.PlayAudioJ();
            }
            else if (LetterIndex == 7)
            {
                LetterAudioScript.PlayAudioK();
            }
            else if (LetterIndex == 8)
            {
                LetterAudioScript.PlayAudioL();
            }
            else if (LetterIndex == 9)
            {
                LetterAudioScript.PlayAudioM();
            }
            else if (LetterIndex == 10)
            {
                LetterAudioScript.PlayAudioN();
            }
            else if (LetterIndex == 11)
            {
                LetterAudioScript.PlayAudioP();
            }
            else if (LetterIndex == 12)
            {
                LetterAudioScript.PlayAudioQ();
            }
            else if (LetterIndex == 13)
            {
                LetterAudioScript.PlayAudioR();
            }
            else if (LetterIndex == 14)
            {
                LetterAudioScript.PlayAudioS();
            }
            else if (LetterIndex == 15)
            {
                LetterAudioScript.PlayAudioT();
            }
            else if (LetterIndex == 16)
            {
                LetterAudioScript.PlayAudioV();
            }
            else if (LetterIndex == 17)
            {
                LetterAudioScript.PlayAudioW();
            }
            else if (LetterIndex == 18)
            {
                LetterAudioScript.PlayAudioX();
            }
            else if (LetterIndex == 19)
            {
                LetterAudioScript.PlayAudioY();
            }
            else if (LetterIndex == 20)
            {
                LetterAudioScript.PlayAudioZ();
            }
        }
        else if(TileScript.LetterCounterInteger == 26)
        {
            if (LetterIndex == 0)
            {
                LetterAudioScript.PlayAudioA();
            }
            else if (LetterIndex == 1)
            {
                LetterAudioScript.PlayAudioB();
            }
            else if (LetterIndex == 2)
            {
                LetterAudioScript.PlayAudioC();
            }
            else if (LetterIndex == 3)
            {
                LetterAudioScript.PlayAudioD();
            }
            else if (LetterIndex == 4)
            {
                LetterAudioScript.PlayAudioE();
            }
            else if (LetterIndex == 5)
            {
                LetterAudioScript.PlayAudioF();
            }
            else if (LetterIndex == 6)
            {
                LetterAudioScript.PlayAudioG();
            }
            else if (LetterIndex == 7)
            {
                LetterAudioScript.PlayAudioH();
            }
            else if (LetterIndex == 8)
            {
                LetterAudioScript.PlayAudioI();
            }
            else if (LetterIndex == 9)
            {
                LetterAudioScript.PlayAudioJ();
            }
            else if (LetterIndex == 10)
            {
                LetterAudioScript.PlayAudioK();
            }
            else if (LetterIndex == 11)
            {
                LetterAudioScript.PlayAudioL();
            }
            else if (LetterIndex == 12)
            {
                LetterAudioScript.PlayAudioM();
            }
            else if (LetterIndex == 13)
            {
                LetterAudioScript.PlayAudioN();
            }
            else if (LetterIndex == 14)
            {
                LetterAudioScript.PlayAudioO();
            }
            else if (LetterIndex == 15)
            {
                LetterAudioScript.PlayAudioP();
            }
            else if (LetterIndex == 16)
            {
                LetterAudioScript.PlayAudioQ();
            }
            else if (LetterIndex == 17)
            {
                LetterAudioScript.PlayAudioR();
            }
            else if (LetterIndex == 18)
            {
                LetterAudioScript.PlayAudioS();
            }
            else if (LetterIndex == 19)
            {
                LetterAudioScript.PlayAudioT();
            }
            else if (LetterIndex == 20)
            {
                LetterAudioScript.PlayAudioU();
            }
            else if (LetterIndex == 21)
            {
                LetterAudioScript.PlayAudioV();
            }
            else if (LetterIndex == 22)
            {
                LetterAudioScript.PlayAudioW();
            }
            else if (LetterIndex == 23)
            {
                LetterAudioScript.PlayAudioX();
            }
            else if (LetterIndex == 24)
            {
                LetterAudioScript.PlayAudioY();
            }
            else if (LetterIndex == 25)
            {
                LetterAudioScript.PlayAudioZ();
            }
        }
    }
    
}
