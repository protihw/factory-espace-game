using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource walkingAudioSource;
    [SerializeField]
    private AudioClip[] walkingAudioClips;

    public void WalkingMethod()
    {
        walkingAudioSource.PlayOneShot(walkingAudioClips[Random.Range(0, walkingAudioClips.Length)]);
    }
}
