using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximitySound : MonoBehaviour
{
    public AudioClip soundClip;  // Assign your audio clip in the Unity Editor
    public float maxVolumeDistance = 2f;  // Maximum distance for full volume
    public float minVolumeDistance = 0.2f;   // Minimum distance for minimum volume
    public float delayBetweenFootsteps = 0.2f;  // Delay between each footstep

    private AudioSource audioSource;
    private Transform player;
    private bool isPlaying = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;
        audioSource.loop = false;  // Set to false to play the sound once at a time
        audioSource.playOnAwake = false;  // Don't start playing the audio on awake

        player = GameObject.FindGameObjectWithTag("Player").transform;  // Assuming the player has the tag "Player"
    }

    void Update()
    {
        if (player == null)
        {
            // Player not found, do something (e.g., find it again)
            player = GameObject.FindGameObjectWithTag("Player").transform;
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Adjust volume based on distance
        float volume = Mathf.Clamp01(1 - (distanceToPlayer - minVolumeDistance) / (maxVolumeDistance - minVolumeDistance));
        audioSource.volume = volume;

        // Play the audio when the player is within the maximum distance and not already playing
        if (distanceToPlayer <= maxVolumeDistance && !isPlaying)
        {
            StartCoroutine(PlayFootstepWithDelay());
        }
    }

    IEnumerator PlayFootstepWithDelay()
    {
        isPlaying = true;
        audioSource.Play();

        // Wait for the specified delay before allowing the sound to play again
        yield return new WaitForSeconds(delayBetweenFootsteps);

        isPlaying = false;
    }
}
