using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChestActions : MonoBehaviour
{
    // animators
    [SerializeField]
    private Animator animatorLock;
    [SerializeField]
    private Animator animatorChest;

    // audios
    [SerializeField]
    private AudioSource chestAudioSource;
    [SerializeField]
    private AudioClip[] openingChestAudioClips;
    [SerializeField]
    private AudioClip[] closingChestAudioClips;
    [SerializeField]
    private AudioClip[] openingLockAudioClips;

    // variables
    private bool colliding;
    private List<Item> playerInventory;
    private bool key;
    private bool locked = true;
    private bool chestStatus = false;

    void Update()
    {
        RaycastCamera();

        if (key)
        {
            if (Input.GetKeyDown(KeyCode.E) && colliding && locked == true)
            {
                locked = false;
                animatorLock.SetTrigger("OpenLock");
                chestAudioSource.PlayOneShot(openingLockAudioClips[Random.Range(0, openingLockAudioClips.Length)]);
            }
            else if (Input.GetKeyDown(KeyCode.E) && colliding && locked == false && chestStatus == false)
            {
                chestStatus = true;
                animatorChest.SetBool("chestStatus", chestStatus);
                chestAudioSource.PlayOneShot(openingChestAudioClips[Random.Range(0, openingChestAudioClips.Length)]);
            }
            else if (Input.GetKeyDown(KeyCode.E) && colliding && locked == false && chestStatus == true)
            {
                chestStatus = false;
                animatorChest.SetBool("chestStatus", chestStatus);
                chestAudioSource.PlayOneShot(closingChestAudioClips[Random.Range(0, closingChestAudioClips.Length)]);
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
            if (hit.transform.tag == "Interactive")
            {
                playerInventory = PlayerInventory.Instance.inventory;

                if (playerInventory != null)
                {
                    if (playerInventory.Exists(item => item.itemName == "RustKey") || locked == false)
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
        else
        {
            colliding = false;

        }
    }
}