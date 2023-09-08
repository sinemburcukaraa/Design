using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> placedGameObjects = new List<GameObject>();
    public InputManager inputManager; public PlacementSystem placementSystem; public PreviewSystem previewSystem;
    public int PlaceObject(GameObject prefab, Vector3 position)
    {
        GameObject newObject = Instantiate(prefab);
        newObject.transform.position = position;
        newObject.transform.GetChild(0).GetComponent<ObjectManager>().placed = true;
        placedGameObjects.Add(newObject);
        return placedGameObjects.Count - 1;
    }

    internal void RemoveObjectAt(int gameObjectIndex)
    {
        if (placedGameObjects.Count <= gameObjectIndex
            || placedGameObjects[gameObjectIndex] == null)
            return;
        Destroy(placedGameObjects[gameObjectIndex]);
        placedGameObjects[gameObjectIndex] = null;
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
