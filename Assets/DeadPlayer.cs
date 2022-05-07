using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.Play("GameOver");
        StartCoroutine(ResetLvl());
    }
    IEnumerator ResetLvl()
    {
        Time.timeScale = 0.15f;
        yield return new WaitForSeconds(0.25f);
        Time.timeScale = 1f;
        GameManager.instance.ResetLvl();
    }
}
