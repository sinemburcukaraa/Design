using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlaceManager : MonoBehaviour
{
    public float CurrentPlaceScore;
    public float CurrentPlaceCount;
    public static CurrentPlaceManager instance;
    private void Awake()
    {
        if (instance == null ) { instance = this; }
    }
    public float CurrentPlaceScoreCalculate() 
    {
        float score = (float)CurrentPlaceScore / CurrentPlaceCount; // 45 adet doðru alaný varsayalým
        Debug.Log(CurrentPlaceScore);
        Debug.Log(score);
        return score;
    }

}
