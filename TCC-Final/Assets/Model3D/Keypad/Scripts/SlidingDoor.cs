using UnityEngine;
namespace NavKeypad
{
    public class SlidingDoor : MonoBehaviour
    {
        // audios
        [SerializeField]
        private AudioSource doorAudioSource;
        [SerializeField]
        private AudioClip openingDoorAudioClip;
        [SerializeField]
        private AudioClip closingDoorAudioClip;

        // variables
        [SerializeField] private Animator anim;
        public bool IsOpoen => isOpen;
        private bool isOpen = false;

        public void ToggleDoor()
        {
            isOpen = !isOpen;
            anim.SetBool("isOpen", isOpen);
        }

        public void OpenDoor()
        {
            isOpen = true;
            anim.SetBool("isOpen", isOpen);
            doorAudioSource.PlayOneShot(openingDoorAudioClip);
        }
        public void CloseDoor()
        {
            isOpen = false;
            anim.SetBool("isOpen", isOpen);
            doorAudioSource.PlayOneShot(closingDoorAudioClip);
        }
    }
}