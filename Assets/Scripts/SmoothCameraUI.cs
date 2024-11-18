using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraUI : MonoBehaviour
{
    public Transform targetCamera; // Reference to the VR camera
    public Vector3 positionOffset = new Vector3(0, 0, 1f); // Offset in front of the camera
    public float smoothFactor = 0.1f; // How smooth the movement is

    [Range(0f, 1f)]
    public float rotationLockY = 0.5f; // Lock rotation on Y axis (0 = free, 1 = locked)

    private void LateUpdate()
    {
        if (targetCamera == null)
            return;

        // Smoothly follow the target camera position with an offset
        Vector3 targetPosition = targetCamera.position + targetCamera.forward * positionOffset.z + targetCamera.right * positionOffset.x + targetCamera.up * positionOffset.y;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothFactor);

        // Limit rotation on specific axes
        Vector3 targetEuler = targetCamera.rotation.eulerAngles;
        targetEuler.y = Mathf.Lerp(transform.eulerAngles.y, targetEuler.y, 1 - rotationLockY);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, targetEuler.y, 0), smoothFactor);
    }
}
