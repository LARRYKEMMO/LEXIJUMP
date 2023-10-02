using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour
{
    private int Index;
    private Animator animator;
    public GameObject LazerLeft;
    public GameObject LazerRight;
    public GameObject LazerCenter;
    public CameraFollow CameraFollowScript;
    private AudioSource ThunderClip;
    // Start is called before the first frame update
    void Start()
    {
        ThunderClip = GetComponent<AudioSource>();
        Invoke("Activate", 20f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Activate()
    {
        Index = Random.Range(1, 4);
        if(Index == 1)
        {
            animator = LazerLeft.GetComponent<Animator>();
            animator.SetBool("On", true);
            Invoke("DeActivate", 1.5f);
        }
        else if (Index == 2)
        {
            animator = LazerCenter.GetComponent<Animator>();
            animator.SetBool("On", true);
            Invoke("DeActivate", 1.5f);
        }
        else if (Index == 3)
        {
            animator = LazerRight.GetComponent<Animator>();
            animator.SetBool("On", true);
            Invoke("DeActivate", 1.5f);
        }
    }

    private void DeActivate()
    {
        animator.SetBool("On", false);
        Invoke("CallScreenShake", 1f);
        Invoke("Activate", 20f);
    }

    private void CallScreenShake()
    {
        ThunderClip.Play();
        StartCoroutine(CameraFollowScript.Shake(0.7f, 3f));

    }
}
