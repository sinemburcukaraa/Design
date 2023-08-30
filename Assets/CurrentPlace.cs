using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlace : MonoBehaviour
{

    public string id;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obj")
        {
            if (other.gameObject.GetComponent<ObjectManager>().id == id && other.gameObject.GetComponent<ObjectManager>().placed)
            {
                CurrentPlaceManager.instance.CurrentPlaceScore++;
            }
        }
       
    }

  

}
