using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusButton : MonoBehaviour
{
    public int lvl;
    public Text lvlText;
    public Text actualBonusText;
    public Text newBonudText;
    public Slider slider;
    public Button button;
    public Text nameText;
    public enum buttonsStats { Precision, Speed, Jump, Health};
    public buttonsStats myStat;

    void Start()
    {
        UpdateUI();
    }
    public void UpdateUI()
    {
        switch (myStat)
        {
            case buttonsStats.Precision:
                lvl = PlayerStats.instance.precision;
                break;
            case buttonsStats.Speed:
                lvl = PlayerStats.instance.speed;
                break;
            case buttonsStats.Jump:
                lvl = PlayerStats.instance.jump;
                break;
            case buttonsStats.Health:
                lvl = PlayerStats.instance.health;
                break;
        }
        lvlText.text = "lvl " + lvl;
        actualBonusText.text = (lvl * 5f).ToString() + "%";
        newBonudText.text = ((lvl + 1) * 5).ToString() + "%";
        if (lvl * 5 >= 100)
            newBonudText.text = "MAX";
        slider.value = lvl;

        if (PlayerStats.instance.points == 0)
            button.interactable = false;
        else button.interactable = true;
    }
}
