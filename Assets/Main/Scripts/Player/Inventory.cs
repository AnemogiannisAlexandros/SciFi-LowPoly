using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "Inventory", order = 0)]
    public class Inventory : ScriptableObject
    {
        public List<Item> inventoryItems = new List<Item>();

        //Add An Item to our List
        public void AddItem(Item item)
        {
            inventoryItems.Add(item);
        }
        //Remove an item from our list
        public void RemoveItem(Item item)
        {
            inventoryItems.Remove(item);
        }
    }
}
