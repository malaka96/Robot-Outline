using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngineSound : MonoBehaviour
{
    public AudioSource engineAudioSource;
    public Rigidbody2D carRigidbody; // Reference to the car's Rigidbody2D
    public float minPitch = 0.5f;
    public float maxPitch = 2.0f;
    public float maxSpeed = 20f; // Maximum speed of the car

    void Update()
    {
        // Get the current speed of the car
        float speed = carRigidbody.velocity.magnitude;

        // Calculate the pitch based on the speed
        float pitch = Mathf.Lerp(minPitch, maxPitch, speed / maxSpeed);

        // Set the pitch of the audio source
        engineAudioSource.pitch = pitch;
    }
}
