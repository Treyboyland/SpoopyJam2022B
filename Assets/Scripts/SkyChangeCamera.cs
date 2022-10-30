using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyChangeCamera : MonoBehaviour
{
    [SerializeField]
    List<Camera> cameras;

    [SerializeField]
    Gradient gradient;

    [Range(0, 1), SerializeField]
    float skyValue;

    public float SkyValue { get => skyValue; set => skyValue = value; }

    // Update is called once per frame
    void Update()
    {
        SetColor(gradient.Evaluate(skyValue));
    }

    void SetColor(Color c)
    {
        foreach (var camera in cameras)
        {
            camera.backgroundColor = c;
        }
    }
}
