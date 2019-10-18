using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public bool isActive = true;
    [SerializeField]
    private GameObject Trigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Trigger)
        {
            isActive = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Trigger)
        {
            isActive = true;
        }
    }
}
