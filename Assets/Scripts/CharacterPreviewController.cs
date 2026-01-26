using UnityEngine;

public class CharacterPreviewController : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 200f;

    [Header("Zoom")]
    [SerializeField] private Camera previewCamera;
    [SerializeField] private float zoomSpeed = 2f;
    [SerializeField] private float minZoom = 2.5f;
    [SerializeField] private float maxZoom = 6f;
    public GameObject character;

    private float currentZoom;

    void Start()
    {
        if (previewCamera == null)
        {
            previewCamera = Camera.main;
        }

        currentZoom = previewCamera.transform.localPosition.z;
    }

    void Update()
    {
        HandleRotation();
        
    }

    private void HandleRotation()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up, -mouseX * rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    private void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.01f)
        {
            currentZoom += scroll * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, -maxZoom, -minZoom);

            Vector3 camPos = previewCamera.transform.localPosition;
            camPos.z = currentZoom;
            previewCamera.transform.localPosition = camPos;
        }
    }
}
