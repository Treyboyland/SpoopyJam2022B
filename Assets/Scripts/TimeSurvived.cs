using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeSurvived : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;

    float elapsed;

    public bool ShouldCount { get; private set; } = true;

    private void Start()
    {
        GameManager.Manager.OnGameOver.AddListener(() => ShouldCount = false);
    }

    // Update is called once per frame
    void Update()
    {
        if(ShouldCount)
        {
            elapsed += Time.deltaTime;
            SetText();
        }
    }

    void SetText()
    {
        int seconds = (int)elapsed;
        int milliseconds = (int)((elapsed % 1) * 1000);
        TimeSpan ts = new TimeSpan(0, 0, 0, seconds, milliseconds);
        text.text = "Time: " + ts.ToString("m\\:ss\\.f");
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("SurvivalTime", elapsed);
        PlayerPrefs.Save();
    }
}
