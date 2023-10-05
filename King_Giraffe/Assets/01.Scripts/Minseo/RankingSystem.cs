using System;
using System.Collections.Generic;
using UnityEngine;

public class RankingSystem : MonoBehaviour
{
    private List<string> usedID = new List<string>();

    public string AutomaticID()
    {
        string id;
        do
        {
            id = "Giraffe" + UnityEngine.Random.Range(0, 10000).ToString();
        } while (usedID.Contains(id));

        return id;
    }


}
