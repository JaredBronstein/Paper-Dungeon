using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
