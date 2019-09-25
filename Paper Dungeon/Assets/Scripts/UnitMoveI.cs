using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
