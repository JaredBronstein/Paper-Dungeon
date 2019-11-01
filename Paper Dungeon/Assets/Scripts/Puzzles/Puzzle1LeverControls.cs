using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// made by Jonathan way
// all of the Puzzle(number here)LeverControls that I made follow the same pattern
public class Puzzle1LeverControls : ILeverPuzzles
{

    //takes in all the states that the puzzle has
    [SerializeField]
    GameObject Startstate, Firststate, Secondstate, Finishedstate;

    //any switches it needs
    [SerializeField]
    GameObject Switch1, Switch2, Switch3, Switch4;

    //takes the transforms, sprite renderers, and lever code from the levers in the puzzle (can grab the audio device for sound)
    Transform Switch1move, Switch2move, Switch3move, Switch4move;
    SpriteRenderer Switch1image, Switch2image, Switch3image, Switch4image;
    LeverActivate Switch1OnOff, Switch2OnOff, Switch3OnOff, Switch4OnOff;

    //variables to keep track of in the puzzle, the names should explain what they do
    bool Switch1active, Switch2active, Switch3active, Switch4active;
    int states;

    // Start is called before the first frame update
    void Start()
    {
        //initiallize anything not dopped in from Unity
        Switch1move = Switch1.GetComponent<Transform>();
        Switch2move = Switch2.GetComponent<Transform>();
        Switch3move = Switch3.GetComponent<Transform>();
        Switch4move = Switch4.GetComponent<Transform>();

        Switch1image = Switch1.GetComponent<SpriteRenderer>();
        Switch2image = Switch2.GetComponent<SpriteRenderer>();
        Switch3image = Switch3.GetComponent<SpriteRenderer>();
        Switch4image = Switch4.GetComponent<SpriteRenderer>();

        Switch1OnOff = Switch1.GetComponent<LeverActivate>();
        Switch2OnOff = Switch2.GetComponent<LeverActivate>();
        Switch3OnOff = Switch3.GetComponent<LeverActivate>();
        Switch4OnOff = Switch4.GetComponent<LeverActivate>();

        Switch1active = false;
        Switch2active = false;
        Switch3active = false;
        Switch4active = false;

        states = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //There are three methods, the first checks the levers code, the second updates things in this code and changes the sprites of the levers, and the third changes the state of the puzzle in Unity
        SwitchThisLever();
        LeversOnOff();
        SwitchStates();
    }

    //3rd method, switches the states of the puzzle and in puzzle 1 will also move the levers with the puzzle if need be
    protected override void SwitchStates()
    {
        switch (states)
        {
            case 0:
                Startstate.SetActive(true);
                Firststate.SetActive(false);
                Secondstate.SetActive(false);
                Finishedstate.SetActive(false);
                Switch2move.position = new Vector3(Switch2move.position.x, .68f, Switch2move.position.z);
                Switch3move.position = new Vector3(Switch3move.position.x, -.36f, Switch2move.position.z);
                break;
            case 1:
                Startstate.SetActive(false);
                Firststate.SetActive(true);
                Secondstate.SetActive(false);
                Finishedstate.SetActive(false);
                Switch2move.position = new Vector3(Switch2move.position.x, .12f, Switch2move.position.z);
                Switch3move.position = new Vector3(Switch3move.position.x, -.36f, Switch2move.position.z);
                break;
            case 2:
                Startstate.SetActive(false);
                Firststate.SetActive(false);
                Secondstate.SetActive(true);
                Finishedstate.SetActive(false);
                Switch2move.position = new Vector3(Switch2move.position.x, .68f, Switch2move.position.z);
                Switch3move.position = new Vector3(Switch3move.position.x, .12f, Switch2move.position.z);
                break;
            case 3:
                Startstate.SetActive(false);
                Firststate.SetActive(false);
                Secondstate.SetActive(false);
                Finishedstate.SetActive(true);
                Switch2move.position = new Vector3(Switch2move.position.x, .12f, Switch2move.position.z);
                Switch3move.position = new Vector3(Switch3move.position.x, .12f, Switch2move.position.z);
                break;
        }
    }

