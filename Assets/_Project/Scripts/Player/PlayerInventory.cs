using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Slider _teleportSlider;
    [SerializeField] private GameObject _player;

    public static PlayerInventory Instance { get; private set; } // Con static adesso appartiene alla classe
    // Getter pubblico setter privato per far leggere a tutti ma modificabile solo da questa classe

    private List<SO_Item> _itemsList = new List<SO_Item>();

    private void Awake()
    {
        if (Instance != null && Instance != this) // Controllo per Singleton (This Inventario presente in scena)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this; // Singleton

        if (_teleportSlider) _teleportSlider.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseInventory(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseInventory(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseInventory(3);
        }
    }

    public void AddItem(SO_Item item)
    {
        _itemsList.Add(item);
    }

    public void RemoveItem(SO_Item item)
    {
        _itemsList.Remove(item);
    }

    public void UseInventory(int id)
    {
        foreach (SO_Item item in _itemsList)
        {
            if (item.Id == id)
            {
                item.Use(_player);
                if (item.Id != 3) RemoveItem(item);
                break;
            }
        }
    }

    public void StartTeleport(GameObject player, float chargeTime)
    {
        StartCoroutine(TeleportRoutine(player, chargeTime));
    }

    private IEnumerator TeleportRoutine(GameObject player, float chargeTime)
    {
        _teleportSlider.value = 0;
        _teleportSlider.maxValue = chargeTime;
        _teleportSlider.gameObject.SetActive(true);

        float time = 0f;
        while (time < chargeTime)
        {
            time += Time.deltaTime;
            _teleportSlider.value = time;
            yield return null;
        }

        float playerY = player.GetComponent<Collider>().bounds.size.y;
        player.transform.position = new Vector3(0, playerY, 0);

        _teleportSlider.gameObject.SetActive(false);

        SO_Item ring = _itemsList.Find(i => i.Id == 3);
        if (ring)  RemoveItem(ring); // Qui lo rimuovo solo dopo il teleport
    }
}

//private void Update()
//{
//    if (Input.GetKey(KeyCode.Alpha1))
//    {
//        UseInventory(1);
//    }
//    if (Input.GetKey(KeyCode.Alpha2))
//    {
//        UseInventory(2);
//    }
//    if (Input.GetKey(KeyCode.Alpha3))
//    {
//        UseInventory(3);
//    }
//}

//public void UseInventory(int numberItemList)
//{
//    foreach (SO_Item item in _itemsList) // Scorro per ogni Item nella lista
//    {
//        if (item.Id == numberItemList)
//        {
//            item.Use(gameObject); // Trovo l'oggetto e lo uso

//            Debug.Log($"{gameObject.name} ha usato : {item.Name}");

//            _itemsList.Remove(item); // Lo rimuovo dalla lista 

//            break; // Altrimenti modifico la lista mentre ci ciclo dentro
//        }
//    }
//}
