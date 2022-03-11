using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryScript : MonoBehaviour
{
    [Header("Referenced Scripts")]
    [SerializeField] private List<ItemObject> _healingItemInventory = new List<ItemObject>();
    [SerializeField] private ItemObject _healingItem;
    [SerializeField] private PlayerFunctions _playerFunctions;

    private void Awake()
    {
        _healingItemInventory.Add(_healingItem);
    }

    public void AddItem(ItemObject itemToAdd)
    {
        itemToAdd._itemQuantity += 1;
    }

    public void UseItem()
    {
        if (_healingItem._itemQuantity > 0)
        {
            _healingItem._itemQuantity -= 1;
            _playerFunctions.HealCharacter(_healingItem._itemHealAmount);
        }
    }
}
