using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class IndexControl : MonoBehaviour
{
    public ObjectPlacer objectPlacer;
    public int index;
    public string id;
    public bool used;
    public void usedControl()
    {
        UsedObjectControl.Instance.usedButton = this.GetComponent<Button>();
    }
    public void Start()
    {
        index = UsedObjectControl.Instance.scrollobj.IndexOf(this.transform);
    }

    private void Update()
    {
        if (!this.GetComponent<Button>().interactable)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public float ofset = 0.5f;
    public void click()
    {
        if (UsedObjectControl.Instance.scrollobj.Count > 0)
        {
            //this.transform.parent = null;
            //UsedObjectControl.Instance.scrollobj.Remove(this.transform);
            this.gameObject.GetComponent<Button>().interactable = false;
        }

        
    }
    
}