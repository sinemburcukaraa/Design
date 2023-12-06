
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class PreviewSystem : MonoBehaviour
{
    [SerializeField]
    private float previewYOffset = 0.06f;

    [SerializeField]
    private GameObject cellIndicator;
    private GameObject previewObject;

    [SerializeField]
    private Material previewMaterialPrefab;
    private Material previewMaterialInstance;
    public ObjectPlacer objectPlacer;
    private Renderer cellIndicatorRenderer;
    public List<GameObject> nullObj = new List<GameObject>();
    private void Start()
    {
        previewMaterialInstance = new Material(previewMaterialPrefab);
        cellIndicator.SetActive(false);
        cellIndicatorRenderer = cellIndicator.GetComponentInChildren<Renderer>();
    }
    GameObject lastObj, newObj;
    public void StartShowingPlacementPreview(GameObject prefab, Vector2Int size)
    {
        print("StartShowingPlacementPreview");
        lastObj = newObj;
        listControl();
        previewObject = Instantiate(prefab);
        newObj = previewObject;
        PreparePreview(previewObject);
        PrepareCursor(size);
        cellIndicator.SetActive(true);
    }
    public void listControl()
    {
        if (lastObj != null)
        {
            if (!objectPlacer.placedGameObjects.Contains(lastObj))
            {
                if (nullObj.Count==0)
                {
                    nullObj.Add(lastObj);
                }
                else
                {
                    nullObj.RemoveAt(0);
                    nullObj.Add(lastObj);

                }
            }
        }
    }
    private void PrepareCursor(Vector2Int size)
    {
        if (size.x > 0 || size.y > 0)
        {
            cellIndicator.transform.localScale = new Vector3(size.x, 1, size.y);
            cellIndicatorRenderer.material.mainTextureScale = size;
        }
    }

    private void PreparePreview(GameObject previewObject)
    {
        Renderer[] renderers = previewObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = previewMaterialInstance;
            }
            renderer.materials = materials;
        }
    }

    public void StopShowingPreview()
    {
        cellIndicator.SetActive(false);
        previewObject.SetActive(false);
        //if (previewObject != null)
        //    Destroy(previewObject);
    }

    public void UpdatePosition(Vector3 position, bool validity)
    {
        if (previewObject != null)
        {
            MovePreview(position);
            ApplyFeedbackToPreview(validity, 0.5f);

        }

        MoveCursor(position);
        ApplyFeedbackToCursor(validity);
    }

    public void ApplyFeedbackToPreview(bool validity, float value)
    {
        Color c = validity ? Color.white : Color.red;

        c.a = value;
        previewMaterialInstance.color = c;
    }

    private void ApplyFeedbackToCursor(bool validity)
    {
        Color c = validity ? Color.white : Color.red;

        c.a = 0.5f;
        cellIndicatorRenderer.material.color = c;
    }

    private void MoveCursor(Vector3 position)
    {
        cellIndicator.transform.position = position;
    }

    private void MovePreview(Vector3 position)
    {
        previewObject.transform.position = new Vector3(
            position.x,
            position.y + previewYOffset,
            position.z);
    }

    internal void StartShowingRemovePreview()
    {
        cellIndicator.SetActive(true);
        PrepareCursor(Vector2Int.one);
        ApplyFeedbackToCursor(false);
    }
    internal void StartRelocateRemovePreview()
    {
        cellIndicator.SetActive(true);
        PrepareCursor(Vector2Int.one);
        ApplyFeedbackToCursor(true);
    }
}