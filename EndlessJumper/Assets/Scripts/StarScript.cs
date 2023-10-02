using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public int numberOfObjects = 10;
    public GameObject StarPrefab;
    public Vector3 letterPosition;
    private GameObject Star;
    private List<GameObject> Stars;
    private float radius = 0.5f;
    private float moveSpeed = 0.5f;
    private AudioSource Twinkle;
    // Start is called before the first frame update
    void Start()
    {
        Twinkle = GetComponent<AudioSource>();
        Stars = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayStars()
    {
        float angleIncrement = 360f / numberOfObjects;

        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * angleIncrement;
            Vector2 spawnPosition = GetCirclePosition(angle);
            Star = Instantiate(StarPrefab, spawnPosition, Quaternion.identity);
            Stars.Add(Star);
            SetMovementDirection(Star, angle);
            Destroy(Stars[i], 5f);
        }
    }


    private Vector2 GetCirclePosition(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float x = letterPosition.x + radius * Mathf.Cos(radian);
        float y = letterPosition.y + radius * Mathf.Sin(radian);
        return new Vector2(x, y);
    }

    private void SetMovementDirection(GameObject obj, float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float dirX = Mathf.Cos(radian);
        float dirY = Mathf.Sin(radian);
        Vector2 direction = new Vector2(dirX, dirY);
        obj.GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
    }

    public void PlayTwinkle()
    {
        Twinkle.Play();
    }
}
