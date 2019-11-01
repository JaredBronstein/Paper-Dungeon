using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//made by jonathan way
// simple template for anything that moves in the game, can be used by enemy AI or the player controller
public class UnitMoveI : MonoBehaviour
{
    [SerializeField]
    protected float characterSpeed;

    [SerializeField]
    protected Transform characterPosition;


    public UnitMoveI(){ }
    protected virtual void Execute(){ }
    protected virtual void MoveUp() { }
    protected virtual void MoveDown() { }
    protected virtual void MoveLeft() { }
    protected virtual void MoveRight() { }

}
