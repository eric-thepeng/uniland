using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    //PanelManager.i.isPanel(你要的panel);
    static PanelManager instance = null;
    public static PanelManager i
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PanelManager>();
            }
            return instance;
        }
    }

    public enum Panel {Home, Explore, Craft}
    public Panel currentPanel;

    public bool isPanel(Panel toCheck)
    {
        return toCheck == currentPanel ;
    }
}
