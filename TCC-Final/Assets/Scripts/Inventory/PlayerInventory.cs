using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    private static PlayerInventory instance;
    private GameObject myPrefab;
    public Transform dropPosition;
    public Image slotIcon;

    public static PlayerInventory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerInventory>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("PlayerInventory");
                    instance = obj.AddComponent<PlayerInventory>();
                }
            }
            return instance;
        }
    }

    public List<Item> inventory = new List<Item>();

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RemoveItem();
        }
    }

    public void AddItem(Item item, GameObject prefab)
    {
        inventory.Add(item);
        myPrefab = prefab;
        slotIcon.sprite = item.itemIcon;
        slotIcon.gameObject.SetActive(true);
    }

    public void RemoveItem()
    {
        if (inventory.Count == 1 && myPrefab != null)
        {
            GameObject reactivatedObject = Instantiate(myPrefab, dropPosition.position, Quaternion.identity);
            reactivatedObject.SetActive(true);

            inventory.Clear();
            myPrefab = null;

            slotIcon.sprite = null;
            slotIcon.gameObject.SetActive(false);
        }
    }
}
