using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    double playerSpeed;

    Transform playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveUp()
    {
       // playerPosition.position.y += playerSpeed;
    }

    void MoveDown()
    {

    }

    void MoveLeft()
    {

    }

    void MoveRight()
    {

    }

    void Interact()
    {

    }

    void StartCombat(){ 
    
    }

}
