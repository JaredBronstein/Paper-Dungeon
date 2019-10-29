using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2LeverControls : ILeverPuzzles
{
    [SerializeField]
    GameObject Startstate, Firststate, Secondstate, Thirdstate, Fourthstate, Fifthstate, Sixthstate, Finishedstate;

    [SerializeField]
    GameObject Switch1, Switch2, Switch3, Switch4, Switch5, Switch6, Switch7, Switch8;

    SpriteRenderer Switch1image, Switch2image, Switch3image, Switch4image, Switch5image, Switch6image, Switch7image, Switch8image;
    LeverActivate Switch1OnOff, Switch2OnOff, Switch3OnOff, Switch4OnOff, Switch5OnOff, Switch6OnOff, Switch7OnOff, Switch8OnOff;

    bool Switch1active, Switch2active, Switch3active, Switch4active, Switch5active, Switch6active, Switch7active, Switch8active;
    int states;

    // Start is called before the first frame update
    void Start()
    {
        Switch1image = Switch1.GetComponent<SpriteRenderer>();
        Switch2image = Switch2.GetComponent<SpriteRenderer>();
        Switch3image = Switch3.GetComponent<SpriteRenderer>();
        Switch4image = Switch4.GetComponent<SpriteRenderer>();
        Switch5image = Switch5.GetComponent<SpriteRenderer>();
        Switch6image = Switch6.GetComponent<SpriteRenderer>();
        Switch7image = Switch7.GetComponent<SpriteRenderer>();
        Switch8image = Switch8.GetComponent<SpriteRenderer>();

        Switch1OnOff = Switch1.GetComponent<LeverActivate>();
        Switch2OnOff = Switch2.GetComponent<LeverActivate>();
        Switch3OnOff = Switch3.GetComponent<LeverActivate>();
        Switch4OnOff = Switch4.GetComponent<LeverActivate>();
        Switch5OnOff = Switch5.GetComponent<LeverActivate>();
        Switch6OnOff = Switch6.GetComponent<LeverActivate>();
        Switch7OnOff = Switch7.GetComponent<LeverActivate>();
        Switch8OnOff = Switch8.GetComponent<LeverActivate>();

        Switch1active = false;
        Switch2active = false;
        Switch3active = false;
        Switch4active = false;
        Switch5active = false;
        Switch6active = false;
        Switch7active = false;
        Switch8active = false;

        states = 1;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchThisLever();
        LeversOnOff();
        SwitchStates();
    }

    protected override void SwitchStates()
    {
        switch (states)
        {
            case 0:
                Startstate.SetActive(true);
                Firststate.SetActive(false);
                Secondstate.SetActive(false);
                Thirdstate.SetActive(false);
                Fourthstate.SetActive(false);
                Fifthstate.SetActive(false);
                Sixthstate.SetActive(false);
                Finishedstate.SetActive(false);
                break;
            case 1:
                Startstate.SetActive(false);
                Firststate.SetActive(true);
                Secondstate.SetActive(false);
                Thirdstate.SetActive(false);
                Fourthstate.SetActive(false);
                Fifthstate.SetActive(false);
                Sixthstate.SetActive(false);
                Finishedstate.SetActive(false);
                break;
            case 2:
                Startstate.SetActive(false);
                Firststate.SetActive(false);
                Secondstate.SetActive(true);
                Thirdstate.SetActive(false);
                Fourthstate.SetActive(false);
                Fifthstate.SetActive(false);
                Sixthstate.SetActive(false);
                Finishedstate.SetActive(false);
                break;
            case 3:
                Startstate.SetActive(false);
                Firststate.SetActive(false);
                Secondstate.SetActive(false);
                Thirdstate.SetActive(true);
                Fourthstate.SetActive(false);
                Fifthstate.SetActive(false);
                Sixthstate.SetActive(false);
                Finishedstate.SetActive(false);
                break;
            case 4:
                Startstate.SetActive(false);
                Firststate.SetActive(false);
                Secondstate.SetActive(false);
                Thirdstate.SetActive(false);
                Fourthstate.SetActive(true);
                Fifthstate.SetActive(false);
                Sixthstate.SetActive(false);
                Finishedstate.SetActive(false);
                break;
            case 5:
                Startstate.SetActive(false);
                Firststate.SetActive(false);
                Secondstate.SetActive(false);
                Thirdstate.SetActive(false);
                Fourthstate.SetActive(false);
                Fifthstate.SetActive(true);
                Sixthstate.SetActive(false);
                Finishedstate.SetActive(false);
                break;
            case 6:
                Startstate.SetActive(false);
                Firststate.SetActive(false);
                Secondstate.SetActive(false);
                Thirdstate.SetActive(false);
                Fourthstate.SetActive(false);
                Fifthstate.SetActive(false);
                Sixthstate.SetActive(true);
                Finishedstate.SetActive(false);
                break;
            case 7:
                Startstate.SetActive(false);
                Firststate.SetActive(false);
                Secondstate.SetActive(false);
                Thirdstate.SetActive(false);
                Fourthstate.SetActive(false);
                Fifthstate.SetActive(false);
                Sixthstate.SetActive(false);
                Finishedstate.SetActive(true);
                break;
        }
    }

    protected override void LeversOnOff()
    {
        if (Switch1active == false && Switch2active == false && Switch3active == false && Switch4active == false && Switch5active == false && Switch6active == false && Switch7active == false && Switch8active == false)
        {
            states = 1;
            Switch1image.sprite = leverOff;
            Switch2image.sprite = leverOff;
            Switch3image.sprite = leverOff;
            Switch4image.sprite = leverOff;
            Switch5image.sprite = leverOff;
            Switch6image.sprite = leverOff;
            Switch7image.sprite = leverOff;
            Switch8image.sprite = leverOff;

        }
        else if (Switch1active == true && Switch2active == false && Switch3active == false && Switch4active == false && Switch5active == false && Switch6active == false && Switch7active == false && Switch8active == false)
        {
            states = 0;
            Switch1image.sprite = leverOn;
            Switch2image.sprite = leverOff;
            Switch3image.sprite = leverOff;
            Switch4image.sprite = leverOff;
            Switch5image.sprite = leverOff;
            Switch6image.sprite = leverOff;
            Switch7image.sprite = leverOff;
            Switch8image.sprite = leverOff;

        }
        else if (Switch1active == true && Switch2active == true && Switch3active == false && Switch4active == false && Switch5active == false && Switch6active == false && Switch7active == false && Switch8active == false)
        {
            states = 1;
            Switch1image.sprite = leverOn;
            Switch2image.sprite = leverOn;
            Switch3image.sprite = leverOff;
            Switch4image.sprite = leverOff;
            Switch5image.sprite = leverOff;
            Switch6image.sprite = leverOff;
            Switch7image.sprite = leverOff;
            Switch8image.sprite = leverOff;

        }
        else if (Switch1active == true && Switch2active == true && Switch3active == true && Switch4active == false && Switch5active == false && Switch6active == false && Switch7active == false && Switch8active == false)
        {
            states = 2;
            Switch1image.sprite = leverOn;
            Switch2image.sprite = leverOn;
            Switch3image.sprite = leverOn;
            Switch4image.sprite = leverOff;
            Switch5image.sprite = leverOff;
            Switch6image.sprite = leverOff;
            Switch7image.sprite = leverOff;
            Switch8image.sprite = leverOff;
        }
        else if (Switch1active == true && Switch2active == true && Switch3active == true && Switch4active == true && Switch5active == false && Switch6active == false && Switch7active == false && Switch8active == false)
        {
            states = 3;
            Switch1image.sprite = leverOn;
            Switch2image.sprite = leverOn;
            Switch3image.sprite = leverOn;
            Switch4image.sprite = leverOn;
            Switch5image.sprite = leverOff;
            Switch6image.sprite = leverOff;
            Switch7image.sprite = leverOff;
            Switch8image.sprite = leverOff;

        }
        else if (Switch1active == true && Switch2active == true && Switch3active == true && Switch4active == true && Switch5active == true && Switch6active == false && Switch7active == false && Switch8active == false)
        {
            states = 4;
            Switch1image.sprite = leverOn;
            Switch2image.sprite = leverOn;
            Switch3image.sprite = leverOn;
            Switch4image.sprite = leverOn;
            Switch5image.sprite = leverOn;
            Switch6image.sprite = leverOff;
            Switch7image.sprite = leverOff;
            Switch8image.sprite = leverOff;
        }
        else if (Switch1active == true && Switch2active == true && Switch3active == true && Switch4active == true && Switch5active == true && Switch6active == true && Switch7active == false && Switch8active == false)
        {
            states = 5;
            Switch1image.sprite = leverOn;
            Switch2image.sprite = leverOn;
            Switch3image.sprite = leverOn;
            Switch4image.sprite = leverOn;
            Switch5image.sprite = leverOn;
            Switch6image.sprite = leverOn;
            Switch7image.sprite = leverOff;
            Switch8image.sprite = leverOff;

        }
        else if (Switch1active == true && Switch2active == true && Switch3active == true && Switch4active == true && Switch5active == true && Switch6active == true && Switch7active == true && Switch8active == false)
        {
            states = 6;
            Switch1image.sprite = leverOn;
            Switch2image.sprite = leverOn;
            Switch3image.sprite = leverOn;
            Switch4image.sprite = leverOn;
            Switch5image.sprite = leverOn;
            Switch6image.sprite = leverOn;
            Switch7image.sprite = leverOn;
            Switch8image.sprite = leverOff;
        }
        else if (Switch1active == true && Switch2active == true && Switch3active == true && Switch4active == true && Switch5active == true && Switch6active == true && Switch7active == true && Switch8active == true)
        {
            states = 7;
            Switch1image.sprite = leverOn;
            Switch2image.sprite = leverOn;
            Switch3image.sprite = leverOn;
            Switch4image.sprite = leverOn;
            Switch5image.sprite = leverOn;
            Switch6image.sprite = leverOn;
            Switch7image.sprite = leverOn;
            Switch8image.sprite = leverOn;
        }
    }

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

        if (Switch5OnOff.leverActivated == true)
            Switch5active = true;
        else
            Switch5active = false;

        if (Switch6OnOff.leverActivated == true)
            Switch6active = true;
        else
            Switch6active = false;

        if (Switch7OnOff.leverActivated == true)
            Switch7active = true;
        else
            Switch7active = false;

            if (Switch8OnOff.leverActivated == true)
            Switch8active = true;
        else
            Switch8active = false;
    }
}
