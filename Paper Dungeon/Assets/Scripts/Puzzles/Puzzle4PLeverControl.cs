using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle4PLeverControl : ILeverPuzzles
{
    [SerializeField]
    GameObject Firststate, Secondstate;

    [SerializeField]
    GameObject Switch1, Switch2, Switch3;

    SpriteRenderer Switch1image, Switch2image, Switch3image;
    LeverActivate Switch1OnOff, Switch2OnOff, Switch3OnOff;

    bool Switch1active, Switch2active, Switch3active;
    int states;

    // Start is called before the first frame update
    void Start()
    {
        Switch1image = Switch1.GetComponent<SpriteRenderer>();
        Switch2image = Switch2.GetComponent<SpriteRenderer>();
        Switch3image = Switch3.GetComponent<SpriteRenderer>();

        Switch1OnOff = Switch1.GetComponent<LeverActivate>();
        Switch2OnOff = Switch2.GetComponent<LeverActivate>();
        Switch3OnOff = Switch3.GetComponent<LeverActivate>();

        Switch1active = false;
        Switch2active = false;
        Switch3active = false;

        states = 0;
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
                Firststate.SetActive(true);
                Secondstate.SetActive(false);
                break;
            case 1:
                Firststate.SetActive(false);
                Secondstate.SetActive(true);
                break;
        }
    }

    protected override void LeversOnOff()
    {
        if (Switch1active == false && Switch2active == false && Switch3active == false)
        {
            states = 0;
            Switch1image.sprite = leverOff;
            Switch2image.sprite = leverOff;
            Switch3image.sprite = leverOff;
        }
        else if (Switch1active == true && Switch2active == false && Switch3active == false)
        {
            states = 0;
            Switch1image.sprite = leverOn;
            Switch2image.sprite = leverOff;
            Switch3image.sprite = leverOff;
        }
        else if (Switch1active == true && Switch2active == true && Switch3active == false)
        {
            states = 0;
            Switch1image.sprite = leverOn;
            Switch2image.sprite = leverOn;
            Switch3image.sprite = leverOff;
        }
        else if (Switch1active == true && Switch2active == true && Switch3active == true)
        {
            states = 1;
            Switch1image.sprite = leverOn;
            Switch2image.sprite = leverOn;
            Switch3image.sprite = leverOn;
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
    }
}
