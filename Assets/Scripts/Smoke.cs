using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public float YPosition { get; set; }

    public Magma MagmaToTrack { get; set; }

    // Update is called once per frame
    void Update()
    {
        CheckActive();
        CheckPosition();
    }

    private void OnDisable()
    {
        MagmaToTrack = null;
    }

    void CheckActive()
    {
        if (MagmaToTrack != null)
        {
            gameObject.SetActive(MagmaToTrack.gameObject.activeInHierarchy);
        }
    }

    void CheckPosition()
    {
        if (MagmaToTrack != null)
        {
            var currentPos = transform.position;
            var magmaPos = MagmaToTrack.transform.position;
            magmaPos.y = YPosition;

            if(currentPos != magmaPos)
            {
                transform.position = magmaPos;
            }
        }
    }
}
