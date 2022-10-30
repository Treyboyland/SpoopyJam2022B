using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    [SerializeField]
    ScaleAnimator animator;

    static int count;

    public static int Count { get => count; }

    public static bool WithinTrigger { get { return count > 0; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.LogWarning("Hit");
        var player = collision.gameObject.GetComponent<Player>();

        if(player != null)
        {
            //Debug.LogWarning("Add");
            count++;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (player != null && count < 0)
        {
            count = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if(player != null)
        {
            count--;
        }
    }

    public void Animate()
    {
        animator.Animate();
    }
}
