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

    [SerializeField]
    private AudioSource startingJumpingAudioSource;
    [SerializeField]
    private AudioClip[] startingJumpingAudioClips;

    [SerializeField]
    private AudioSource landingJumpingAudioSource;
    [SerializeField]
    private AudioClip[] landingJumpingAudioClips;

    public void WalkingMethod()
    {
        walkingAudioSource.PlayOneShot(walkingAudioClips[Random.Range(0, walkingAudioClips.Length)]);
    }

    public void RunningMethod() 
    {
        runningAudioSource.PlayOneShot(runningAudioClips[Random.Range(0, runningAudioClips.Length)]);
    }

    public void StartingJumpingMethod()
    {
        startingJumpingAudioSource.PlayOneShot(startingJumpingAudioClips[Random.Range(0, startingJumpingAudioClips.Length)]);
    }

    public void LandingJumpingMethod() 
    {
        landingJumpingAudioSource.PlayOneShot(landingJumpingAudioClips[Random.Range(0, landingJumpingAudioClips.Length)]);
    }
}
