using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Controller : MonoBehaviour
{

    [SerializeField]
    private GameObject Player;

    private GameObject Enemy;

    private int[] PlayerStats = new int[2];
    private int[] MobStats = new int[2];

    private bool isInCombat = false;

    private PlayerController2 PC2;
    private Player_Stats PS;
    private Mob_Stats MS;

    private void Awake()
    {
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
    public void GetInput()
    {
        PlayerAction();
        if (MobStats[0] <= 0)
        {
            CombatEnd();
        }
        else
        {
            MobAction();
            if (PlayerStats[0] <= 0)
            {
                GameOver();
            }
        }
    }
    public void PlayerAction()
    {
        Debug.Log("Player Attacks!");
        MobStats[0] -= PlayerStats[1];
    }
    public void MobAction()
    {
        Debug.Log("Enemy Attacks!");
        PlayerStats[0] -= MobStats[1];
    }
    private void CombatEnd()
    {
        this.gameObject.SetActive(false);
        Enemy.GetComponent<BoxCollider2D>().enabled = false;
        Enemy.GetComponent<SpriteRenderer>().enabled = false;
        //Enemy.GetComponent<EnemyController>().enabled = false;
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
    private void GameOver()
    {

    }
}
