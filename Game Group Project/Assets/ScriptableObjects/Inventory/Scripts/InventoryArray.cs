using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class InventoryArray : ScriptableObject
{
    public ItemObject[] _inventoryArray = new ItemObject[3];

    public void AddItem(ItemObject itemToAdd)
    {
        for (int i = 0; i < _inventoryArray.Length; i++)
        {
            if (_inventoryArray[i]._itemName == itemToAdd._itemName)
            {
                _inventoryArray[i]._itemQuantity += 1;
            }
            else
            {
                for (int k = 0; k < _inventoryArray.Length; k++)
                {
                    if (_inventoryArray[k] == null)
                    {
                        _inventoryArray[k] = itemToAdd;
                    }
                }
            }
        }
    }
}
