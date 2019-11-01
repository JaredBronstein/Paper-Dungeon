using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonSoundCode : MonoBehaviour
{
    [SerializeField]
    AudioSource buttonNoise;

    // Start is called before the first frame update
    void Start()
    {
        buttonNoise.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayTheSound()
    {
        buttonNoise.Play();
    }
}
