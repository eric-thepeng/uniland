using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBlock : MonoBehaviour
{
    InventoryItemSO iiso;
    InventoryItemSO.Category category;
    public int row;
    public int column;
    public int displayAmount;

    public void SetUp(Inventory.ItemInfo ii, int inRow, int inColumn)
    {
        iiso = ii.iiso;
        category = iiso.category;
        row = inRow;
        column = inColumn;
        displayAmount = ii.totalAmount - ii.inUseAmount;
        GetComponent<SpriteRenderer>().sprite = iiso.inventoryIcon;
    }

    private void OnMouseEnter()
    {
        InventoryHoverInfo.i.Display(transform.position);
    }

    private void OnMouseExit()
    {
        InventoryHoverInfo.i.Disappear();
    }
}
