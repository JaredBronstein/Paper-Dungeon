using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : UnitMoveI
{

    public bool InCombat = false;
    public GameObject Opponent;

    // Update is called once per frame
    void Update()
    {
        Execute();
    }


    protected override void Execute()
    {
        if(!InCombat)
        {
            if (Input.GetButton("w")) MoveUp();
            else if (Input.GetButton("a")) MoveLeft();
            else if (Input.GetButton("s")) MoveDown();
            else if (Input.GetButton("d")) MoveRight();
        }
    }

    protected override void MoveUp()
    {
        characterPosition.position = new Vector3(characterPosition.position.x, characterPosition.position.y + characterSpeed, characterPosition.position.z);

    }
    protected override void MoveDown()
    {
        characterPosition.position = new Vector3(characterPosition.position.x, characterPosition.position.y + -characterSpeed, characterPosition.position.z);

    }
    protected override void MoveLeft()
    {
        characterPosition.position = new Vector3(characterPosition.position.x + -characterSpeed, characterPosition.position.y, characterPosition.position.z);

    }
    protected override void MoveRight()
    {
        characterPosition.position = new Vector3(characterPosition.position.x + characterSpeed, characterPosition.position.y, characterPosition.position.z);

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Opponent = collision.gameObject;
            InCombat = true;
        }
    }
}
