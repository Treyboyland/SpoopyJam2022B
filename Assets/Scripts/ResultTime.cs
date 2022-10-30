using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ResultTime : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;

    float elapsed;

    // Start is called before the first frame update
    void Start()
    {
        elapsed = PlayerPrefs.GetFloat("SurvivalTime", 0);
        SetTime();
    }

    void SetTime()
    {
        int seconds = (int)elapsed;
        int milliseconds = (int)((elapsed % 1) * 1000);
        TimeSpan ts = new TimeSpan(0, 0, 0, seconds, milliseconds);
        text.text = "Your Time:\r\n" + ts.ToString("m\\:ss\\.f");
    }
}
