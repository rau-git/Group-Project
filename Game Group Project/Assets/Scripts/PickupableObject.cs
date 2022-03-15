using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObject : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private ItemObject _item;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        other.GetComponent<PlayerInventoryScript>().AddItem(_item);
        Destroy(this.gameObject);
    }
}
