using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyChange : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sprite;

    [SerializeField]
    Gradient gradient;

    [Range(0, 1), SerializeField]
    float skyValue;

    public float SkyValue { get => skyValue; set => skyValue = value; }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sprite.color = gradient.Evaluate(skyValue);
    }
}
