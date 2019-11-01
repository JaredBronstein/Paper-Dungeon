using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//made by jonathan way
//simple code on every lever that lets the player turn it on or off, if anything needs to know the state of a lever it should reference that levers version of this code
public class LeverActivate : MonoBehaviour
{
    public bool leverActivated;

    [SerializeField]
    GameObject buttonPrompt;

    AudioSource leverNoise;

    // Start is called before the first frame update
    void Start()
    {
        leverActivated = false;
        buttonPrompt.SetActive(false);
        leverNoise = this.GetComponent<AudioSource>();
    } 

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            buttonPrompt.SetActive(true);
            if (Input.GetButtonDown("Activate"))
            {
                leverNoise.Play();
                if (leverActivated == false)
                {
                    leverActivated = true;
                }
                else
                {
                    leverActivated = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            buttonPrompt.SetActive(false);
        }
    }
}
