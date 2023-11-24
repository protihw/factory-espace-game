using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource walkingAudioSource;
    [SerializeField]
    private AudioClip[] walkingAudioClips;

    [SerializeField]
    private AudioSource runningAudioSource;
    [SerializeField]
    private AudioClip[] runningAudioClips;

    public void WalkingMethod()
    {
        walkingAudioSource.PlayOneShot(walkingAudioClips[Random.Range(0, walkingAudioClips.Length)]);
    }

    public void RunningMethod() 
    {
        runningAudioSource.PlayOneShot(runningAudioClips[Random.Range(0, runningAudioClips.Length)]);
    }
}
