using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestActions : MonoBehaviour
{
    [SerializeField]
    private Animator animatorLock;
    [SerializeField]
    private Animator animatorChest;
    [SerializeField]
    private bool colliding;
    private bool locked = true;
    private bool chestOpen = false;

    void Start()
    {
        
    }

    void Update()
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

    private void OnTriggerEnter(Collider collisiom)
    {
        if (collisiom.gameObject.CompareTag("Player"))
        {
            colliding = true;
        }
    }

    private void OnTriggerExit(Collider collisiom)
    {
        if (collisiom.gameObject.CompareTag("Player"))
        {
            colliding = false;
        }
    }
}