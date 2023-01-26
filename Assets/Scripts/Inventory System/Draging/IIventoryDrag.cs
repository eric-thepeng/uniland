using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IIventoryDrag {
    InventoryItemSO myIISO { get; set; }
    InventoryBlock myIB { get; set; }

    public void SetUpDrag(InventoryItemSO iiso , InventoryBlock ib)
    {
        myIISO = iiso;
        myIB = ib;
    }

    public void CancelDrag()
    {

    }
}
