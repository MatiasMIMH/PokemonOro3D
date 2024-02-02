using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void Update()
    {
        
        //Orientacion de la rotacion
        Vector3 viewDirection = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDirection.normalized;
        
        //Rotacion del player object
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        if (inputDirection != Vector3.zero){
            var rotate = Vector3.Slerp(playerObj.forward, inputDirection.normalized, Time.deltaTime * rotationSpeed);
            playerObj.forward = rotate;
            Debug.Log(rotate);
        }
    }
}