    //method 2 checks the puzzle for all the possible lever combinations the player (should) be able to make and changes the state of the puzzle and lever sprites accordingly
    protected override void LeversOnOff()
    {
        if (Switch1active == false && Switch2active == false && Switch3active == false && Switch4active == false)
        {
            states = 0;
            Switch1image.sprite = leverOff;
            Switch2image.sprite = leverOff;
            Switch3image.sprite = leverOff;
            Switch4image.sprite = leverOff;
        }
        else if (Switch1active == true && Switch2active == true && Switch3active == true && Switch4active == true)
        {
            states = 0;
            Switch1image.sprite = leverOn;
            Switch2image.sprite = leverOn;
            Switch3image.sprite = leverOn;
            Switch4image.sprite = leverOn;
        }
        else if (Switch1active == true && Switch2active == false && Switch3active == false && Switch4active == false)
        {
            states = 1;
            Switch1image.sprite = leverOn;
            Switch2image.sprite = leverOff;
            Switch3image.sprite = leverOff;
            Switch4image.sprite = leverOff;
        }
        else if (Switch1active == true && Switch2active == true && Switch3active == true && Switch4active == false)
        {
            states = 2;
            Switch1image.sprite = leverOn;
            Switch2image.sprite = leverOn;
            Switch3image.sprite = leverOn;
            Switch4image.sprite = leverOff;
        }
        else if (Switch1active == true && Switch2active == true && Switch3active == false && Switch4active == false)
        {
            states = 3;
            Switch1image.sprite = leverOn;
            Switch2image.sprite = leverOn;
            Switch3image.sprite = leverOff;
            Switch4image.sprite = leverOff;
        }
        else if (Switch1active == false && Switch2active == false && Switch3active == true && Switch4active == true)
        {
            states = 3;
            Switch1image.sprite = leverOff;
            Switch2image.sprite = leverOff;
            Switch3image.sprite = leverOn;
            Switch4image.sprite = leverOn;
        }
        else if (Switch1active == false && Switch2active == false && Switch3active == false && Switch4active == true)
        {
            states = 2;
            Switch1image.sprite = leverOff;
            Switch2image.sprite = leverOff;
            Switch3image.sprite = leverOff;
            Switch4image.sprite = leverOn;
        }
        else if (Switch1active == false && Switch2active == true && Switch3active == true && Switch4active == true)
        {
            states = 1;
            Switch1image.sprite = leverOff;
            Switch2image.sprite = leverOn;
            Switch3image.sprite = leverOn;
            Switch4image.sprite = leverOn;
        }
        else if (Switch1active == false && Switch2active == true && Switch3active == false && Switch4active == false)
        {
            states = 2;
            Switch1image.sprite = leverOff;
            Switch2image.sprite = leverOn;
            Switch3image.sprite = leverOff;
            Switch4image.sprite = leverOff;
        }
        else if (Switch1active == true && Switch2active == true && Switch3active == false && Switch4active == true)
        {
            states = 1;
            Switch1image.sprite = leverOff;
            Switch2image.sprite = leverOn;
            Switch3image.sprite = leverOff;
            Switch4image.sprite = leverOn;
        }
        else if (Switch1active == true && Switch2active == false && Switch3active == true && Switch4active == true)
        {
            states = 2;
            Switch1image.sprite = leverOn;
            Switch2image.sprite = leverOff;
            Switch3image.sprite = leverOn;
            Switch4image.sprite = leverOn;
        }
    }

    //method 1 simply checks the levers coding and tell the variables in this code whether a lever is returning on or off (true or false)
    protected override void SwitchThisLever()
    {
        if (Switch1OnOff.leverActivated == true)
            Switch1active = true;
        else
            Switch1active = false;

        if (Switch2OnOff.leverActivated == true)
            Switch2active = true;
        else
            Switch2active = false;

        if (Switch3OnOff.leverActivated == true)
            Switch3active = true;
        else
            Switch3active = false;

        if (Switch4OnOff.leverActivated == true)
            Switch4active = true;
        else
            Switch4active = false;
    }
}