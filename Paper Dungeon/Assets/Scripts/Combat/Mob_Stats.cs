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
    public string[] AttackList = new string[5];

    private string[] temp;

    private void Awake()
    {
        StatUpdate();
        AttackList[0] = "Attack,true,ATK,HP,1,true";
    }
    public string[] Attack(int AttackNumber)
    {
        temp = AttackList[AttackNumber].Split(',');
        return temp;
    }
    public int[] StatReturn()
    {
        return Stats;
    }
    protected void StatUpdate()
    {
        Stats[0] = HP;
        Stats[1] = MP;
        Stats[2] = ATK;
        Stats[3] = DEF;
        Stats[4] = MAG;
        Stats[5] = WIS;
        Stats[6] = SPD;
        for (int i = 0; i < Stats.Length; i++)
        {
            Debug.Log(this.gameObject.name + " Stat " + i + "'s value is " + Stats[i]);
        }
    }
}
