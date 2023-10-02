using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDDL : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);
        
    }

    //public void DestroyAudioMenu()
    //{
    //    DestroyImmediate(this.gameObject);
    //}
}
