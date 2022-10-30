using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    private void OnEnable()
    {
        Randomize();
    }

    void SetRotation()
    {
        float rotation = Random.Range(0, 360.0f);

        var rotationQuaternion = Quaternion.Euler(0, 0, rotation);

        transform.rotation = rotationQuaternion;
    }

    public void Randomize()
    {
        SetRotation();
    }
}
