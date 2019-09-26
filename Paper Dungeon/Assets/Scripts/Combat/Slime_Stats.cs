using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Stats : Mob_Stats
{
    public Slime_Stats(int hp, int mp, int atk, int def, int mag, int wis, int spd)
    {
        HP = hp;
        MP = mp;
        ATK = atk;
        DEF = def;
        MAG = mag;
        WIS = wis;
        SPD = spd;
    }
    public override int Attack()
    {
        return (int)(ATK * 0.75);
    }
}
