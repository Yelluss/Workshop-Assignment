using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private float multiplier = 0.01f; 

    private Camera cam;

    private float mouseX;
    private float mouseY;

    private float xRotation;
    private float yRotation;

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        yRotation += mouseX * sensitivity * multiplier;
        xRotation -= mouseY * sensitivity * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    // This method is invoked when the player moves the mouse
    private void OnLook(InputValue input)
    {
    
        mouseX = input.Get<Vector2>().x;
        mouseY = input.Get<Vector2>().y;
    }
}
