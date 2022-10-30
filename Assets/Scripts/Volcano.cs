using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano : MonoBehaviour
{
    [SerializeField]
    Shake shake;

    [Range(0, 1)]
    [SerializeField]
    float progressRumble;

    [SerializeField]
    Vector2 secondsBetweenAnamolies;

    [Header("Anamolies")]
    [SerializeField]
    AnamolySO fill, magma, meteor, all, death;

    [SerializeField]
    AnimationCurve multiplier;

    [SerializeField]
    MagmaPool magmaPool;


    [SerializeField]
    WeightedRandomizerSO weights;


    float elapsed = 0;
    float currentMultiplier = 1;

    float timeUntilNextAnamoly;
    bool lastShakeState = false;

    // Start is called before the first frame update
    void Start()
    {
        timeUntilNextAnamoly = secondsBetweenAnamolies.Random();
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseTime();
        DoAnamoly();
    }

    void IncreaseTime()
    {
        currentMultiplier = multiplier.Evaluate(magmaPool.ActiveCount);
        elapsed += (Time.deltaTime * currentMultiplier);
        shake.ShouldShake = elapsed / timeUntilNextAnamoly > progressRumble;

        if(lastShakeState != shake.ShouldShake && shake.ShouldShake)
        {
            lastShakeState = true;
            GameManager.Manager.OnShakeSound.Invoke();
        }
        else if(lastShakeState != shake.ShouldShake)
        {
            lastShakeState = shake.ShouldShake;
        }
    }

    void DoAnamoly()
    {
        if (elapsed >= timeUntilNextAnamoly)
        {
            Debug.LogWarning("Anamoly");
            elapsed = 0;
            timeUntilNextAnamoly = secondsBetweenAnamolies.Random();
            DoRandomAnamoly();
        }
    }

    void DoRandomAnamoly()
    {
        var chosen = weights.Choose();

        Debug.LogWarning(chosen.AnamolyName);
        if (chosen.AnamolyName == fill.AnamolyName)
        {
            GameManager.Manager.OnFillAnamoly.Invoke();
        }
        else if (chosen.AnamolyName == magma.AnamolyName)
        {
            GameManager.Manager.OnMagmaAnamoly.Invoke();
        }
        else if (chosen.AnamolyName == meteor.AnamolyName)
        {
            GameManager.Manager.OnMeteorAnamoly.Invoke();
        }
        else if (chosen.AnamolyName == all.AnamolyName)
        {
            GameManager.Manager.OnAllAnamoly.Invoke();
        }
        else if (chosen.AnamolyName == death.AnamolyName)
        {
            GameManager.Manager.OnDeathAnamoly.Invoke();
        }

        GameManager.Manager.OnAnamolyChosen.Invoke(chosen);
    }
}
