using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BEAN 
{
    public class PlayerCamera : MonoBehaviour
    {
        [Header("Camera Controls")]
        public float sensitivity = 400f;
        private float xRot = 0f;

        [Header("References")]
        [SerializeField] private Transform playerBody;


        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
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
