using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{


    [SerializeField]
    float randomDiff;

    [SerializeField]
    bool shouldShake;

    public bool ShouldShake { get => shouldShake; set => shouldShake = value; }

    Vector3 initialPos;


    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldShake)
        {
            //Debug.LogWarning("Shake");
            transform.position = initialPos + (Vector3)randomDiff.RandomVector2();
        }
        else
        {
            transform.position = initialPos;
        }
    }
}
