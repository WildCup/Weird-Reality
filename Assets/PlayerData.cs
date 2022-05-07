using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int lvl;
    public int points;
    public float exp;
    public int killed;
    public int maxLvl;
    //stats
    public int precision;
    public int speed;
    public int jump;
    public int health;

    public PlayerData(PlayerStats p)
    {
        lvl = p.lvl;
        points = p.points;
        exp = p.totalExp;
        killed = p.killed;
        maxLvl = GameManager.instance.maxLevel;
        //stats
        precision = p.precision;
        speed = p.speed;
        jump = p.jump;
        health = p.health;
    }
}
