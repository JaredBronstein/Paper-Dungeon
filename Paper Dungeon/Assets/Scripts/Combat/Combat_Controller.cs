using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Combat_Controller : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private Text textbox;
    [SerializeField]
    private Button[] buttons = new Button[6];
    [SerializeField]
    private Image[] EnemyImages = new Image[3];
    [SerializeField]
    private Image BossImage, Background;

    private GameObject Enemy;

    private string[] AttackInfo = new string[6];
    private int[] PlayerStats = new int[7];
    private int[] MobStats = new int[7];

    private bool isInCombat = false;
    private bool isPhys, isAttack;
    private int StatUsed, StatTarget, Damage, MaxHP, Choice;
    private double Modifier;
    private int BossCounter = 3;

    private PlayerController2 PC2;
    private Player_Stats PS;
    private Mob_Stats MS;
    private EnemyController EC;
    private BossController BC;
    #endregion

    private void Awake()
    {
        //Gets the Scripts from the Player
        PC2 = Player.GetComponent<PlayerController2>();
        PS = Player.GetComponent<Player_Stats>();
    }

    void Update()
    {
        //Checks to see if the player is in combat and the combat UI isn't on. If true, begin combat
        if (PC2.InCombat && !isInCombat)
        {
            isInCombat = true;
            GetEnemy();
            CombatStart();
        }
        if(BossCounter == 0)
        {
            SceneManager.LoadScene("Credits");
        }
    }

    private void GetEnemy()
    {
        Enemy = PC2.Opponent;        
        MS = Enemy.GetComponent<Mob_Stats>();
        //if it's a slime, make the background normal, disable the boss sprite and the enemy images all slimes.
        //If it's a boss, make the background spooky, disable the enemy images, and set the boss sprite to the boss.
        if(Enemy.name.Contains("Slime"))
        {
            EC = Enemy.GetComponent<EnemyController>();
            Background.sprite = EC.SetBackground();
            BossImage.enabled = false;
            EnemyImages[0].enabled = EnemyImages[1].enabled = EnemyImages[2].enabled = true;
            EnemyImages[0].sprite = EnemyImages[1].sprite = EnemyImages[2].sprite = EC.SetBattleSprite();
        }
        else
        {
            BC = Enemy.GetComponent<BossController>();
            Background.sprite = BC.SetBackground();
            EnemyImages[0].enabled = EnemyImages[1].enabled = EnemyImages[2].enabled = false;
            BossImage.enabled = true;
            BossImage.sprite = BC.SetBattleSprite();           
        }
    }

    private void CombatStart()
    {
        //Debug.Log("Combat has Begun!");
        //Gets Slime to stop moving when combat starts
        if (EC != null)
        {
            EC.CancelInvoke();
        }
        PlayerStats = PS.StatReturn();
        MobStats = MS.StatReturn();
        MaxHP = PlayerStats[0];
        textbox.text = "A wild " + Enemy.name + " has appeared!";
    }

    /// <summary>
    /// Gets the Players input and starts the sequence. First it disables buttons, does the first action, then the second, then re-enables the buttons for the next turn
    /// </summary>
    /// <param name="choice">Button input is passed into this</param>
    public void GetInput(int choice)
    {
        Choice = choice;
        Debug.Log("Player Health: " + PlayerStats[0]);
        Debug.Log("Slime Health: " + MobStats[0]);
        foreach(Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }
        Invoke("ActionOne", 1.0f);
    }
    /// <summary>
    /// Checks who goes first, and if anyone died game over or victory respectively.
    /// </summary>
    private void ActionOne()
    {
        if (PlayerStats[6] >= MobStats[6])
        {
            PlayerActionAnnounce();
            if (MobStats[0] <= 0)
            {
                Invoke("Win", 1.0f);
            }
            else
            {
                Invoke("ActionTwo", 2.0f);
            }
        }
        else
        {
            MobActionAnnounce();
            if (PlayerStats[0] <= 0)
            {
                Invoke("Lose", 1.0f);
            }
            else
            {
                Invoke("ActionTwo", 2.0f);
            }
        }
    }
    /// <summary>
    /// Check who goes second, same rules apply from ActionOne()
    /// </summary>
    private void ActionTwo()
    {
        if (PlayerStats[6] >= MobStats[6])
        {
            MobActionAnnounce();
            if (PlayerStats[0] <= 0)
            {
                Invoke("Lose", 1.0f);
            }
        }
        else
        {
            PlayerActionAnnounce();
            if (MobStats[0] <= 0)
            {
                Invoke("Win", 1.0f);
            }
        }
        Invoke("ReEnableButtons", 1.0f);
    }
    private void ReEnableButtons()
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }
    /// <summary>
    /// Tells the Textbox to say what the player's doing
    /// </summary>
    private void PlayerActionAnnounce()
    {
        AttackInfo = PS.Attack(Choice);
        //Debug.Log(AttackInfo[0] + " " + AttackInfo[1] + " " + AttackInfo[2] + " " + AttackInfo[3] + " " + AttackInfo[4] + " " + AttackInfo[5]);
        ConvertAttack();
        //Debug.Log("Player uses " + AttackInfo[0]);
        textbox.text = "Player uses " + AttackInfo[0];
        Invoke("PlayerActionCommit", 1.0f);
    }
    /// <summary>
    /// Does what the player wants to do
    /// </summary>
    private void PlayerActionCommit()
    {
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
            //Debug.Log("Player does " + Damage + " damage.");
            textbox.text = "Player does " + Damage + " damage.";
        }
        else
        {
            PlayerStats[StatTarget] += Convert.ToInt32(PlayerStats[StatUsed] * Modifier);
        }
        if (PlayerStats[0] > MaxHP)
        {
            PlayerStats[0] = MaxHP;
        }
    }
    /// <summary>
    /// Tells the textbox to say what the mob's doing
    /// </summary>
    private void MobActionAnnounce()
    {
        AttackInfo = MS.Attack(0);
        ConvertAttack();
        //Debug.Log(Enemy.name + " uses " + AttackInfo[0]);
        textbox.text = Enemy.name + " uses " + AttackInfo[0];
        Invoke("MobActionCommit", 1.0f);
    }
    /// <summary>
    /// Does what the mob wants to do
    /// </summary>
    private void MobActionCommit()
    {
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
            //Debug.Log(Enemy.name + " does " + Damage + " damage.");
            textbox.text = Enemy.name + " does " + Damage + " damage.";
        }
        else
        {
            MobStats[StatTarget] += Convert.ToInt32(MobStats[StatUsed] * Modifier);
        }
    }

    private void Win()
    {
        textbox.text = "You win! You gained  " + MS.EXP + " experience points";
        Invoke("CombatEnd", 1.0f);
    }
    private void Lose()
    {
        textbox.text = "You have been defeated. You lose.";
        Invoke("GameOver", 1.0f);
    }
    /// <summary>
    /// Ends combat, disables enemy, and increases Player EXP
    /// </summary>
    private void CombatEnd()
    {
        if (Enemy.name.Contains("Slime"))
        {

        }
        else
        {
            BossCounter--;
        }
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

    public void FleeAnnounce()
    {
        textbox.text = "You ran away safely";
        Invoke("FleeCommit", 1.0f);
    }
    private void FleeCommit()
    {
        textbox.text = "";
        this.gameObject.SetActive(false);
        Enemy.GetComponent<BoxCollider2D>().enabled = false;
        isInCombat = false;
        PC2.InCombat = false;
        Invoke("ReEnableEnemy", 2.0f);
    }
    private void ReEnableEnemy()
    {
        Enemy.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
    /// <summary>
    /// Converts attackinfo into usable variables for actions
    /// </summary>
    private void ConvertAttack()
    {
        isAttack = (AttackInfo[1] == "true");
        StatUsed = Convert.ToInt16(AttackInfo[2]);
        StatTarget = Convert.ToInt16(AttackInfo[3]);
        Modifier = Convert.ToDouble(AttackInfo[4]);
        isPhys = (AttackInfo[5] == "true");
        Debug.Log("Attack Stats: " + AttackInfo[0] + "," + AttackInfo[1] + "," + AttackInfo[2] + "," + AttackInfo[3] + "," + AttackInfo[4] + "," + AttackInfo[5]);
    }
}
