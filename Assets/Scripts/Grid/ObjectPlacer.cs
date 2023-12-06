using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> placedGameObjects = new List<GameObject>();
    public InputManager inputManager; public PlacementSystem placementSystem; public PreviewSystem previewSystem; int scroolObjCount;
    public List<GameObject> CopyButtonList = new List<GameObject>();
    private void Start()
    {
        scroolObjCount = UsedObjectControl.Instance.scrollobj.Count;
        for (int i = 0; i < UsedObjectControl.Instance.scrollobj.Count; i++)
        {
            CopyButtonList.Add(UsedObjectControl.Instance.scrollobj[i].gameObject);
        }
    }
    public int PlaceObject(GameObject prefab, Vector3 position)
    {
        if (!IsPrefabInList(prefab))
        {
            GameObject newObject = Instantiate(prefab);
            newObject.transform.position = position;
            newObject.transform.GetChild(0).GetComponent<ObjectManager>().placed = true;
            placedGameObjects.Add(newObject);
            placementSystem.StopPlacement();

            CompletedPlacedObject();
        }
        return placedGameObjects.Count - 1;
    }

    private bool IsPrefabInList(GameObject prefab)
    {
        foreach (GameObject obj in placedGameObjects)
        {
            if (obj == prefab)
            {
                return true;
            }
        }
        return false;
    }
    internal void RemoveObjectAt(int gameObjectIndex)
    {
        if (placedGameObjects.Count <= gameObjectIndex
            || placedGameObjects[gameObjectIndex] == null)
            return;
        //int index = UsedObjectControl.Instance.scrollobj.IndexOf(placedGameObjects[gameObjectIndex].transform);
        //UsedObjectControl.Instance.scrollobj[index].transform.GetComponent<Button>().inte
        FindButton(placedGameObjects[gameObjectIndex]);
        Destroy(placedGameObjects[gameObjectIndex]);
        placedGameObjects.RemoveAt(gameObjectIndex);
        //placedGameObjects[gameObjectIndex] = null;
    }

    public void FindButton(GameObject selectedObj)
    {
        for (int i = 0; i < scroolObjCount; i++)
        {
            if (CopyButtonList[i].GetComponent<IndexControl>().id == selectedObj.transform.GetChild(0).GetComponent<ObjectManager>().id)
            {
                UsedObjectControl.Instance.scrollobj[i].GetComponent<UnityEngine.UI.Button>().interactable = true;
            }
        }
    }
    public void CompletedPlacedObject()
    {
        for(int i = 0; i < scroolObjCount; i++)
        {
            if (UsedObjectControl.Instance.scrollobj[i].GetComponent<UnityEngine.UI.Button>().interactable)
            {
                break;
            }
            else
            {
                if (placedGameObjects.Count == scroolObjCount)
                {
                    GameManager.instance.Win();
                    break;
                }

            }
        }
    }
    //internal void RemoveRelocate(int gameObjectIndex)
    //{
    //    if (placedGameObjects.Count <= gameObjectIndex
    //        || placedGameObjects[gameObjectIndex] == null)
    //        return;
    //    Destroy(placedGameObjects[gameObjectIndex]);
    //    placedGameObjects[gameObjectIndex] = null;
    //    previewSystem.ApplyFeedbackToPreview(true, 1);
    //    placementSystem.StartPlacement(gameObjectIndex);

    //    Debug.Log("girdi");
    //}

}
