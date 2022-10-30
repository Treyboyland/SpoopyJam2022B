using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPool : MonobehaviourPool<GroundTrigger>
{
    [SerializeField]
    Player player;

    // Update is called once per frame
    void Update()
    {
        if (player.InGround && !GroundTrigger.WithinTrigger)
        {
            //Debug.LogWarning("In ground: " + player.InGround + " Within: " + GroundTrigger.WithinTrigger + "(" + GroundTrigger.Count + ")");
            Spawn();
        }
    }

    void Spawn()
    {
        var ground = GetObject();
        ground.transform.position = player.transform.position;
        ground.gameObject.SetActive(true);
    }

    public void ResetAll()
    {
        foreach(var obj in pool)
        {
            if(obj.gameObject.activeInHierarchy)
            {
                obj.Animate();
            }
        }
    }
}
