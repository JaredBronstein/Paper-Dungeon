using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Controller : MonoBehaviour
{

    [SerializeField]
    private GameObject Player;

    private GameObject Enemy;

    private int[] PlayerStats = new int[7];
    private int[] MobStats = new int[7];
    private string[] PlayerAttackList = new string[5];
    private string[] MobAttackList = new string[5];

    private bool isInCombat = false;

    private PlayerController2 PC2;
    private Player_Stats PS;
    private Mob_Stats MS;
    //private Canvas canvas;

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
        PlayerInfo();
        EnemyInfo();
    }
    private void CombatEnd()
    {
        Enemy.GetComponent<BoxCollider2D>().enabled = false;
        Enemy.GetComponent<SpriteRenderer>().enabled = false;
        PS.EXP += MS.EXP;
        PC2.InCombat = false;
        isInCombat = false;
        Debug.Log("Combat has Ended!");
    }
    #region GetInfo
    /// <summary>
    /// Gets Stats and Attack List from the Player_Stats class and passes it in here
    /// </summary>
    private void PlayerInfo()
    {
        //Debug.Log("Player Stats Size CC: " + PlayerStats.Length);
        //Debug.Log("Player Stats Size PS: " + PS.Stats.Length);
        for (int i = 0; i < PS.Stats.Length; i++)
        {
            PlayerStats[i] = PS.Stats[i];
        }
        for (int i = 0; i < PS.AttackList.Length; i++)
        {
            PlayerAttackList[i] = PS.AttackList[i];
        }
    }
    /// <summary>
    /// Gets Stats and Attack List from the Mob_Stats class of the enemy reference
    /// </summary>
    private void EnemyInfo()
    {
        for (int i = 0; i < MS.Stats.Length; i++)
        {
            MobStats[i] = MS.Stats[i];
        }
        for (int i = 0; i < MS.AttackList.Length; i++)
        {
            MobAttackList[i] = MS.AttackList[i];
        }
    }
    #endregion
}
