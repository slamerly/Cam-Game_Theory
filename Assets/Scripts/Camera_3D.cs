using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_3D : MonoBehaviour
{
    public GameObject characterTarget;
    public Camera cam;
    public float rotationSpeed = 2.0f;
    public float topClamp = 90f;
    public float bottomClamp = -90f;
    public float speedZoom = 1f;

    private float playerCameraTargetPitch;
    private float rotationVelocity;
    private float mouseX;
    private float mouseY;
    private bool zoom = false;
    private bool hit = false;

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
        Debug.Log(zoom);
        if (zoom)
            if(cam.fieldOfView > 50)
                cam.fieldOfView -= Time.deltaTime * speedZoom;
            else
                cam.fieldOfView = 50;
        else
            if (cam.fieldOfView < 95)
                cam.fieldOfView += Time.deltaTime * speedZoom;
    }

    private void CameraRotation()
    {
        float deltaTimeMultiplier = 1.0f;
        
        playerCameraTargetPitch -= mouseY * rotationSpeed * deltaTimeMultiplier;
        rotationVelocity = mouseX * rotationSpeed;

        playerCameraTargetPitch = ClampAngle(playerCameraTargetPitch, bottomClamp, topClamp);

        transform.localRotation = Quaternion.Euler(playerCameraTargetPitch, 0f, 0f);

        characterTarget.transform.Rotate(Vector3.up * rotationVelocity);
    }

    private static float ClampAngle(float CamAngle, float angleMin, float angleMax)
    {
        if (CamAngle < -360f) CamAngle += 360f;
        if (CamAngle > 360f) CamAngle -= 360f;
        return Mathf.Clamp(CamAngle, angleMin, angleMax);
    }

    public void ReceiveInputZoom(bool zoomActivation)
    {
        zoom = zoomActivation;
    }

    public void ReceiveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x;
        mouseY = mouseInput.y;
    }
}
