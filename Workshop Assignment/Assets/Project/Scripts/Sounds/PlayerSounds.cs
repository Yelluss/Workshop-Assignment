using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    

    private bool isMoving = false;
    private bool soundStarted = false;
    private float movementTimer;
    [SerializeField] private float timeThreshold;


    [Header("Sprinting")]
    [SerializeField] private float sprintPitch;
    [SerializeField] private float sprintVolume;

    [Header("Walking")]
    [SerializeField] private float walkPitch;
    [SerializeField] private float walkVolume;


    void Start()
    {
        audioSource.pitch = walkPitch;
        audioSource.volume = walkVolume;
    }

    
    void Update()
    {
        MovingCheck();

    }

    private void OnMovement(InputValue input)
    {
       isMoving = true;
    }

    private void OnMovementStop(InputValue input)
    {
        audioSource.Stop();
        soundStarted = false;
        isMoving = false;
    }

    private void OnSprint()
    {
        audioSource.pitch = sprintPitch;
        audioSource.volume = sprintVolume;
    }

    private void OnSprintStop()
    {
        audioSource.pitch = walkPitch;
        audioSource.volume = walkVolume;
    }

    private void MovingCheck()
    {
        //Basically if player is moving, wait X amount of seconds before starting walking sound to prevent sound spam and if player stops moving set the X value to zero
        if (isMoving)
        {
            movementTimer += Time.deltaTime;

            if (movementTimer > timeThreshold && !soundStarted)
            {
                audioSource.clip = SoundBank.Instance.stepAudio;
                audioSource.loop = true;

                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }

            }


        }
        else
        {
            movementTimer = 0f;
        }

    }
}
