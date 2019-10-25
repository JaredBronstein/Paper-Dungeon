using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat_Controller : MonoBehaviour
{

    [SerializeField]
    private GameObject Player;

    //[SerializeField]
    //private GameObject buttonPrefab;

    private GameObject Enemy;

    private string[] AttackInfo = new string[6];

    //private int NumberofPlayerAttacks = 1;
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
        PC2 = Player.GetComponent<PlayerController2>();
        PS = Player.GetComponent<Player_Stats>();
    }

    void Update()
    {
        //if(PS.AttackList[NumberofPlayerAttacks] != null)
        //{
        //    AddButton();
        //    NumberofPlayerAttacks++;
        //}
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
        Enemy.GetComponent<EnemyController>().enabled = false;
        PlayerStats = PS.StatReturn();
        MobStats = MS.StatReturn();
    }
    public void GetInput(int Choice)
    {
        if(PlayerStats[6] >= MobStats[6])
        {
            PlayerAction(Choice);
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
        else
        {
            MobAction();
            if (PlayerStats[0] <= 0)
            {
                GameOver();
            }
            else
            {
                PlayerAction(Choice);
                if (MobStats[0] <= 0)
                {
                    CombatEnd();
                }
            }
        }
    }
    public void PlayerAction(int Selection)
    {
        AttackInfo = PS.Attack(Selection);
        Debug.Log("Player uses " + AttackInfo[0]);
        if (isAttack)
        {
            if (isPhys)
            {
                MobStats[StatTarget] -= Convert.ToInt32(PlayerStats[StatUsed] * Modifier - MobStats[2]);
            }
            else
            {
                MobStats[StatTarget] -= Convert.ToInt32(PlayerStats[StatUsed] * Modifier - MobStats[4]);
            }
        }
        else
        {
            PlayerStats[StatTarget] += Convert.ToInt32(PlayerStats[StatUsed] * Modifier);
        }
    }
    public void MobAction()
    {
        AttackInfo = MS.Attack(UnityEngine.Random.Range(0, MS.AttackList.Length));
        ConvertAttack();
        Debug.Log("Enemy uses " + AttackInfo[0]);
        if (isAttack)
        {
            if (isPhys)
            {
                PlayerStats[StatTarget] -= Convert.ToInt32(MobStats[StatUsed] * Modifier - PlayerStats[2]);
            }
            else
            {
                PlayerStats[StatTarget] -= Convert.ToInt32(MobStats[StatUsed] * Modifier - PlayerStats[4]);
            }
        }
        else
        {
            MobStats[StatTarget] += Convert.ToInt32(MobStats[StatUsed] * Modifier);
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
    public void Flee()
    {
        this.gameObject.SetActive(false);
        Enemy.GetComponent<EnemyController>().enabled = true;
        Enemy.GetComponent<BoxCollider2D>().enabled = false;
        isInCombat = false;
        PC2.InCombat = false;
        Invoke("FleeDelay", 2.0f);
    }
    private void GameOver()
    {

    }
    private void FleeDelay()
    {
        Enemy.GetComponent<BoxCollider2D>().enabled = true;
    }
    //private void AddButton()
    //{
    //    GameObject button = (GameObject)Instantiate(buttonPrefab);
    //    button.transform.SetParent(this.transform); //this sets the parent of the button. Change to specific panel button will appear in
    //    button.GetComponent<Button>().onClick.AddListener(delegate { GetInput(NumberofPlayerAttacks); });
    //}
    private void ConvertAttack()
    {
        isAttack = (AttackInfo[1] == "true");
        StatUsed = Convert.ToInt16(AttackInfo[2]);
        StatTarget = Convert.ToInt16(AttackInfo[3]);
        Modifier = Convert.ToDouble(AttackInfo[4]);
        isPhys = (AttackInfo[5] == "true");
    }
}
