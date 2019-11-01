using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//made by jonathan way
//simple code on every lever that lets the player turn it on or off, if anything needs to know the state of a lever it should reference that levers version of this code
public class LeverActivate : MonoBehaviour
{
    public bool leverActivated;

    // Start is called before the first frame update
    void Start()
    {
        leverActivated = false;
    } 

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            if (Input.GetButtonDown("Activate"))
            {
                if (leverActivated == false)
                {
                    Debug.Log("Player activates lever");
                    leverActivated = true;
                }
                else
                {
                    Debug.Log("Player turns off lever");
                    leverActivated = false;
                }
            }
        }
    }
}
