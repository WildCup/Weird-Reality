using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignPost : MonoBehaviour
{
    public GameObject panel;
    public GameObject arrow;
    public GameObject tutorial;
    Transform player;

    int shownStatus = 0;
    bool canShow = false;
    //typing
    public float typeDelay = 0.2f;
    public bool wantTutorial;
    public Text text;
    string fullMsg;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        fullMsg = text.text;
    }
    void Start()
    {
        panel.SetActive(false);
        arrow.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canShow)
        {
            switch (shownStatus)
            {
                case 0:
                    StartCoroutine(ShowText());
                    panel.SetActive(true);
                    arrow.SetActive(false);
                    if (wantTutorial)
                        tutorial.SetActive(false);
                    shownStatus = 1;
                    break;
                case 1:
                    text.text = fullMsg;
                    StopAllCoroutines();
                    shownStatus = 2;
                    break;
                case 2:
                    panel.SetActive(false);
                    shownStatus = 0;
                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        arrow.SetActive(true);
        canShow = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        panel.SetActive(false);
        arrow.SetActive(false);
        canShow = false;
    }
    //Typing
    IEnumerator ShowText()
    {
        for (int i = 0; i < fullMsg.Length; i++)
        {
            text.text = fullMsg.Substring(0, i + 1);
            yield return new WaitForSeconds(typeDelay);
        }
    }
}
