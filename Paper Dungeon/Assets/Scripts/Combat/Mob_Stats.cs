using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Stats : MonoBehaviour
{
    [SerializeField]
    protected int HP, ATK;
    protected int[] Stats  = new int[2];
    [Tooltip("Experience Points, gained after combat")]
    public int EXP;

    private void Awake()
    {
        StatUpdate();
    }
    public int[] StatReturn()
    {
        return Stats;
    }
    protected void StatUpdate()
    {
        Stats[0] = HP;
        Stats[1] = ATK;
        for (int i = 0; i < Stats.Length; i++)
        {
            Debug.Log("Player Stat " + i + "'s value is " + Stats[i]);
        }
    }
}
