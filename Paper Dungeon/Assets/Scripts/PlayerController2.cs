using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                animator.SetBool("Is_Moving", false);
                animator.SetBool("Move_Up", false);
                animator.SetBool("Move_Down", false);
                animator.SetBool("Move_Left", false);
                animator.SetBool("Move_Right", false);
            }
        }
    }

    protected override void MoveUp()
    {
        characterPosition.position = new Vector3(characterPosition.position.x, characterPosition.position.y + characterSpeed, characterPosition.position.z);
        animator.SetBool("Is_Moving", true);
        animator.SetBool("Move_Up", true);
    }
    protected override void MoveDown()
    {
        characterPosition.position = new Vector3(characterPosition.position.x, characterPosition.position.y + -characterSpeed, characterPosition.position.z);
        animator.SetBool("Is_Moving", true);
        animator.SetBool("Move_Down", true);
    }
    protected override void MoveLeft()
    {
        characterPosition.position = new Vector3(characterPosition.position.x + -characterSpeed, characterPosition.position.y, characterPosition.position.z);
        animator.SetBool("Is_Moving", true);
        animator.SetBool("Move_Left", true);
    }
    protected override void MoveRight()
    {
        characterPosition.position = new Vector3(characterPosition.position.x + characterSpeed, characterPosition.position.y, characterPosition.position.z);

        animator.SetBool("Is_Moving", true);
        animator.SetBool("Move_Right", true);

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
