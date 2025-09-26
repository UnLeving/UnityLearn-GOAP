using System.Collections.Generic;
using UnityEngine;

public class GInventory
{
    private List<GameObject> items = new();
    public List<GameObject> Items => items;
    
    public void AddItem(GameObject item)
    {
        items.Add(item);
    }
    
    public void RemoveItem(GameObject item)
    {
        items.Remove(item);
    }

    public GameObject FindItemWithTag(string tag)
    {
        return items.Find(item => item.CompareTag(tag));
    }
}