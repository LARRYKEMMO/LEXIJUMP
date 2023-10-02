using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatteredScript : MonoBehaviour
{
    private SoundManagerScript SMScript;
    private int BtilesCounter = -1; 
    public bool TriggerOn = false;
    private EdgeCollider2D ED;
    private TileSpawn SpScript;
    // Start is called before the first frame update
    void Start()
    {
        SpScript = FindObjectOfType<TileSpawn>();
        SMScript = FindAnyObjectByType<SoundManagerScript>();
        //ED = gameObject.GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(TriggerOn == false)
        //{
        //    ED.isTrigger = false;
        //}
        //else if(TriggerOn == true)
        //{
        //    ED.isTrigger = true;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            SMScript.PlayShattered();
            BtilesCounter = SpScript.Btiles.IndexOf(gameObject);
            Debug.Log("INDEXXXXX: " + BtilesCounter);
            SpScript.Btiles.RemoveAt(BtilesCounter);
            Destroy(gameObject, 0.2f);
        }
    }
}
