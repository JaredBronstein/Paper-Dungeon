using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Stats : MonoBehaviour
{
    protected int HP, MP, ATK, DEF, MAG, WIS, SPD;
    public int[] Stats  = new int[7];
    [Tooltip("Experience Points, gained after combat")]
    public int EXP;
    [Tooltip("List of Attacks the Mob can use. Formatting is Name,IsAttack,StatUsed,StatTarget,Modifier,isPhys")]
    public string[] AttackList = new string[5];

    //public string[] NameList;
    //public bool[] IsAttackList;
    //public string[] StatUsedList;
    //public string[] StatTargetList;
    //public double[] ModifierList;
    //public bool[] isPhysList;

    private string[] temp;

    private void Awake()
    {
        StatUpdate();
    }

    /// <summary>
    /// Made to be called in the Combat Controller, used to pass in the attack information depending on input.
    /// </summary>
    /// <param name="AttackNumber">The Attack number from the attack list</param>
    /// <returns>The information of the Attack called</returns>
    public string[] Attack(int AttackNumber)
    {
        temp = AttackList[AttackNumber].Split(',');
        return temp;
    }
    public int[] StatReturn()
    {
        return Stats;
    }
    public int SpeedCheck()
    {
        return SPD + UnityEngine.Random.Range(0, 4);
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
    }
    //public void AttackListFormat()
    //{
    //    for (int i = 0; i <= AttackList.Length; i++)
    //    {
    //        temp = AttackList[i].Split(',');
    //        NameList[i] = temp[0];
    //        IsAttackList[i] = (temp[1] == "true");
    //        StatUsedList[i] = temp[2];
    //        StatTargetList[i] = temp[3];
    //        ModifierList[i] = Convert.ToDouble(temp[4]);
    //        isPhysList[i] = (temp[5] == "true");
    //    }
    //}
}
