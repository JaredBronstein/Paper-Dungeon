using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private MoveUp upButton_;
    private Movedown downButton_;
    private Moveleft leftButton_;
    private Moveright rightButton_;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("w")) upButton_.Execute();
        else if (Input.GetButton("a")) leftButton_.Execute();
        else if (Input.GetButton("s")) downButton_.Execute();
        else if (Input.GetButton("d")) rightButton_.Execute();
    }
}
