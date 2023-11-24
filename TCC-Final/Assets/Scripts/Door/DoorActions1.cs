using System.Net.Sockets;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorActions1 : MonoBehaviour
{
    // audios
    [SerializeField]
    private AudioSource doorAudioSource;
    [SerializeField]
    private AudioClip openingDoorAudioClip;
    [SerializeField]
    private AudioClip closingDoorAudioClip;

    // variables
    [SerializeField]
    private Animator _animator;
    private bool colliding;
    private bool doorOpen = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastCamera();

        if (Input.GetKeyDown(KeyCode.E) && colliding && doorOpen == false)
        {
            doorOpen = true;
            _animator.SetBool("doorStatus", doorOpen);
            doorAudioSource.PlayOneShot(openingDoorAudioClip);
        }
        else if (Input.GetKeyDown(KeyCode.E) && colliding && doorOpen == true)
        {
            doorOpen = false;
            _animator.SetBool("doorStatus", doorOpen);
            doorAudioSource.PlayOneShot(closingDoorAudioClip);
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
            if (hit.transform.tag == "Interactive1")
            {
                colliding = true;
            }
        }
        else
        {
            colliding = false;
        }
    }
}
