using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "Items")]
public class ItemObject : ScriptableObject
{
    [Header("Item Attributes")]
    public string _itemName;
    [TextArea(1, 5)]
    public string _itemDescription;
    public int _itemQuantity;
    public float _itemHealAmount;

    [Header("Prefab Assignables")]
    public GameObject _worldItemPrefab;
    public GameObject _uiItemPrefab;
}
