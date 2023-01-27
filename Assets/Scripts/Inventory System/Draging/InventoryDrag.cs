using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryDrag : MonoBehaviour {
    public InventoryItemSO myIISO { get; set; }
    public InventoryBlock myIB { get; set; }

    public void SetUpDragUI(InventoryItemSO iiso , InventoryBlock ib)
    {
        myIISO = iiso;
        myIB = ib;
    }

    public void PlaceDragUI()
    {
        myIB.PlaceDrag();
        Inventory.i.InUseItem(myIISO, true);
    }

    public void CancelDragUI()
    {
        myIB.CancelDrag();
    }

    protected void SetPositionToMouse()
    {
        transform.position = new Vector3(GetMouseWorldPos().x, GetMouseWorldPos().y, transform.position.z);
    }

    protected Vector3 GetMouseWorldPos()
    {
        //return mouse position through main camera
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));
        //return CameraManager.i.getPanelCamera().ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraManager.i.getPanelCamera().transform.position.z * -1));
    }
}
