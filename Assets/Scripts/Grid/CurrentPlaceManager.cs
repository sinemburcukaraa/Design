using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlaceManager : MonoBehaviour
{
    public float CurrentPlaceScore;
    public float CurrentPlaceCount = 10;
    public static CurrentPlaceManager instance;
    private void Awake()
    {
        if (instance == null ) { instance = this; }
    }
    public float CurrentPlaceScoreCalculate() 
    {
        float score = CurrentPlaceScore / CurrentPlaceCount;
        return score;
    }

}
