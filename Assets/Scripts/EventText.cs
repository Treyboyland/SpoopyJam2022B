using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventText : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;



    // Start is called before the first frame update
    void Start()
    {
        GameManager.Manager.OnShakeSound.AddListener(SoonText);
        GameManager.Manager.OnAnamolyChosen.AddListener(EventChosen);
        textBox.text = "";
    }

    void SoonText()
    {
        StopAllCoroutines();
        textBox.text = "Event Imminent";
    }

    void EventChosen(AnamolySO anamoly)
    {
        StartCoroutine(ShowText(anamoly));
    }

    IEnumerator ShowText(AnamolySO anamoly)
    {
        textBox.text = anamoly.AnamolyName + " Event!";
        yield return new WaitForSeconds(5.0f);
        textBox.text = "";
    }
}
