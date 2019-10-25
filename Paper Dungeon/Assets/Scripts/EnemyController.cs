﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : UnitMoveI
{
    [SerializeField]
    private GameObject LeftBorder, RightBorder, TopBorder, BottomBorder;
    [SerializeField]
    private Sprite Grey, Yellow, Red;

    private SpriteRenderer slimeRenderer;
    private Animator slimeAnimator;
    private Mob_Stats stats;

    private int Direction;
    private bool CanLeft, CanRight, CanUp, CanDown;

    private void Awake()
    {
        slimeAnimator = this.GetComponent<Animator>();
        stats = this.GetComponent<Mob_Stats>();
        SetAnimation();
        InvokeRepeating("Execute", 0, 0.5f);
    }

    private void SetAnimation()
    {
        if (stats.StatReturn()[2] > 4)
        {
            slimeAnimator.SetBool("Is_Red", true);
        }
        else if (stats.StatReturn()[4] > 4)
        {
            slimeAnimator.SetBool("Is_Yellow", true);
        }
        else
        {
            slimeAnimator.SetBool("Is_Gray", true);
        }
    }

    private void Update()
    {
        CanLeft = LeftBorder.GetComponent<EnemyTrigger>().isActive;
        CanRight = RightBorder.GetComponent<EnemyTrigger>().isActive;
        CanUp = TopBorder.GetComponent<EnemyTrigger>().isActive;
        CanDown = BottomBorder.GetComponent<EnemyTrigger>().isActive;
        Direction = UnityEngine.Random.Range(0,4);
    }
    protected override void Execute()
    {
        switch(Direction)
        {
            case 0:
                if(CanUp)
                {
                    MoveUp();
                }
                break;
            case 1:
                if(CanDown)
                {
                    MoveDown();
                }
                break;
            case 2:
                if(CanLeft)
                {
                    MoveLeft();
                }
                break;
            case 3:
                if(CanRight)
                {
                    MoveRight();
                }
                break;
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
}
