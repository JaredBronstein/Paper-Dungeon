using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Stats : MonoBehaviour
{
    public int HP, MP, ATK, DEF, MAG, WIS, SPD;
    [Tooltip("List of Attacks the Mob can use. Formatting is Name,IsAttack,StatUsed,StatTarget,Modifier,isPhys")]
    public string[] AttackList;

    public string[] NameList;
    public bool[] IsAttackList;
    public string[] StatUsedList;
    public string[] StatTargetList;
    public double[] ModifierList;
    public bool[] isPhysList;

    private string[] temp;

    public virtual int Attack()
    {
        int rng = UnityEngine.Random.Range(0, AttackList.Length);
        return rng;
    }
    public int SpeedCheck()
    {
        return SPD + UnityEngine.Random.Range(0, 4);
    }
    public void AttackListFormat()
    {
        for (int i = 0; i <= AttackList.Length; i++)
        {
            temp = AttackList[i].Split(',');
            NameList[i] = temp[0];
            IsAttackList[i] = (temp[1] == "true");
            StatUsedList[i] = temp[2];
            StatTargetList[i] = temp[3];
            ModifierList[i] = Convert.ToDouble(temp[4]);
            isPhysList[i] = (temp[5] == "true");
        }
    }
}
