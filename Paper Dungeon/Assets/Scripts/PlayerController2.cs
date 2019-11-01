using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//made by jonathan way, updated by jared bronstein for combat script purposes
//simple code to allow the player to move around and interact with objects
public class PlayerController2 : UnitMoveI
{
    public bool InCombat = false;

    public GameObject Opponent;
    public GameObject CombatController;

    private Animator animator;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Execute();
    }

    //checks if the player has put any input into the input system (project settings only has keyboard input set up for now)
    protected override void Execute()
    {
        if(!InCombat)
        {
            if (Input.GetButton("w")) MoveUp();
            else if (Input.GetButton("a")) MoveLeft();
            else if (Input.GetButton("s")) MoveDown();
            else if (Input.GetButton("d")) MoveRight();
            else
            {
                //animation parameters to go along with the actual movement
                animator.SetBool("Is_Moving", false);
                animator.SetBool("Move_Up", false);
                animator.SetBool("Move_Down", false);
                animator.SetBool("Move_Left", false);
                animator.SetBool("Move_Right", false);
            }
        }
    }

    //these tell the animator which animation to play depending on the characters direction
    protected override void MoveUp()
    {
        characterPosition.position = new Vector3(characterPosition.position.x, characterPosition.position.y + characterSpeed, characterPosition.position.z);
        animator.SetBool("Is_Moving", true);
        animator.SetBool("Move_Up", true);
        animator.SetBool("Move_Down", false);
        animator.SetBool("Move_Left", false);
        animator.SetBool("Move_Right", false);
    }
    protected override void MoveDown()
    {
        characterPosition.position = new Vector3(characterPosition.position.x, characterPosition.position.y + -characterSpeed, characterPosition.position.z);
        animator.SetBool("Is_Moving", true);
        animator.SetBool("Move_Down", true);
        animator.SetBool("Move_Up", false);
        animator.SetBool("Move_Left", false);
        animator.SetBool("Move_Right", false);
    }
    protected override void MoveLeft()
    {
        characterPosition.position = new Vector3(characterPosition.position.x + -characterSpeed, characterPosition.position.y, characterPosition.position.z);
        animator.SetBool("Is_Moving", true);
        animator.SetBool("Move_Left", true);
        animator.SetBool("Move_Down", false);
        animator.SetBool("Move_Up", false);
        animator.SetBool("Move_Right", false);
    }
    protected override void MoveRight()
    {
        characterPosition.position = new Vector3(characterPosition.position.x + characterSpeed, characterPosition.position.y, characterPosition.position.z);

        animator.SetBool("Is_Moving", true);
        animator.SetBool("Move_Right", true);
        animator.SetBool("Move_Down", false);
        animator.SetBool("Move_Left", false);
        animator.SetBool("Move_Up", false);

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Opponent = collision.gameObject;
            InCombat = true;
            CombatController.gameObject.SetActive(true);
        }
    }
}
