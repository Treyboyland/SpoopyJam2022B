using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Anamoly", menuName = "Game/Anamoly")]
public class AnamolySO : ScriptableObject
{
    [SerializeField]
    string anamolyName;

    public string AnamolyName { get => anamolyName; }

    [SerializeField]
    int weight;

    public int Weight { get => weight; }
}
