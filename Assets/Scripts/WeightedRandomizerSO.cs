using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weighted Random", menuName = "Game/Weighted Random")]
public class WeightedRandomizerSO : ScriptableObject
{
    [SerializeField]
    List<AnamolySO> choices;
    

    public AnamolySO Choose()
    {
        int total = 0;
        foreach(var x in choices)
        {
            total += x.Weight;
        }

        int randomTotal = Random.Range(0, total);
        int current = 0;
        foreach(var x in choices)
        {
            current += x.Weight;
            if(randomTotal < current)
            {
                return x;
            }
        }

        return choices[^1];
    }
}
