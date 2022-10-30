using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokePool : MonobehaviourPool<Smoke>
{
    [SerializeField]
    float ySpawn;

    public void SpawnSmoke(Magma magmaLocation)
    {
        var smoke = GetObject();
        var pos = magmaLocation.transform.position;
        pos.y = ySpawn;
        smoke.transform.position = pos;
        smoke.YPosition = ySpawn;
        smoke.MagmaToTrack = magmaLocation;
        smoke.gameObject.SetActive(true);
    }
}
