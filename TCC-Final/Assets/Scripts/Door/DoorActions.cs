using System.Net.Sockets;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorActions : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    private bool colliding;
    private bool doorOpen = false;
    void Start()
    {

    }

    void Update()
    {
        RaycastCamera();

        if (Input.GetKeyDown(KeyCode.E) && colliding && doorOpen == false)
        {
            doorOpen = true;
            _animator.SetTrigger("Open");
        }
        else if (Input.GetKeyDown(KeyCode.E) && colliding && doorOpen == true)
        {
            doorOpen = false;
            _animator.SetTrigger("Close");
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
                colliding = true;
            }
        }
        else
        {
            colliding = false;
        }
    }
}
