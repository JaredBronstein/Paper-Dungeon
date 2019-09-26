using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Controller : MonoBehaviour
{

    [SerializeField]
    private GameObject Player;

    private PlayerController pc;
    private Canvas canvas;

    private void Awake()
    {
        canvas = this.GetComponent<Canvas>();
    }

    void Update()
    {
        //BattleCheck();
    }

    //private void BattleCheck()
    //{
    //    if (pc.InCombat)
    //    {

    //    }
    //}
}
