using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsedObjectControl : MonoBehaviour
{
    public List<Transform> scrollobj = new List<Transform>();
    public static UsedObjectControl Instance;
    public Vector3 startPos;
    public Button usedButton; public PreviewSystem previewSystem;
    public ObjectPlacer objectPlacer;
    private void Start()
    {
        startPos = scrollobj[0].transform.position;
    }
    private void Awake()
    {
        if (Instance == null) { Instance = this; }


        for (int i = 0; i < this.transform.childCount; i++)
        {
            scrollobj.Add(this.transform.GetChild(i).transform);
        }
    }
    string objId;
    public void click()
    {
        if (previewSystem.nullObj.Count > 0)
        {
            objId = previewSystem.nullObj[0].transform.GetChild(0).GetComponent<ObjectManager>().id;
            for (int i = 0; i < scrollobj.Count; i++)
            {
                if (scrollobj[i].GetComponent<IndexControl>().id == objId)
                {
                    if (placed() == false)
                    {
                        scrollobj[i].GetComponent<Button>().interactable = true;

                    }
                    previewSystem.nullObj.RemoveAt(0);

                }
            }

        }
    }
  
    public bool control;

    public bool placed()
    {
        control = false; // control deðiþkenini baþlangýçta false olarak ayarla

        for (int i = 0; i < objectPlacer.placedGameObjects.Count; i++)
        {
            print("place" + objectPlacer.placedGameObjects[i].transform.GetChild(0).GetComponent<ObjectManager>().id);
            print(objId);
            if (objectPlacer.placedGameObjects[i].transform.GetChild(0).GetComponent<ObjectManager>().id == objId)
            {
                print("girdi");
                control = true;
                break;
            }
        }
        print("çýktý");
        return control;
    }
    //public void TransformController()
    //{
    //    float offset = 0.5f;
    //    for (int i = 0;i < scrollobj.Count;i++)
    //    {
    //        scrollobj[i].transform.position=startPos + scrollobj[]
    //    }
    //}
}
