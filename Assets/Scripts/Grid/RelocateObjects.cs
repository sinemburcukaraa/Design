using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelocateObjects : IBuildingState
{
    private int gameObjectIndex = -1;
    Grid grid;
    PreviewSystem previewSystem;
    GridData floorData;
    GridData furnitureData;
    ObjectPlacer objectPlacer;
    SoundFeedback soundFeedback;

    public RelocateObjects(Grid grid,
                         PreviewSystem previewSystem,
                         GridData floorData,
                         GridData furnitureData,
                         ObjectPlacer objectPlacer,
                         SoundFeedback soundFeedback)
    {
        this.grid = grid;
        this.previewSystem = previewSystem;
        this.floorData = floorData;
        this.furnitureData = furnitureData;
        this.objectPlacer = objectPlacer;
        this.soundFeedback = soundFeedback;
        previewSystem.StartRelocateRemovePreview();
    }

    public void EndState()
    {
        previewSystem.StopShowingPreview();
    }

    public void OnAction(Vector3Int gridPosition)
    {
        GridData selectedData = null;
        //if (furnitureData.CanPlaceObejctAt(gridPosition, Vector2Int.one) == false)
        //{
        //    selectedData = furnitureData;
        //}
        //else if (floorData.CanPlaceObejctAt(gridPosition, Vector2Int.one) == false)
        //{
        //    selectedData = floorData;
        //}

        //if (selectedData == null)
        //{
        //    //sound

        //    soundFeedback.PlaySound(SoundType.relocate);
        //    gameObjectIndex = -1;
        //}
        //else
        //{
        //    soundFeedback.PlaySound(SoundType.Remove);
        //    gameObjectIndex = selectedData.GetRepresentationIndex(gridPosition);
        //    if (gameObjectIndex == -1)
        //        return;
        //    selectedData.RemoveObjectAt(gridPosition);
        //    objectPlacer.RemoveRelocate(gameObjectIndex);
        //}
        //Vector3 cellPosition = grid.CellToWorld(gridPosition);
        //previewSystem.UpdatePosition(cellPosition, CheckIfSelectionIsValid(gridPosition));
    }

    private bool CheckIfSelectionIsValid(Vector3Int gridPosition)
    {
        return !(furnitureData.CanPlaceObejctAt(gridPosition, Vector2Int.one) &&
            floorData.CanPlaceObejctAt(gridPosition, Vector2Int.one));
    }
    public void UpdateState(Vector3Int gridPosition)
    {
        bool validity = CheckIfSelectionIsValid(gridPosition);
        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), validity);
    }
}
