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
        RaycastCamera();

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

    void RaycastCamera()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        float distance = 1.75f;

        int layerMask = 1 << LayerMask.NameToLayer("Ignore Raycast");

        if (Physics.Raycast(ray, out hit, distance, ~layerMask))
        {
            if (hit.transform.tag == "Chest")
            {
                playerInventory = PlayerInventory.Instance.inventory;

                if (playerInventory != null)
                {
                    if (playerInventory.Exists(item => item.itemName == "RustKey"))
                    {
                        key = true;
                    }
                    else
                    {
                        key = true;
                    }
                }

                colliding = true;
            }
        }
        else
        {
            colliding = false;

        }
    }
}