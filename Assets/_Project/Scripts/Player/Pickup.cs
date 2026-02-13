using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Pickup : MonoBehaviour
{
    [SerializeField] SO_Item _item;
    private const string _tagPlayer = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(_tagPlayer)) return;

        PlayerInventory.Instance.AddItem(_item); // Non cerco piu l'inventario nel player (GetComponent), ma prendo l'unico esistente

        Destroy(gameObject);
    }
}
