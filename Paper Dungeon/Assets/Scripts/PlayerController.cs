using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float playerSpeed;

    public bool InCombat = false;

    Transform playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("e"))
        {
            interact();
        }
        else if (Input.GetButton("w"))
        {
            MoveUp();
        }
        else if (Input.GetButton("a"))
        {
            MoveLeft();
        }
        else if (Input.GetButton("s"))
        {
            MoveDown();
        }
        else if (Input.GetButton("d"))
        {
            MoveRight();
        }
        
    }


    private void MoveUp()
    {
        playerPosition.position = new Vector3(playerPosition.position.x, playerPosition.position.y + playerSpeed, playerPosition.position.z);
    }

    private void MoveDown()
    {
        playerPosition.position = new Vector3(playerPosition.position.x, playerPosition.position.y + -playerSpeed, playerPosition.position.z);
    }

    private void MoveLeft()
    {
        playerPosition.position = new Vector3(playerPosition.position.x + -playerSpeed, playerPosition.position.y, playerPosition.position.z);
    }

    private void MoveRight()
    {
        playerPosition.position = new Vector3(playerPosition.position.x + playerSpeed, playerPosition.position.y, playerPosition.position.z);
    }

    private bool interact()
    {
        return true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            InCombat = true;
            Debug.Log("Combat Engaged!");
        }
    }
}
