using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private static PlayerInventory instance;
    private GameObject myPrefab;
    public Transform dropPosition;
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
        Debug.Log("Item adicionado ao inventário: " + item.itemName);
    }

    public void RemoveItem()
    {
        if (inventory.Count == 1 && myPrefab != null)
        {
            GameObject reactivatedObject = Instantiate(myPrefab, dropPosition.position, Quaternion.identity);
            reactivatedObject.SetActive(true);

            inventory.Clear();
            myPrefab = null;

            Debug.Log("Item removido do inventário");
        }
        else
        {
            Debug.LogWarning("Você não possui nenhum item em seu inventário.");
        }
    }
}
