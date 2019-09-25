using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMoveI : MonoBehaviour
{
    [SerializeField]
    public float characterSpeed;

    public Transform characterPosition;

    public UnitMoveI()
    {
    }
    public virtual void Execute()
    {
    }
}

class MoveUp : UnitMoveI
{
    public override void Execute() { MoveUpwards(); }

    void MoveUpwards()
    {
        characterPosition.position = new Vector3(characterPosition.position.x, characterPosition.position.y + characterSpeed, characterPosition.position.z);
    }
}

class Moveleft : UnitMoveI
{
    public override void Execute() { MoveLeftwards(); }

    private void MoveLeftwards()
    {
        characterPosition.position = new Vector3(characterPosition.position.x + -characterSpeed, characterPosition.position.y, characterPosition.position.z);
    }
}

class Movedown : UnitMoveI
{
    public override void Execute() { MoveDownwards(); }

    private void MoveDownwards()
    {
        characterPosition.position = new Vector3(characterPosition.position.x, characterPosition.position.y + -characterSpeed, characterPosition.position.z);
    }
}

class Moveright : UnitMoveI
{
    public override void Execute() { MoveRightwards(); }

    private void MoveRightwards()
    {
        characterPosition.position = new Vector3(characterPosition.position.x + characterSpeed, characterPosition.position.y, characterPosition.position.z);
    }
}
