using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChestActions : MonoBehaviour
{
    [SerializeField]
    private Animator animatorLock;
    [SerializeField]
    private Animator animatorChest;
    [SerializeField]
    private bool colliding;
    private List<Item> playerInventory;
    private bool key;
    private bool locked = true;
    private bool chestOpen = false;

    void Start()
    {

    }

    void Update()
    {
        if (key)
        {
            if (Input.GetKeyDown(KeyCode.E) && colliding && locked == true)
            {
                locked = false;
                animatorLock.SetTrigger("OpenLock");
            }
            else if (Input.GetKeyDown(KeyCode.E) && colliding && locked == false && chestOpen == false)
            {
                chestOpen = true;
                animatorChest.SetTrigger("OpenChest");
            }
            else if (Input.GetKeyDown(KeyCode.E) && colliding && locked == false && chestOpen == true)
            {
                chestOpen = false;
                animatorChest.SetTrigger("CloseChest");
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInventory = collision.gameObject.GetComponent<PlayerInventory>().inventory;

            if (playerInventory != null)
            {
                if (playerInventory.Exists(item => item.itemName == "RustKey"))
                {
                    key = true;
                }
                else
                {
                    key = false;
                }
            }

            colliding = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            colliding = false;
        }
    }
}