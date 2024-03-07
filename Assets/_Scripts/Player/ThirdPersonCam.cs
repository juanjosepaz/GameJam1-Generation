using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;

    [Header("Camera Control Objects")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform playerObject;
    [SerializeField] private float rotationSpeed;
    private Vector2 playerInputDirection;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        playerInputDirection = new Vector2(horizontalInput, verticalInput);

        Vector3 viewDirection = playerTransform.position - new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);
        orientation.forward = viewDirection.normalized;

        Vector3 inputDirection = orientation.forward * playerInputDirection.y + orientation.right * playerInputDirection.x;

        if (inputDirection != Vector3.zero)
        {
            playerObject.forward = Vector3.Slerp(playerObject.forward, inputDirection.normalized, Time.deltaTime * rotationSpeed);
        }

    }
}
