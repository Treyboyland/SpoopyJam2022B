using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyChangeCamera : MonoBehaviour
{
    [SerializeField]
    List<Camera> cameras;

    [SerializeField]
    Gradient gradient;

    [SerializeField]
    Ground ground;

    [SerializeField]
    float secondsToAnimate;

    [Range(0, 1), SerializeField]
    float skyValue;

    public float SkyValue { get => skyValue; set => skyValue = value; }

    private void Start()
    {
        GameManager.Manager.OnGroundHitSound.AddListener(MoveSky);
        SetColor(gradient.Evaluate(1 - skyValue));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetColor(Color c)
    {
        foreach (var camera in cameras)
        {
            camera.backgroundColor = c;
        }
    }

    void MoveSky()
    {
        StopAllCoroutines();
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        float newVal = 1.0f * ground.CurrentLife / ground.MaxLife;

        float currentVal = SkyValue;

        float elapsed = 0;

        while (elapsed < secondsToAnimate)
        {
            elapsed += Time.deltaTime;
            skyValue = Mathf.Lerp(currentVal, newVal, elapsed / secondsToAnimate);
            SetColor(gradient.Evaluate(1 - skyValue));
            yield return null;
        }

        skyValue = newVal;
        SetColor(gradient.Evaluate(1 - skyValue));
    }
}
