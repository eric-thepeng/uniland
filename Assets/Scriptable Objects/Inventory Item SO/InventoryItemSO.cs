using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemSO", menuName = "ScriptableObjects/InventoryItemSO")]
public class InventoryItemSO : ScriptableObject
{
    public string name;
    public enum Category {RawMaterial, CraftMaterial, Food,  Furniture, Object , Tool}
    public Sprite inventoryIcon;
    public Category category;

    public GameObject dragOut;
}
