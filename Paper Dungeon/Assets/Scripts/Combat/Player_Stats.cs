using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : Mob_Stats
{
    [SerializeField]
    [Tooltip("The Level of a Character")]
    private int Level = 1;
    [SerializeField]
    [Tooltip("Amount of EXP required to level up. Defaults for Level 2")]
    private int EXPThreshold;

    private void Awake()
    {
        AttackList[0] = "Snip,true,2,0,1,true";
        AttackList[1] = "Crumple,true,4,3,1,false";
        AttackList[2] = "Tear,true,6,0,1.1,true";
        AttackList[3] = "Fold,false,3,0,1,NA";
        AttackList[4] = "Ink Splot,true,4,0,2,false";
    }

    private void Update()
    {
        if(EXP >= EXPThreshold)
        {
            LevelUp();
        }
    }
    /// <summary>
    /// When called, levels up the player by increasing level by 1 and setting EXP to zero and setting the new EXP threshold for leveling
    /// Also randomly upgrades up to 3 stats by a maximum of 4 and, if the correct level is met adds a new ability to the attack list
    /// </summary>
    private void LevelUp()
    {
        if(Level < 10)
        {
            Level += 1;
            Debug.Log("Player has reached level " + Level);
            EXP -= EXPThreshold;
            EXPThreshold += EXPThreshold;
            //Used for new ability and stat unlocks. Each case is a different level up
            switch (Level - 1)
            {
                case 1:
                    HP += 2;
                    ATK += 1;
                    MAG += 1;
                    SPD += 1;
                    break;
                case 2:
                    HP += 3;
                    ATK += 1;
                    WIS += 1;
                    SPD += 1;
                    break;
                case 3:
                    ATK += 2;
                    DEF += 1;
                    MAG += 1;
                    WIS += 1;
                    break;
                case 4:
                    HP += 5;
                    DEF += 2;
                    SPD += 3;
                    break;
                case 5:
                    ATK += 2;
                    MAG += 5;
                    WIS += 2;
                    break;
                case 6:
                    HP += 5;
                    ATK += 3;
                    DEF += 3;
                    WIS += 2;
                    SPD += 1;
                    break;
                case 7:
                    ATK += 3;
                    MAG += 6;
                    WIS += 2;
                    break;
                case 8:
                    HP += 5;
                    ATK += 3;
                    SPD += 2;
                    break;
                case 9:
                    HP += 5;
                    ATK += 5;
                    DEF += 3;
                    MAG += 7;
                    WIS += 2;
                    SPD += 2;
                    break;
            }
        }
    }

}
