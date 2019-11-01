using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Stats : MonoBehaviour
{
    [SerializeField]
    protected int HP, MP, ATK, DEF, MAG, WIS, SPD;
    protected int[] Stats  = new int[7];
    [Tooltip("Experience Points, gained after combat")]
    public int EXP;
    [Tooltip("List of Attacks the Mob can use. Formatting is Name,IsAttack,StatUsed,StatTarget,Modifier,isPhys")]
    public string[] AttackList = new string[6];

    private string[] temp;

    private void Awake()
    {
        if(ATK > DEF)
        {
            AttackList[0] = "Attack,true,2,0,1,true";
        }
        else
        {
            AttackList[0] = "Magic Attack,true,4,0,1,false";
        }
    }
    public string[] Attack(int AttackNumber)
    {
        if(AttackList[AttackNumber] != null)
        {
            temp = AttackList[AttackNumber].Split(',');
        }
        else
        {
            temp = AttackList[0].Split(',');
        }
        return temp;
    }
    public int[] StatReturn()
    {
        Stats[0] = HP;
        Stats[1] = MP;
        Stats[2] = ATK;
        Stats[3] = DEF;
        Stats[4] = MAG;
        Stats[5] = WIS;
        Stats[6] = SPD;
        return Stats;
    }
}
