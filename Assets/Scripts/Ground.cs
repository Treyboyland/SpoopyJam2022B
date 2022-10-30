using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sprite;

    [SerializeField]
    float secondsToChange;

    [SerializeField]
    List<Color> groundColors;

    int currentLife;

    public int CurrentLife { get => currentLife; }

    public int MaxLife { get; private set; }

    private void Start()
    {
        GameManager.Manager.OnGroundHit.AddListener(() => SetLife(CurrentLife - 1));
        GameManager.Manager.OnInstantDie.AddListener(() => SetLife(0));
    }

    private void OnEnable()
    {
        MaxLife = groundColors.Count;
        currentLife = groundColors.Count;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.InGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.InGround = false;
        }
    }

    public void SetLife(int life)
    {
        if(life < 0 )
        {
            life = 0;
        }
        if(life > groundColors.Count)
        {
            life = groundColors.Count;
        }

        if(life != currentLife)
        {
            currentLife = life;
            StopAllCoroutines();
            StartCoroutine(LerpToNewColor(groundColors[currentLife]));
        }

        if(life <= 0)
        {
            GameManager.Manager.OnGameOver.Invoke();
        }
    }

    IEnumerator LerpToNewColor(Color color)
    {
        Color start = sprite.color;
        float elapsed = 0; 
        while(elapsed < secondsToChange)
        {
            elapsed += Time.deltaTime;
            sprite.color = Color.Lerp(start, color, elapsed / secondsToChange);
            yield return null;
        }

        sprite.color = color;
    }
}
