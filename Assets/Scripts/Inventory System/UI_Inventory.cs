using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UI_Inventory : MonoBehaviour
{
    static UI_Inventory instance = null;
    public static UI_Inventory i
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UI_Inventory>();
            }
            return instance;
        }
    }

    [SerializeField] GameObject inventoryBlockTemplate;
    [SerializeField] GameObject inventoryBlockBackgroundTemplate;
    List<GameObject> allBlockBackgrounds = new List<GameObject>();
    InventoryItemSO.Category displayingCategory;
    List<InventoryBlock> displayingBlocks = new List<InventoryBlock>();
    int maxColumns = 6;
    int maxRows = 6;
    [SerializeField] float displacement;

    public bool resetBackground = false;

    private void Update()
    {
        if (!resetBackground)
        {
            resetBackground = true;
            CreateInventoryBlocksBackground();
        }
    }

    public void DisplayCategory(InventoryItemSO.Category cat)
    {
        displayingBlocks.Clear();
        print(Inventory.i.CategoryToList(cat).Count);
        foreach(Inventory.ItemInfo ii in Inventory.i.CategoryToList(cat))
        {
            GameObject newBlockGO = Instantiate(inventoryBlockTemplate, transform.Find("InventoryBlocks"));
            InventoryBlock newIB = newBlockGO.GetComponent<InventoryBlock>();
            newIB.SetUp(ii, displayingBlocks.Count / maxColumns, displayingBlocks.Count % maxColumns);
            displayingBlocks.Add(newIB);
            newBlockGO.transform.position = new Vector3(newBlockGO.transform.position.x + newIB.column * displacement,
                                                        newBlockGO.transform.position.y - newIB.row * displacement,
                                                        newBlockGO.transform.position.z);
            newBlockGO.SetActive(true);
        }
    }

    public void UpdateItemInfo()
    {
        DisplayCategory(displayingCategory);
    }

    public void CreateInventoryBlocksBackground()
    {
        //delete origional background
        foreach(GameObject go in allBlockBackgrounds)
        {
            go.SetActive(false);
        }

        //make new background
        for(int i = 0; i<maxColumns; i++)
        {
            for(int j = 0; j<maxRows; j++)
            {
                GameObject go = Instantiate(inventoryBlockBackgroundTemplate, transform.Find("InventoryBlocksBackground"));
                go.transform.position = new Vector3(go.transform.position.x + i * displacement,
                                                        go.transform.position.y - j * displacement,
                                                        go.transform.position.z);
                go.SetActive(true);
                allBlockBackgrounds.Add(go);
            }
        }
    }

}
