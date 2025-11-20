using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<string> items = new List<string>();

    public void AddItem(string itemName)
    {
        items.Add(itemName);
        Debug.Log("Inventario actual: " + string.Join(", ", items));
    }
}
