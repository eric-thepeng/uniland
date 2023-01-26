using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHoverInfo : MonoBehaviour
{
    static InventoryHoverInfo instance = null;
    public static InventoryHoverInfo i
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryHoverInfo>();
            }
            return instance;
        }
    }

    public void Display(Vector3 toPosition)
    {
        transform.position = new Vector3(toPosition.x, toPosition.y, transform.position.z);
    }

    public void Disappear()
    {
        transform.position = new Vector3(12f,0f,-1f);
    }
}
