using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Controller : MonoBehaviour
{

    [SerializeField]
    private GameObject Player;

    private GameObject Enemy;

    private string[] AttackInfo = new string[6];
    private int[] PlayerStats = new int[7];
    private int[] MobStats = new int[7];

    private bool isInCombat = false;

    private bool isPhys, isAttack;
    private int StatUsed, StatTarget;
    private double Modifier;

    private PlayerController2 PC2;
    private Player_Stats PS;
    private Mob_Stats MS;

    private void Awake()
    {
        //canvas = this.GetComponent<Canvas>();
        PC2 = Player.GetComponent<PlayerController2>();
        PS = Player.GetComponent<Player_Stats>();        
    }

    void Update()
    {
        if (PC2.InCombat && !isInCombat)
        {
            isInCombat = true;
            GetEnemy();
            CombatStart();
        }
    }
    private void GetEnemy()
    {
        Enemy = PC2.Opponent;
        MS = Enemy.GetComponent<Mob_Stats>();
    }
    private void CombatStart()
    {
        Debug.Log("Combat has Begun!");
        PlayerStats = PS.StatReturn();
        MobStats = MS.StatReturn();
    }
    public void GetInput(int Selection)
    {
        AttackInfo = PS.Attack(Selection);
        PlayerAction();
        MobAction();
        if(PlayerStats[0] <= 0 || MobStats[0] <= 0)
        {
            CombatEnd();
        }
    }
    public void PlayerAction()
    {
        ConvertAttack();
        Debug.Log("Player uses " + AttackInfo[0]);
        if(isAttack)
        {
            if (isPhys)
            {
                MobStats[StatTarget] -= MobStats[StatTarget] - Convert.ToInt32(PlayerStats[StatUsed] * Modifier - MobStats[2]);
            }
            else
            {
                MobStats[StatTarget] -= MobStats[StatTarget] - Convert.ToInt32(PlayerStats[StatUsed] * Modifier - MobStats[4]);
            }
        }
        else
        {
            PlayerStats[StatTarget] += PlayerStats[StatTarget] + Convert.ToInt32(PlayerStats[StatUsed] * Modifier);
        }
    }
    public void MobAction()
    {
        AttackInfo = MS.Attack(UnityEngine.Random.Range(0, MS.AttackList.Length+1));
        ConvertAttack();
        Debug.Log("Enemy uses " + AttackInfo[0]);
        if (isAttack)
        {
            if (isPhys)
            {
                PlayerStats[StatTarget] -= PlayerStats[StatTarget] - Convert.ToInt32(MobStats[StatUsed] * Modifier - PlayerStats[2]);
            }
            else
            {
                PlayerStats[StatTarget] -= PlayerStats[StatTarget] - Convert.ToInt32(MobStats[StatUsed] * Modifier - PlayerStats[4]);
            }
        }
        else
        {
            MobStats[StatTarget] += MobStats[StatTarget] + Convert.ToInt32(MobStats[StatUsed] * Modifier);
        }
    }
    private void CombatEnd()
    {
        this.gameObject.SetActive(false);
        Enemy.GetComponent<BoxCollider2D>().enabled = false;
        Enemy.GetComponent<SpriteRenderer>().enabled = false;
        PS.EXP += MS.EXP;
        PC2.InCombat = false;
        isInCombat = false;
        Debug.Log("Combat has Ended!");
        for(int i=0;i<PlayerStats.Length;i++)
        {
            Debug.Log("Player Stat " + i + "'s value is " + PlayerStats[i]);
        }
        for(int i=0;i<MobStats.Length;i++)
        {
            Debug.Log("Mob Stat " + i + "'s value is " + MobStats[i]);
        }
    }
    private void ConvertAttack()
    {
        isAttack = (AttackInfo[1] == "true");
        StatUsed = Convert.ToInt16(AttackInfo[2]);
        StatTarget = Convert.ToInt16(AttackInfo[3]);
        Modifier = Convert.ToDouble(AttackInfo[4]);
        isPhys = (AttackInfo[5] == "true");
    }
}
