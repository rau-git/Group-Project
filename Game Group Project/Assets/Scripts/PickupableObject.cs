using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObject : MonoBehaviour
{
    [SerializeField]
    private ItemObject _item;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerInventoryScript>().AddItem(_item);
            Destroy(this.gameObject);
        }
    }
}
