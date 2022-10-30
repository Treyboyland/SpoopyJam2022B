using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSpeed : MonoBehaviour
{
    [SerializeField]
    Vector2 speed;

    [SerializeField]
    Vector2Int multiplierRange;

    float multiplier;

    private void OnEnable()
    {
        multiplier = multiplierRange.Random();
        Debug.LogWarning(multiplier);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += multiplier * Time.deltaTime * (Vector3)speed;
    }
}
