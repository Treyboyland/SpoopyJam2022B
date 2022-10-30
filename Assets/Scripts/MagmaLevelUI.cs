using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagmaLevelUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;

    [SerializeField]
    MagmaPool pool;

    [SerializeField]
    int low, medium;

    enum LastLevel
    {
        LOW, MEDIUM, HIGH
    }

    LastLevel lastLevel = LastLevel.LOW;


    // Start is called before the first frame update
    void Start()
    {
        SetText(lastLevel);
    }

    // Update is called once per frame
    void Update()
    {
        var current = GetCurrentLevel();
        if(current != lastLevel)
        {
            lastLevel = current;
            SetText(lastLevel);
        }
    }

    void SetText(LastLevel level)
    {
        switch (level)
        {
            case LastLevel.LOW:
                textBox.text = "Magma Level: Low";
                break;
            case LastLevel.MEDIUM:
                textBox.text = "Magma Level: Medium";
                break;
            case LastLevel.HIGH:
                textBox.text = "Magma Level: HIGH";
                break;
        }
    }

    LastLevel GetCurrentLevel()
    {
        int count = pool.ActiveCount;
        if (count < low)
        {
            return LastLevel.LOW;
        }
        if (count < medium)
        {
            return LastLevel.MEDIUM;
        }
        return LastLevel.HIGH;
    }
}
