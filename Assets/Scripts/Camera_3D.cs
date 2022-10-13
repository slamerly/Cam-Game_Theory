using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_3D : MonoBehaviour
{
    public GameObject PlayerCameraTarget;
    public float TopClamp = 90f;
    public float BottomClamp = -90f;

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float deltaTimeMultiplier = 1.0f;
        float playerCameraTargetPitch;
        playerCameraTargetPitch -= Input.GetAxis("Mouse Y") * RotationSpeed * deltaTimeMultiplier;
        rotationVelocity = Input.GetAxis("Mouse X") * RotationSpeed * deltaTimeMultiplier;

        playerCameraTargetPitch = ClampAngle(playerCameraTargetPitch, BottomClamp, TopClamp);

        PlayerCameraTarget.transform.localRotation = Quaternion.Euler(playerCameraTargetPitch, 0f, 0f);

        transform.Rotate(Vector3.up * rotationVelocity);
    }
}
