using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MultiFPS.Movement;


namespace MultiFPS.Control
{
    [RequireComponent(typeof(PlayerMotor))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed = 5f;
        [SerializeField] float lookSensitivity = 3f; 

        private PlayerMotor motor;

        private void Start()
        {
            motor = GetComponent<PlayerMotor>();
        }

        private void Update()
        {
            float xMove = Input.GetAxisRaw("Horizontal");
            float zMove = Input.GetAxisRaw("Vertical");

            Vector3 moveHorizontal = transform.right * xMove;
            Vector3 moveVertical = transform.forward * zMove;

            Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

            //Apply Movement
            motor.Move(velocity);

            //Turning the player left and right
            float yRot = Input.GetAxisRaw("Mouse X");

            Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;

            //Apply rotation
            motor.Rotate(rotation);

            //Turning the camera up and down
            float xRot = Input.GetAxisRaw("Mouse Y");

            Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * lookSensitivity;

            //Apply rotation
            motor.RotateCamera(cameraRotation);
        }
    }
}