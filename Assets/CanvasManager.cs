using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public void PlayButton()
    {
        GameManager.instance.PlayButton();
    }
    public void ContinueButton()
    {
        GameManager.instance.ContinueButton();
    }
    public void ExitButton()
    {
        GameManager.instance.ExitButton();
    }
    public void MenuButton()
    {
        GameManager.instance.MenuButton();
    }
}
