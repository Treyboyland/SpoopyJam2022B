using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorPool : MonobehaviourPool<Meteor>
{
    [SerializeField]
    float spawnY;

    [SerializeField]
    Vector2 xRange;

    public void SpawnObject()
    {
        Vector2 pos = new Vector2(xRange.Random(), spawnY);
        var meteor = GetObject();

        meteor.transform.position = pos;
        meteor.gameObject.SetActive(true);
    }
}
