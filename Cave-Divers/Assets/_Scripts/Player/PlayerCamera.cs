using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace BEAN 
{
    public class PlayerCamera : NetworkBehaviour
    {
        [Header("Camera Controls")]
        public float sensitivity = 400f;
        private float xRot = 0f;

        [Header("References")]
        [SerializeField] private Transform playerBody;


        private void Start()
        {
            if (!IsOwner) Destroy(this.gameObject);
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            HandleCameraMovement();
        }

        private void HandleCameraMovement()
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -90, 90);

            transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
