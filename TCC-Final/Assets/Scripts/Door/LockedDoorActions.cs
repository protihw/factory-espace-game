using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class LockedDoorActions : MonoBehaviour
{
    // audios
    [SerializeField]
    private AudioSource doorAudioSource;
    [SerializeField]
    private AudioClip[] openingDoorAudioClips;
    [SerializeField]
    private AudioClip[] closingDoorAudioClips;
    [SerializeField]
    private AudioClip lockedDoorAudioClip;

    // variables
    [SerializeField]
    private Animator _animator;
    private bool colliding;
    private List<Item> playerInventory;
    private bool key;
    private bool doorOpen = false;
    private bool hasUnlocked = false;

    void Update()
    {
        RaycastCamera();

        if (key || hasUnlocked == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && colliding && doorOpen == false)
            {
                hasUnlocked = true;
                doorOpen = true;
                _animator.SetBool("doorStatus", doorOpen);
                doorAudioSource.PlayOneShot(openingDoorAudioClips[Random.Range(0, openingDoorAudioClips.Length)]);
            }
            else if (Input.GetKeyDown(KeyCode.E) && colliding && doorOpen == true)
            {
                doorOpen = false;
                _animator.SetBool("doorStatus", doorOpen);
                doorAudioSource.PlayOneShot(closingDoorAudioClips[Random.Range(0, closingDoorAudioClips.Length)]);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) && colliding)
            {
                doorAudioSource.PlayOneShot(lockedDoorAudioClip);
            }
        }
    }

    void RaycastCamera()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        float distance = 1f;

        int layerMask = 1 << LayerMask.NameToLayer("Ignore Raycast");

        if (Physics.Raycast(ray, out hit, distance, ~layerMask))
        {
            if (hit.transform.tag == "InteractiveLocked")
            {
                playerInventory = PlayerInventory.Instance.inventory;

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
        else
        {
            colliding = false;
        }
    }
}
