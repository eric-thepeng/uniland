using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisDrag : InventoryDrag
{
    bool placed = false;
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            PlaceTetris();
        }
        if (placed) return;
        transform.position = GetMouseWorldPos();
    }

    private void PlaceTetris()
    {
        placed = true;
        PlaceDragUI();
        this.enabled = false;
    }
}
