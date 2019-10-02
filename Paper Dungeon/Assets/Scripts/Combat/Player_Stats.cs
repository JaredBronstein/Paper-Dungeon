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
            EXP = 0;
            EXPThreshold += EXPThreshold;
            //Used for new ability unlocks. Each case is a different level up
            switch (Level - 1)
            {
                case 1:
                    break;
                case 2:
                    AttackList[2] = "EXPLOSION,true,MAG,HP,5,false";
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
            }
            //This randomly upgrades the stats
            for (int i = 0; i <= Random.Range(1, 4); i++)
            {
                switch (Random.Range(1, 8))
                {
                    case 1:
                        HP += Random.Range(0, 4);
                        break;
                    case 2:
                        MP += Random.Range(0, 4);
                        break;
                    case 3:
                        ATK += Random.Range(0, 4);
                        break;
                    case 4:
                        DEF += Random.Range(0, 4);
                        break;
                    case 5:
                        MAG += Random.Range(0, 4);
                        break;
                    case 6:
                        WIS += Random.Range(0, 4);
                        break;
                    case 7:
                        SPD += Random.Range(0, 4);
                        break;
                }
            }
        }
    }

}
