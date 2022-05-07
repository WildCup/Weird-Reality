using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IkilledSb : MonoBehaviour
{
    //killed text
    public Text killedText;
    public Animator anim;

    public static IkilledSb instance;

    public GameObject upgradePanel;
    public Text pointsText;
    //buttons
    public PlusButton precisionButton;
    public PlusButton speedButton;
    public PlusButton jumpButton;
    public PlusButton healthButton;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    public void OnKill(int kills)
    {
        if (kills == 0)
        {
            killedText.text = "";
            return;
        }
        killedText.text = "Killed: " + kills;
        anim.SetTrigger("Kill");
    }
    public void Nohting()
    {
        killedText.text = "";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            upgradePanel.SetActive(!upgradePanel.activeSelf);
            
            UpdateAllButtons();
        }
    }
    #region upgradeButtons
    public void UpgradePrecision()
    {
        PlayerStats.instance.precision++;
        PlayerStats.instance.points--;
    }
    public void UpgradeSpeed()
    {
        PlayerStats.instance.speed++;
        PlayerStats.instance.points--;
    }
    public void UpgradeJump()
    {
        PlayerStats.instance.jump++;
        PlayerStats.instance.points--;
    }
    public void UpgradeHealth()
    {
        PlayerStats.instance.health++;
        PlayerStats.instance.points--;
    }
    public void UpdateAllButtons()
    {
        precisionButton.UpdateUI();
        speedButton.UpdateUI();
        jumpButton.UpdateUI();
        healthButton.UpdateUI();
        pointsText.text = "points: " + PlayerStats.instance.points;
    }
    #endregion
}
