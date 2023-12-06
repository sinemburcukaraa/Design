using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlace : MonoBehaviour
{

    public string id;
    public GameObject selectedObj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obj")
        {

            if (other.gameObject.GetComponent<ObjectManager>().id == id && other.gameObject.GetComponent<ObjectManager>().placed)
            {
                CurrentPlaceManager.instance.CurrentPlaceScore++;
                selectedObj = other.gameObject;

            }
        }

    }
    public void RemoveCountControl()
    {
        if (selectedObj != null)
        {
            if (!selectedObj.activeInHierarchy) { print("exit;"); }

        }
    }
    private void OnTriggerExit(Collider other)
    {
       

    }
}
