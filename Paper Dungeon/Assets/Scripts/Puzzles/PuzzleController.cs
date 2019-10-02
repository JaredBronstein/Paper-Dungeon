using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{


    //These booleans are checking to see what moves the player has already made.

    public int moveup;
    public int movedown;
    public int moveright;
    public int moveleft;

    public GameObject Up1;
    public GameObject Up2;
    public GameObject Up3;
    public GameObject Up4;
    
    public GameObject Down1;
    public GameObject Down2;
    public GameObject Down3;

    public GameObject Left1;
    public GameObject Left2;
    public GameObject Left3;

    public GameObject Right1;
    public GameObject Right2;
    public GameObject Right3;
    public GameObject Right4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    //This is a temporary method to test the movement of the pieces.
    public void PlayerInput()
    {
        Upward();
        Downward();
        LeftMove();
        RightMove();
    }

    public void Upward()
    {
        if (Input.GetKeyDown("w"))
        {

                Up1.transform.Translate(0, moveup, 0);
                Up2.transform.Translate(0, moveup, 0);
                Up3.transform.Translate(0, moveup, 0);
                Up4.transform.Translate(0, moveup, 0);
 
        }

        if (Input.GetKeyUp("w"))
        {

            Up1.transform.Translate(0, -moveup, 0);
            Up2.transform.Translate(0, -moveup, 0);
            Up3.transform.Translate(0, -moveup, 0);
            Up4.transform.Translate(0, -moveup, 0);
        }
    }

    public void Downward()
    {
        if (Input.GetKeyDown("s"))
        {

            Down1.transform.Translate(0, movedown, 0);
            Down2.transform.Translate(0, movedown, 0);
            Down3.transform.Translate(0, movedown, 0);


        }

        if (Input.GetKeyUp("s"))
        {

            Down1.transform.Translate(0, -movedown, 0);
            Down2.transform.Translate(0, -movedown, 0);
            Down3.transform.Translate(0, -movedown, 0);

        }
    }

    public void LeftMove()
    {
        if (Input.GetKeyDown("a"))
        {

            Left1.transform.Translate(moveleft, 0, 0);
            Left2.transform.Translate(moveleft, 0, 0);
            Left3.transform.Translate(moveleft, 0, 0);


        }

        if (Input.GetKeyUp("a"))
        {

            Left1.transform.Translate(-moveleft, 0, 0);
            Left2.transform.Translate(-moveleft, 0, 0);
            Left3.transform.Translate(-moveleft, 0, 0);

        }
    }

    public void RightMove()
    {
        if (Input.GetKeyDown("d"))
        {

            Right1.transform.Translate(moveright, 0, 0);
            Right2.transform.Translate(moveright, 0, 0);
            Right3.transform.Translate(moveright, 0, 0);
            Right4.transform.Translate(moveright, 0, 0);

        }

        if (Input.GetKeyUp("d"))
        {

            Right1.transform.Translate(-moveright, 0, 0);
            Right2.transform.Translate(-moveright, 0, 0);
            Right3.transform.Translate(-moveright, 0, 0);
            Right4.transform.Translate(-moveright, 0, 0);
        }
    }
}
