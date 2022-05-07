using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int maxLevel;
    GameObject warningPanel;
    Button continueButton;

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
        maxLevel = PlayerPrefs.GetInt("lvl", 1);
    }
    private void Start()
    {
        IkilledSb.instance.Nohting();
        warningPanel = GameObject.Find("WarningPanel");
        continueButton = GameObject.Find("ContinueButton").GetComponent<Button>();
        if (maxLevel == 1) continueButton.interactable = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            GoToLvl(SceneManager.GetActiveScene().buildIndex);
        if (Input.GetKeyDown(KeyCode.Escape))
            if (SceneManager.GetActiveScene().buildIndex != 0)
                GoToLvl(0);
            else ExitButton();
        if (Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().buildIndex == 0)
            AudioManager.instance.Play("Click");
        if (Input.GetKeyDown(KeyCode.S))
            Save();
    }
    public void GoToLvl(int i)
    {
        maxLevel = Mathf.Max(maxLevel, i);
        if (i == 0)
        {
            IkilledSb.instance.Nohting();
            warningPanel = GameObject.Find("WarningPanel");
            continueButton = GameObject.Find("ContinueButton").GetComponent<Button>();
            if (maxLevel == 1) continueButton.interactable = false;
            
        }
        SceneManager.LoadScene(i);
    }
    public void GoToNextLevel()
    { 
        GoToLvl(SceneManager.GetActiveScene().buildIndex + 1);
    }
    #region ALL_BUTTONS
    public void PlayButton()
    {
        if (maxLevel > 2)
            warningPanel.SetActive(true);
        else YesIWantToPlay();
    }
    public void YesIWantToPlay()
    {
        SaveLoad.DeleteProgress();
        maxLevel = 1;
        GoToLvl(1);
    }
    public void NoIChangeMyMind()
    {
        warningPanel.SetActive(false);
    }
    public void ContinueButton()
    {
        GoToLvl(maxLevel);
    }
    public void ExitButton()
    {
        Save();
        Application.Quit();
    }
    public void MenuButton()
    {
        GoToLvl(0);
    }
    #endregion
    public void ResetLvl()
    {
        GoToLvl(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnApplicationQuit()
    {
        Save();
    }
    void Save()
    {
        SaveLoad.Save(PlayerStats.instance);
    }
}
