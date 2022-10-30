using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaPool : MonobehaviourPool<Magma>
{
    public void Spawn(Vector2 pos)
    {
        var magma = GetObject();
        magma.transform.position = pos;
        magma.gameObject.SetActive(true);
    }
}
