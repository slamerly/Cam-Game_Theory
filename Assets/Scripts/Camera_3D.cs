using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_3D : MonoBehaviour
{
    public GameObject PlayerCameraTarget;
    public float RotationSpeed = 2.0f;
    public float TopClamp = 90f;
    public float BottomClamp = -90f;

    private float playerCameraTargetPitch;
    private float rotationVelocity;
    private float mouseX;
    private float mouseY;

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float deltaTimeMultiplier = 1.0f;
        
        playerCameraTargetPitch -= mouseY * RotationSpeed * deltaTimeMultiplier;
        rotationVelocity = mouseX * RotationSpeed * deltaTimeMultiplier;

        playerCameraTargetPitch = ClampAngle(playerCameraTargetPitch, BottomClamp, TopClamp);

        PlayerCameraTarget.transform.localRotation = Quaternion.Euler(playerCameraTargetPitch, 0f, 0f);

        transform.Rotate(Vector3.up * rotationVelocity);
    }

    private static float ClampAngle(float CamAngle, float angleMin, float angleMax)
    {
        if (CamAngle < -360f) CamAngle += 360f;
        if (CamAngle > 360f) CamAngle -= 360f;
        return Mathf.Clamp(CamAngle, angleMin, angleMax);
    }

    public void ReceiveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x;
        mouseY = mouseInput.y;
    }
}
