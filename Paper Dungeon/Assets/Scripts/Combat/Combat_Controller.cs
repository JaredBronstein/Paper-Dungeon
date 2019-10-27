using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Combat_Controller : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private Text textbox;

    private GameObject Enemy;

    private string[] AttackInfo = new string[6];
    private int[] PlayerStats = new int[7];
    private int[] MobStats = new int[7];

    private bool isInCombat = false;
    private bool isPhys, isAttack;
    private int StatUsed, StatTarget, Damage, MaxHP;
    private double Modifier;

    private PlayerController2 PC2;
    private Player_Stats PS;
    private Mob_Stats MS;
    #endregion

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
        //Debug.Log("Combat has Begun!");
        Enemy.GetComponent<EnemyController>().enabled = false;
        PlayerStats = PS.StatReturn();
        MobStats = MS.StatReturn();
        MaxHP = PlayerStats[0];
        textbox.text = "A wild " + Enemy.name + " has appeared!";
        for(int i=0; i <PlayerStats.Length; i++)
        {
            Debug.Log("Player Stat " + i + " is " + PlayerStats[i]);
        }
    }

    public void GetInput(int Choice)
    {
        Debug.Log("Player Health: " + PlayerStats[0]);
        Debug.Log("Slime Health: " + MobStats[0]);
        this.GetComponentInChildren<Button>().enabled = false;
        if(PlayerStats[6] >= MobStats[6])
        {
            PlayerAction(Choice);
            StartCoroutine(Delay(1.0f));
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
            StartCoroutine(Delay(1.0f));
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
        this.GetComponentInChildren<Button>().enabled = true;
    }

    public void PlayerAction(int Selection)
    {
        AttackInfo = PS.Attack(Selection);
        //Debug.Log(AttackInfo[0] + " " + AttackInfo[1] + " " + AttackInfo[2] + " " + AttackInfo[3] + " " + AttackInfo[4] + " " + AttackInfo[5]);
        ConvertAttack();
        Debug.Log("Player uses " + AttackInfo[0]);
        textbox.text = "Player uses " + AttackInfo[0];
        StartCoroutine(Delay(1.0f));
        if (isAttack)
        {
            if (isPhys)
            {
                Damage = Convert.ToInt32(PlayerStats[StatUsed] * Modifier - MobStats[3]);
            }
            else
            {
                Damage = Convert.ToInt32(PlayerStats[StatUsed] * Modifier - MobStats[5]);
            }
            MobStats[StatTarget] -= Damage;
            Debug.Log("Player does " + Damage + " damage.");
            textbox.text = "Player does " + Damage + " damage.";
        }
        else
        {
            PlayerStats[StatTarget] += Convert.ToInt32(PlayerStats[StatUsed] * Modifier);
        }
        if(PlayerStats[0] > MaxHP)
        {
            PlayerStats[0] = MaxHP;
        }
    }

    public void MobAction()
    {
        AttackInfo = MS.Attack(0);
        ConvertAttack();
        Debug.Log("Enemy uses " + AttackInfo[0]);
        textbox.text = "Enemy uses " + AttackInfo[0];
        StartCoroutine(Delay(1.0f));
        if (isAttack)
        {
            if (isPhys)
            {
                 Damage = Convert.ToInt32(MobStats[StatUsed] * Modifier - PlayerStats[3]);
            }
            else
            {
                Damage = Convert.ToInt32(MobStats[StatUsed] * Modifier - PlayerStats[5]);
            }
            PlayerStats[StatTarget] -= Damage;
            Debug.Log("Slime does " + Damage + " damage.");
            textbox.text = "Slime does " + Damage + " damage.";
        }
        else
        {
            MobStats[StatTarget] += Convert.ToInt32(MobStats[StatUsed] * Modifier);
        }
    }

    private void CombatEnd()
    {
        textbox.text = "You win! You gained  " + MS.EXP + " experience points";
        StartCoroutine(Delay(1.0f));
        this.gameObject.SetActive(false);
        Enemy.GetComponent<BoxCollider2D>().enabled = false;
        Enemy.GetComponent<SpriteRenderer>().enabled = false;
        PS.EXP += MS.EXP;
        PC2.InCombat = false;
        isInCombat = false;
        //Debug.Log("Combat has Ended!");
        //for(int i=0;i<PlayerStats.Length;i++)
        //{
        //    Debug.Log("Player Stat " + i + "'s value is " + PlayerStats[i]);
        //}
        //for(int i=0;i<MobStats.Length;i++)
        //{
        //    Debug.Log("Mob Stat " + i + "'s value is " + MobStats[i]);
        //}
    }

    public void Flee()
    {
        textbox.text = "You ran away safely";
        StartCoroutine(Delay(1.0f));
        textbox.text = "";
        this.gameObject.SetActive(false);
        Enemy.GetComponent<EnemyController>().enabled = true;
        Enemy.GetComponent<BoxCollider2D>().enabled = false;
        isInCombat = false;
        PC2.InCombat = false;
        StartCoroutine(Delay(2.0f));
        Enemy.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void GameOver()
    {
        Debug.Log("DEAD");
    }

    private void ConvertAttack()
    {
        isAttack = (AttackInfo[1] == "true");
        StatUsed = Convert.ToInt16(AttackInfo[2]);
        StatTarget = Convert.ToInt16(AttackInfo[3]);
        Modifier = Convert.ToDouble(AttackInfo[4]);
        isPhys = (AttackInfo[5] == "true");
        Debug.Log("Attack Stats: " + AttackInfo[0] + "," + AttackInfo[1] + "," + AttackInfo[2] + "," + AttackInfo[3] + "," + AttackInfo[4] + "," + AttackInfo[5]);
    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
