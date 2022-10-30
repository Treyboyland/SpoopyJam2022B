using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    [SerializeField]
    Transform playerPos;

    float zPosition;

    // Start is called before the first frame update
    void Start()
    {
        zPosition = transform.position.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var pos = playerPos.transform.position;
        pos.z = zPosition;
        transform.position = pos;
    }
}
