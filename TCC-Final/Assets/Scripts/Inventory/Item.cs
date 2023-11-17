//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemIcon;

    public Item(string name, Sprite icon)
    {
        itemName = name;
        itemIcon = icon;
    }
}
