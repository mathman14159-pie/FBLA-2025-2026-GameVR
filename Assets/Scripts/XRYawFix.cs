using UnityEngine;

public class XRYawFix : MonoBehaviour
{
    Quaternion lastRotation;

    void Start()
    {
        lastRotation = transform.localRotation;
    }

    void LateUpdate()
    {
        Quaternion current = transform.localRotation;

        // Extract yaw
        float yawDelta = Mathf.DeltaAngle(
            lastRotation.eulerAngles.y,
            current.eulerAngles.y
        );

        // Invert yaw
        transform.Rotate(0f, -yawDelta * 2f, 0f, Space.Self);

        lastRotation = transform.localRotation;
    }
}
