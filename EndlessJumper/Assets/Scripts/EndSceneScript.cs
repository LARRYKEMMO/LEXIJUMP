using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneScript : MonoBehaviour
{
    private Vector3 OriginalPos;
    private string FinalText = "Congratulations for completing all levels of LEXI JUMP !!!, You now unlocked the ability to play any level of the game at your convinience. ENJOY !!!";
    private int LoopCounter = 0;
    private string TempText = "";
    private char[] characterList;
    public Text DisplayText;
    public GameObject MenuButton;
    // Start is called before the first frame update
    void Start()
    {
        OriginalPos = gameObject.transform.position;
        characterList = FinalText.ToCharArray();
        //Debug.Log("char Length: " + characterList.Length);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(-0.1f, 0, 0);
        if(gameObject.transform.position.x <= -14f)
        {
            gameObject.transform.position = OriginalPos;
        }

        Invoke("DisplayTextNow", 1.5f);
    }

    private void DisplayTextNow()
    {
        if(LoopCounter < characterList.Length - 1)
        {
            TempText += characterList[LoopCounter];
            DisplayText.text = TempText;
            LoopCounter++;
        }
        else
        {
            MenuButton.SetActive(true);
        }
    }
}
