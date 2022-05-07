using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class START : MonoBehaviour
{
    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;

        Debug.Log("Application.targetFrameRate is set to 60");
    }

}
