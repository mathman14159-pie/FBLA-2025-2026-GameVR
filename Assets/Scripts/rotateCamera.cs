using Unity.Mathematics;
using UnityEngine;

public class rotateCamera : MonoBehaviour
{
    public GameObject Camera;
    public float rotationNumber;
    public float value = 0.09f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Camera.transform.Rotate(Camera.transform.rotation.x, value, Camera.transform.rotation.z);
    }
}
