using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;
    float xRotation = 0f, yRotation = 0f;
    public float topClamp = -90f, bottomClamp = 90f;
    public Transform playerBody;
    public bool canLook = true;

    void Update()
    {
        if (!canLook) return;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);
        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);
    }


    public void SetMouseSensitivity(float value)
    {
        mouseSensitivity = value * 200;
    }
    public void SetCanLook(bool value)
    {
        canLook = value;
    }
}