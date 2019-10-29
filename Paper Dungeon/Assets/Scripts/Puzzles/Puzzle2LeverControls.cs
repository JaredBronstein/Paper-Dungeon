using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2LeverControls : ILeverPuzzles
{
    [SerializeField]
    GameObject Startstate, Firststate, Secondstate, Thirdstate, Fourthstate, Fifthstate, Sixthstate, Finishedstate;

    [SerializeField]
    GameObject Switch1, Switch2, Switch3, Switch4, Switch5, Switch6, Switch7, Switch8;

    [SerializeField]
    GameObject Switch1_2, Switch2_2, Switch3_2, Switch4_2, Switch5_2, Switch6_2, Switch7_2, Switch8_2;

    SpriteRenderer Switch1image, Switch2image, Switch3image, Switch4image, Switch5image, Switch6image, Switch7image, Switch8image;
    LeverActivate Switch1OnOff, Switch2OnOff, Switch3OnOff, Switch4OnOff, Switch5OnOff, Switch6OnOff, Switch47nOff, Switch8OnOff;

    SpriteRenderer Switch1_2image, Switch2_2image, Switch3_2image, Switch4_2image, Switch5_2image, Switch6_2image, Switch7_2image, Switch8_2image;
    LeverActivate Switch1_2OnOff, Switch2_2OnOff, Switch3_2OnOff, Switch4_2OnOff, Switch5_2OnOff, Switch6_2OnOff, Switch7_2nOff, Switch8_2OnOff;

    bool Switch1active, Switch2active, Switch3active, Switch4active, Switch5active, Switch6active, Switch7active, Switch8active;
    bool Switch1_2active, Switch2_2active, Switch3_2active, Switch4_2active, Switch5_2active, Switch6_2active, Switch7_2active, Switch8_2active;
    int states;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
