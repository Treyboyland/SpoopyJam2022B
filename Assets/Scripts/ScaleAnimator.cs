using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimator : MonoBehaviour
{
    [SerializeField]
    AnimationCurve curve;

    [SerializeField]
    float secondsToAnimate;

    bool scaleSet = false;

    Vector3 originalScale;

    public bool IsAnimating { get; private set; } = false;

    private void OnEnable()
    {
        if(!scaleSet)
        {
            scaleSet = true;
            originalScale = transform.localScale;
        }
        transform.localScale = originalScale;
    }

    public void Animate()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(Animation());
        }
    }

    IEnumerator Animation()
    {
        float elapsed = 0;
        IsAnimating = true;

        while (elapsed < secondsToAnimate)
        {
            elapsed += Time.deltaTime;
            float scaleVal = curve.Evaluate(elapsed / secondsToAnimate);
            transform.localScale = originalScale * scaleVal;
            yield return null;
        }

        IsAnimating = false;
        gameObject.SetActive(false);
    }
}
