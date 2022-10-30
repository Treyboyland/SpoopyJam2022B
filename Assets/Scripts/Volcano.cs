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
    WeightedRandomizerSO weights;


    float elapsed = 0;

    float timeUntilNextAnamoly;

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
        elapsed += Time.deltaTime;
        shake.ShouldShake = elapsed / timeUntilNextAnamoly > progressRumble;
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
    }
}
