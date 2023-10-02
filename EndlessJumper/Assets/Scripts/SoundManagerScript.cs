using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    private AudioSource AudioBag;
    public AudioClip Boing;
    public AudioClip TileBroken;
    public AudioClip Speed;
    public AudioClip Boost;
    public AudioClip Vortex;
    // Start is called before the first frame update
    void Start()
    {
        AudioBag = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBoing()
    {
        AudioBag.clip = Boing;
        AudioBag.Play();    
    }

    public void PlayShattered()
    {
        AudioBag.clip = TileBroken;
        AudioBag.Play();
    }

    public void PlaySpeed()
    {
        AudioBag.clip = Speed;
        AudioBag.Play();
    }

    public void PlayBoost()
    {
        AudioBag.clip = Boost;
        AudioBag.Play();
    }

    public void StopBoost()
    {
        AudioBag.Stop();
    }

    public void PlayVortex()
    {
        AudioBag.clip = Vortex;
        AudioBag.Play();
    }

}
