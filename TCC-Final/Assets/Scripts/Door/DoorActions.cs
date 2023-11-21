using UnityEngine;

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

    private void OnTriggerEnter(Collider collission)
    {
        if (collission.gameObject.CompareTag("Player"))
        {
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
