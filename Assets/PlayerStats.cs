using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public int lvl = 1;
    public int points = 0;
    public float totalExp;
    public int killed = 0;
    //stats
    public int precision = 0;
    public int speed = 0;
    public int jump = 0;
    public int health = 0;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
    private void Start()
    {
        PlayerData data = SaveLoad.Load();
        lvl = data.lvl;
        points = data.points;
        totalExp = data.exp;
        killed = data.killed;
        GameManager.instance.maxLevel = data.maxLvl;
        //stats
        precision = data.precision;
        speed = data.speed;
        jump = data.jump;
        health = data.health;
    }
    public bool EarnExp(float exp)
    {
        //1 -> 10
        //2 -> 20
        //3 -> 40
        killed++;
        IkilledSb.instance.OnKill(killed);

        totalExp += exp;
        float expToNextLvl = 10 * Mathf.Pow(2, lvl - 1);
        if (totalExp >= expToNextLvl)
        {
            totalExp -= expToNextLvl;
            lvl++;
            points++;
            AudioManager.instance.Play("LvlUp");
            return true;
        }
        return false;
    }
}
