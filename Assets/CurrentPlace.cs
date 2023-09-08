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
            Debug.Log("temas");

            if (other.gameObject.GetComponent<ObjectManager>().id == id && other.gameObject.GetComponent<ObjectManager>().placed)
            {
                Debug.Log("temas" + id);
                CurrentPlaceManager.instance.CurrentPlaceScore++;
            }
        }
       
    }

  

}
