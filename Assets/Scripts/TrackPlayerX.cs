using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerX : MonoBehaviour
{
    [SerializeField]
    Transform player;

    Vector3 offset;

    float fixedY;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
        fixedY = transform.position.y;
        offset.x = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = player.transform.position + offset;
        pos.y = fixedY;
        transform.position = pos;
    }
}
