using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TileSpawn : MonoBehaviour
{
    private StarScript starScript;

    public GameObject TilePrefab;
    private GameObject Tile;

    public GameObject SpeedPrefab;
    private GameObject Boost;
    private Vector3 SpeedPosition;

    private GameObject BrokenTile;
    public GameObject BrokenPrefab;

    public GameObject FlagPrefab;
    private GameObject Flag;

    private GameObject MainPrefab; 
    public GameObject APrefab;
    public GameObject BPrefab;
    public GameObject CPrefab;
    public GameObject DPrefab;
    public GameObject EPrefab;
    public GameObject FPrefab;
    public GameObject GPrefab;
    public GameObject HPrefab;
    public GameObject IPrefab;
    public GameObject JPrefab;
    public GameObject KPrefab;
    public GameObject LPrefab;
    public GameObject MPrefab;
    public GameObject NPrefab;
    public GameObject OPrefab;
    public GameObject PPrefab;
    public GameObject QPrefab;
    public GameObject RPrefab;
    public GameObject SPrefab;
    public GameObject TPrefab;
    public GameObject UPrefab;
    public GameObject VPrefab;
    public GameObject WPrefab;
    public GameObject XPrefab;
    public GameObject YPrefab;
    public GameObject ZPrefab;

    private GameObject Letter;
    public int LetterCounter = 0;
    public int LetterCounterInteger = 0;
    public int LCounter;
    public Text LetterBag;
    public int SpeedCounter = 0;
    public GameObject Collider3;
    private List<GameObject> tiles = new List<GameObject>();
    public List<GameObject> Btiles = new List<GameObject>();
    public List<GameObject> Letters = new List<GameObject>();
    public List<int> Indexes = new List<int>();
    private Vector3 OriginalPosition;
    private float OriginalY = -2.0f;
    private float OriginalX = 0f;
    private string TargetSceneName;
    private Scene CurrentScene;
    private int PowerUpIndex;
    public float TimeScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        starScript = FindAnyObjectByType<StarScript>();
        CurrentScene = SceneManager.GetActiveScene();
        TargetSceneName = CurrentScene.name;
        //Debug.Log("TargetSceneName: " + TargetSceneName);
        OriginalPosition = new Vector3 (OriginalX, OriginalY, 0f);
        if(TargetSceneName == "Level3")
        {
            for (int j = 0; j < 7; j++)
            {
                PowerUpIndex = Random.Range(9, 450);
                Indexes.Add(PowerUpIndex);
                //Debug.Log("////////Index Size: " + Indexes.Count + "//////////////////");
            }

            Indexes.Sort();

            for (int i = 0; i < 530; i++)
            {
                // Debug.Log("For Loop Index: " + i);
                OriginalPosition += new Vector3(Random.Range(-19f, -16f), 3f, 0f);

                if (i.Equals(Indexes[SpeedCounter]))
                {
                    SpeedPosition = new Vector3(OriginalPosition.x, OriginalPosition.y + 0.3f, OriginalPosition.z);
                    Boost = Instantiate(SpeedPrefab, SpeedPosition, Quaternion.identity);
                    //Debug.Log("SpeedCounter//////////////////: " + SpeedCounter);
                    if (SpeedCounter < 6)
                    {
                        SpeedCounter++;
                    }

                    //Indexes.RemoveAt(0);
                }

                if (i == 0)
                {
                    Tile = Instantiate(TilePrefab, OriginalPosition, Quaternion.identity);
                   
                }
                
                if(i % 20 != 0 && i != 0)
                {
                    Tile = Instantiate(TilePrefab, OriginalPosition, Quaternion.identity);
                }
                if (i % 20 == 0 && i != 0)
                {
                    BrokenTile = Instantiate(BrokenPrefab, OriginalPosition, Quaternion.identity);
                    Btiles.Add(BrokenTile);
                    LetterCounter++;
                    OriginalPosition = new Vector3(OriginalPosition.x, OriginalPosition.y + 0.3f, OriginalPosition.z);
                    DetLetter(LetterCounter);
                    Letter = Instantiate(MainPrefab, OriginalPosition, Quaternion.identity);
                    Letters.Add(Letter);
                }

                if (i == 524)
                {
                    OriginalPosition = new Vector3(OriginalPosition.x, OriginalPosition.y + 0.5f, OriginalPosition.z);
                    Flag = Instantiate(FlagPrefab, OriginalPosition, Quaternion.identity);

                }

                tiles.Add(Tile);
                OriginalPosition.x = 0;
                OriginalPosition.y -= 0.3f;
            }
        }
        else if(TargetSceneName == "Level2")
        {
            for(int j = 0; j < 5; j++)
            {
                PowerUpIndex = Random.Range(9, 400);
                Indexes.Add(PowerUpIndex);
                //Debug.Log("////////Index Size: " + Indexes.Count + "//////////////////");
            }

            Indexes.Sort();
            //for (int p = 0; p < 5; p++)
            //{
            //    Debug.Log(Indexes[p]);
            //}

            for (int i = 0; i < 430; i++)
            {
                // Debug.Log("For Loop Index: " + i);
                OriginalPosition += new Vector3(Random.Range(-19f, -16f), 3f, 0f);

                if (i.Equals(Indexes[SpeedCounter]))
                {
                    SpeedPosition = new Vector3(OriginalPosition.x, OriginalPosition.y + 0.3f, OriginalPosition.z);
                    Boost = Instantiate(SpeedPrefab, SpeedPosition, Quaternion.identity);
                    //Debug.Log("SpeedCounter//////////////////: " + SpeedCounter);
                    if(SpeedCounter < 4)
                    {
                        SpeedCounter ++;
                    }
                    
                    //Indexes.RemoveAt(0);
                }

                if (i == 0)
                {
                    Tile = Instantiate(TilePrefab, OriginalPosition, Quaternion.identity);
                }

                if (i % 20 != 0 && i != 0)
                {
                    Tile = Instantiate(TilePrefab, OriginalPosition, Quaternion.identity);
                }
                if (i % 20 == 0 && i != 0)
                {
                    BrokenTile = Instantiate(BrokenPrefab, OriginalPosition, Quaternion.identity);
                    Btiles.Add(BrokenTile);
                    LetterCounter++;
                    OriginalPosition = new Vector3(OriginalPosition.x, OriginalPosition.y + 0.3f, OriginalPosition.z);
                    DetLetter2(LetterCounter);
                    Letter = Instantiate(MainPrefab, OriginalPosition, Quaternion.identity);
                    Letters.Add(Letter);
                }

                if (i == 424)
                {
                    OriginalPosition = new Vector3(OriginalPosition.x, OriginalPosition.y + 0.5f, OriginalPosition.z);
                    Flag = Instantiate(FlagPrefab, OriginalPosition, Quaternion.identity);

                }

                tiles.Add(Tile);
                OriginalPosition.x = 0;
                OriginalPosition.y -= 0.3f;
            }
        }
        else if(TargetSceneName == "Level1")
        {
            for (int j = 0; j < 2; j++)
            {
                PowerUpIndex = Random.Range(9, 80);
                Indexes.Add(PowerUpIndex);
                //Debug.Log("////////Index Size: " + Indexes.Count + "//////////////////");
            }

            Indexes.Sort();
            //Debug.Log("Index Size: " + Indexes.Count);

            for (int i = 0; i < 110; i++)
            {
                // Debug.Log("For Loop Index: " + i);
                OriginalPosition += new Vector3(Random.Range(-19f, -16f), 3f, 0f);
                if (i.Equals(Indexes[SpeedCounter]))
                {
                    SpeedPosition = new Vector3(OriginalPosition.x, OriginalPosition.y + 0.3f, OriginalPosition.z);
                    Boost = Instantiate(SpeedPrefab, SpeedPosition, Quaternion.identity);
                    //Debug.Log("SpeedCounter//////////////////: " + SpeedCounter);
                    if (SpeedCounter < 1)
                    {
                        SpeedCounter++;
                    }

                    //Indexes.RemoveAt(0);
                }

                if (i == 0)
                {
                    Tile = Instantiate(TilePrefab, OriginalPosition, Quaternion.identity);
                    //SpeedPosition = new Vector3(OriginalPosition.x, OriginalPosition.y + 0.3f, OriginalPosition.z);
                    //Boost = Instantiate(SpeedPrefab, SpeedPosition, Quaternion.identity);
                }

                if (i % 20 != 0 && i != 0)
                {
                    Tile = Instantiate(TilePrefab, OriginalPosition, Quaternion.identity);
                }
                if (i % 20 == 0 && i != 0)
                {
                    BrokenTile = Instantiate(BrokenPrefab, OriginalPosition, Quaternion.identity);
                    Btiles.Add(BrokenTile);
                    LetterCounter++;
                    OriginalPosition = new Vector3(OriginalPosition.x, OriginalPosition.y + 0.3f, OriginalPosition.z);
                    DetLetter1(LetterCounter);
                    Letter = Instantiate(MainPrefab, OriginalPosition, Quaternion.identity);
                    Letters.Add(Letter);
                }

                if (i == 104)
                {
                    OriginalPosition = new Vector3(OriginalPosition.x, OriginalPosition.y + 0.5f, OriginalPosition.z);
                    Flag = Instantiate(FlagPrefab, OriginalPosition, Quaternion.identity);

                }

                tiles.Add(Tile);
                OriginalPosition.x = 0;
                OriginalPosition.y -= 0.3f;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeScore += 0.001f;

        if (TargetSceneName == "Level1")
        {
            LetterCounterInteger = 5;
            LCounter = (LetterCounterInteger - LetterCounter);
            LetterBag.text = "Letter Bag: " + LCounter.ToString();
            //SScript.Score = LetterCounterInteger - LetterCounter;
        }
        else if(TargetSceneName == "Level2")
        {
            LetterCounterInteger = 21;
            LetterBag.text = "Letter Bag: " + (LetterCounterInteger - LetterCounter).ToString();
            //SScript.Score = LetterCounterInteger - LetterCounter;
        }
        else if(TargetSceneName == "Level3")
        {
            LetterCounterInteger = 26;
            LetterBag.text = "Letter Bag: " + (LetterCounterInteger - LetterCounter).ToString();
            //SScript.Score = LetterCounterInteger - LetterCounter;
        }
        //StartCoroutine(DeleteTile());
        //Debug.Log("B Size: " + Btiles.Count);
        //Debug.Log("Letters Size: " + LetterCounter);
    }

    private void DetLetter(int Index)
    {
        if(Index == 1)
        {
            MainPrefab = APrefab;
        }
        else if(Index == 2)
        {
            MainPrefab = BPrefab;
        }
        else if (Index == 3)
        {
            MainPrefab = CPrefab;
        }
        else if (Index == 4)
        {
            MainPrefab = DPrefab;
        }
        else if (Index == 5)
        {
            MainPrefab = EPrefab;
        }
        else if (Index == 6)
        {
            MainPrefab = FPrefab;
        }
        else if (Index == 7)
        {
            MainPrefab = GPrefab;
        }
        else if (Index == 8)
        {
            MainPrefab = HPrefab;
        }
        else if (Index == 9)
        {
            MainPrefab = IPrefab;
        }
        else if (Index == 10)
        {
            MainPrefab = JPrefab;
        }
        else if (Index == 11)
        {
            MainPrefab = KPrefab;
        }
        else if (Index == 12)
        {
            MainPrefab = LPrefab;
        }
        else if (Index == 13)
        {
            MainPrefab = MPrefab;
        }
        else if (Index == 14)
        {
            MainPrefab = NPrefab;
        }
        else if (Index == 15)
        {
            MainPrefab = OPrefab;
        }
        else if (Index == 16)
        {
            MainPrefab = PPrefab;
        }
        else if (Index == 17)
        {
            MainPrefab = QPrefab;
        }
        else if (Index == 18)
        {
            MainPrefab = RPrefab;
        }
        else if (Index == 19)
        {
            MainPrefab = SPrefab;
        }
        else if (Index == 20)
        {
            MainPrefab = TPrefab;
        }
        else if (Index == 21)
        {
            MainPrefab = UPrefab;
        }
        else if (Index == 22)
        {
            MainPrefab = VPrefab;
        }
        else if (Index == 23)
        {
            MainPrefab = WPrefab;
        }
        else if (Index == 24)
        {
            MainPrefab = XPrefab;
        }
        else if (Index == 25)
        {
            MainPrefab = YPrefab;
        }
        else if (Index == 26)
        {
            MainPrefab = ZPrefab;
        }
    }

    private void DetLetter2(int Index)
    {
        if (Index == 1)
        {
            MainPrefab = BPrefab;
        }
        else if (Index == 2)
        {
            MainPrefab = CPrefab;
        }
        else if (Index == 3)
        {
            MainPrefab = DPrefab;
        }
        else if (Index == 4)
        {
            MainPrefab = FPrefab;
        }
        else if (Index == 5)
        {
            MainPrefab = GPrefab;
        }
        else if (Index == 6)
        {
            MainPrefab = HPrefab;
        }
        else if (Index == 7)
        {
            MainPrefab = JPrefab;
        }
        else if (Index == 8)
        {
            MainPrefab = KPrefab;
        }
        else if (Index == 9)
        {
            MainPrefab = LPrefab;
        }
        else if (Index == 10)
        {
            MainPrefab = MPrefab;
        }
        else if (Index == 11)
        {
            MainPrefab = NPrefab;
        }
        else if (Index == 12)
        {
            MainPrefab = PPrefab;
        }
        else if (Index == 13)
        {
            MainPrefab = QPrefab;
        }
        else if (Index == 14)
        {
            MainPrefab = RPrefab;
        }
        else if (Index == 15)
        {
            MainPrefab = SPrefab;
        }
        else if (Index == 16)
        {
            MainPrefab = TPrefab;
        }
        else if (Index == 17)
        {
            MainPrefab = VPrefab;
        }
        else if (Index == 18)
        {
            MainPrefab = WPrefab;
        }
        else if (Index == 19)
        {
            MainPrefab = XPrefab;
        }
        else if (Index == 20)
        {
            MainPrefab = YPrefab;
        }
        else if (Index == 21)
        {
            MainPrefab = ZPrefab;
        }
    }


    private void DetLetter1(int Index)
    {
        if (Index == 1)
        {
            MainPrefab = APrefab;
        }
        else if (Index == 2)
        {
            MainPrefab = EPrefab;
        }
        else if (Index == 3)
        {
            MainPrefab = IPrefab;
        }
        else if (Index == 4)
        {
            MainPrefab = OPrefab;
        }
        else if (Index == 5)
        {
            MainPrefab = UPrefab;
        }
        
    }


    private IEnumerator DeleteTile()
    {
        //Debug.Log("Coroutine started");
        //Debug.Log("Coroutine resumed after 2 seconds");
        if (tiles[4].transform.position.y < Collider3.transform.position.y)
        {
            Destroy(tiles[4]);
            tiles.RemoveAt(4);
            Destroy(tiles[3]);
            tiles.RemoveAt(3);
            Destroy(tiles[2]);
            tiles.RemoveAt(2);
            Destroy(tiles[1]);
            tiles.RemoveAt(1);
            Destroy(tiles[0]);
            tiles.RemoveAt(0);
            //Debug.Log("Tiles: " + tiles.Count);
        }
        else
        {
            //Debug.Log("Tiles: " + tiles.Count);
        }
        yield return new WaitForSeconds(2f);
    }

    public void TriggerTiles()
    {
        for(int i = 0; i < tiles.Count; i++)
        {
            tiles[i].GetComponent<EdgeCollider2D>().isTrigger = true;
        }

        for (int i = 0; i < Btiles.Count; i++)
        {
            Btiles[i].GetComponent<EdgeCollider2D>().isTrigger = true;
        }
    }

    public void UnTriggerTiles()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            tiles[i].GetComponent<EdgeCollider2D>().isTrigger = false;
        }

        for (int i = 0; i < Btiles.Count; i++)
        {
            Btiles[i].GetComponent<EdgeCollider2D>().isTrigger = false;
        }
    }

    public void DeleteLetter()
    {
        starScript.DisplayStars();
        starScript.PlayTwinkle();
        LetterCounter --;
    }
}
