using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Inventory : MonoBehaviour
{
    [SerializeField]List<InventoryItemSO> iisoToAdd;
    [SerializeField] bool addAllIISO;
    [SerializeField] InventoryItemSO.Category categoryToDisplay;
    [SerializeField] bool displayCategroy;

    private void Start()
    {
        AddAllIISO();
    }

    private void Update()
    {
        if (addAllIISO)
        {
            AddAllIISO();
        }
        if (displayCategroy)
        {
            DisplayCategory();
        }
    }

    private void AddAllIISO()
    {
        print("execute: AddAllIISO");
        addAllIISO = false;
        foreach (InventoryItemSO iiso in iisoToAdd)
        {
            Inventory.i.AddInventoryItem(iiso);
        }
    }

    private void DisplayCategory()
    {
        print("execute: DisplayCategory");
        displayCategroy = false;
        UI_Inventory.i.DisplayCategory(categoryToDisplay);
    }


}
