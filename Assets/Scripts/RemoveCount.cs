using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCount : MonoBehaviour
{
   public  List<int> count = new List<int>();
    void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            count.Add(i);
        }
    }
}
