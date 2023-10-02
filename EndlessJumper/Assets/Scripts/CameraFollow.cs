using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    private Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Player.position.y > gameObject.transform.position.y)
        {
            newPosition = new Vector3(gameObject.transform.position.x, Player.position.y, gameObject.transform.position.z);
            gameObject.transform.position = newPosition;    
        }
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;
        while(elapsed < duration)
        {
            float x = Random.Range(-0.01f, 0.01f) * magnitude;
            //float y = Random.Range(-0.05f, 0.05f) * magnitude;
            //Debug.Log("Value X: " + x / magnitude);
            transform.localPosition = new Vector3(x, originalPos.y, originalPos.z);
            elapsed += Time.deltaTime;
            
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
