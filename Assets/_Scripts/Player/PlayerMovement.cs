using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input")]
    private Vector3 moveDirection;
    private Vector2 playerInputDirection;

    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform orientation;

    [Header("Movement")]
    [SerializeField] private float baseMoveSpeed;
    [SerializeField] private float sprintMoveSpeed;
    [SerializeField] private float walkMoveSpeed;
    [SerializeField] private float groundDrag;
    private bool canMove = true;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    private void Update()
    {
        MyInput();

        SpeedControl();

        CheckDrag();

        SprintCheck();
    }

    private void SprintCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            baseMoveSpeed = sprintMoveSpeed;
            animator.SetFloat("walkAnimation", 1);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            baseMoveSpeed = walkMoveSpeed;
            animator.SetFloat("walkAnimation", 0);
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            MovePlayer();
        }
    }

    private void MyInput()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        playerInputDirection = new Vector2(horizontalInput, verticalInput);
    }


    private void CheckDrag()
    {
        rb.drag = groundDrag;
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * playerInputDirection.y + orientation.right * playerInputDirection.x;

        rb.AddForce(10f * baseMoveSpeed * moveDirection.normalized, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new(rb.velocity.x, 0f, rb.velocity.z);

        animator.SetFloat("horizontalSpeed", moveDirection.magnitude);

        if (flatVel.magnitude > sprintMoveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * baseMoveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    public void ChangePlayerCanMoveState(bool state)
    {
        canMove = state;

        if (!state)
        {
            moveDirection = Vector3.zero;
        }
    }

    private void PlayerDeathChangeMove()
    {
        ChangePlayerCanMoveState(false);
    }
}
