using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    private Rigidbody characterRB;


    private Vector3 movementInput;

    public Vector3 moveDirection { get; private set; }


    [SerializeField] private float movementSpeed;
    [SerializeField] private float drag;

    [Header("Sprint Feature")]
    [SerializeField] private float sprintMultiplier;

    private bool isSprinting = false;

    private void Start()
    {
        characterRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (movementInput != Vector3.zero)
        {
            //Kan inte ändra värdet på property, bara fields så måste göra detta för att sätta y = 0
            Vector3 dir = transform.right * movementInput.x + transform.forward * movementInput.z;
            dir.y = 0;
            moveDirection = dir;
            

            MovePlayer();
            DragControl();
        }
    }
    // This method is invoked when there is movement input
    private void OnMovement(InputValue input)
    {
        // Getting movement input values (x and y axes)
        movementInput = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y);
    }
    private void OnMovementStop(InputValue input)
    {
        moveDirection = Vector3.zero;
    }
    //Sprint input action set to hold
    private void OnSprint(InputValue value)
    {
        isSprinting = value.isPressed;

            Debug.Log("Sprinting");
        
    }
    //SprintStop input action set to press release only
    private void OnSprintStop(InputValue value)
    {
        isSprinting = false;
        Debug.Log("Sprinting Stopped");
    }

 

    private void MovePlayer()
    {
       characterRB.AddForce(moveDirection.normalized * movementSpeed, ForceMode.Acceleration);

        if (isSprinting && movementInput != Vector3.zero)
        {
            characterRB.AddForce(moveDirection.normalized * movementSpeed * sprintMultiplier, ForceMode.Acceleration);
            //Debug.Log("Now this is podracing");
        }
    }

    private void DragControl()
    {
        characterRB.linearDamping = drag;
    }

}
