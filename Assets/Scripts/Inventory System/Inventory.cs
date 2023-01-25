using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    static Inventory instance = null;
    public static Inventory i
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Inventory>();
            }
            return instance;
        }
    }

    public class ItemInfo {
        public InventoryItemSO iiso;
        public int totalAmount;
        public int inUseAmount;

        public ItemInfo(InventoryItemSO newIISO)
        {
            iiso = newIISO;
            totalAmount = 1;
            inUseAmount = 0;
        }
    }

    public List<ItemInfo> catRawMaterial = new List<ItemInfo>();
    public List<ItemInfo> catCraftMaterial = new List<ItemInfo>();
    public List<ItemInfo> catFood = new List<ItemInfo>();
    public List<ItemInfo> catTool = new List<ItemInfo>();
    public List<ItemInfo> catFurniture = new List<ItemInfo>();
    public List<ItemInfo> catObject = new List<ItemInfo>();



    public void AddInventoryItem(InventoryItemSO newIISO)
    {
        foreach(ItemInfo ii in CategoryToList(newIISO.category))
        {
            if (ii.iiso == newIISO)
            {
                ii.totalAmount += 1;
                print("added amount: " + newIISO.name);
                return;
            }
        }
        CategoryToList(newIISO.category).Add(new ItemInfo(newIISO));
        print("added new: " + newIISO.name);
    }

    public List<ItemInfo> CategoryToList(InventoryItemSO.Category cat)
    {
        if (cat == InventoryItemSO.Category.RawMaterial) return catRawMaterial;
        else if (cat == InventoryItemSO.Category.CraftMaterial) return catCraftMaterial;
        else if (cat == InventoryItemSO.Category.Food) return catFood;
        else if (cat == InventoryItemSO.Category.Tool) return catTool;
        else if (cat == InventoryItemSO.Category.Furniture) return catFurniture;
        else if (cat == InventoryItemSO.Category.Object) return catObject;
        return null;
    }
}
