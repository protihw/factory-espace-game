using System.Collections.Generic;
using UnityEngine;

public class LockedDoorActions : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    private bool colliding;
    private List<Item> playerInventory;
    private bool key;
    private bool doorOpen = false;
    private bool hasUnlocked = false;

    void Start()
    {

    }

    void Update()
    {
        if (key || hasUnlocked == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && colliding && doorOpen == false)
            {
                doorOpen = true;
                _animator.SetTrigger("Open");
                hasUnlocked = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && colliding && doorOpen == true)
            {
                doorOpen = false;
                _animator.SetTrigger("Close");
            }
        }
    }

    private void OnTriggerEnter(Collider collission)
    {
        if (collission.gameObject.CompareTag("Player"))
        {
            playerInventory = collission.gameObject.GetComponent<PlayerInventory>().inventory;

            if (playerInventory != null)
            {
                if (playerInventory.Exists(item => item.itemName == "Key"))
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

    private void OnTriggerExit(Collider collission)
    {
        if (collission.gameObject.CompareTag("Player"))
        {
            colliding = false;
        }
    }
}
