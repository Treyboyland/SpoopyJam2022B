using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField]
    string sceneToLoad;

    [SerializeField]
    float secondsToWait;

    bool endingGame = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Manager.OnGameOver.AddListener(EndGame);
    }

    void EndGame()
    {
        if(!endingGame)
        {
            endingGame = true;
            StartCoroutine(EndGameRoutine());
        }
    }
    
    IEnumerator EndGameRoutine()
    {
        yield return new WaitForSeconds(secondsToWait);
        SceneManager.LoadScene(sceneToLoad);
    }
}
