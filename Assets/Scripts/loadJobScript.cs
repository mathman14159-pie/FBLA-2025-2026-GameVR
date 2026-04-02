using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using KinematicCharacterController.Examples;
using Cursor = UnityEngine.Cursor;


public class loadJobScript : MonoBehaviour
{
    public ExamplePlayer examplePlayer;
    public static bool machineOpen = false;
    public PlayerInput playerInput;
    public Camera playerCamera;
    public LayerMask jobItem;
    public float interactDistance = 3;
    public GameObject BuyJobsUI;
    public GameObject poor;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
            {
                if (hit.collider.CompareTag("BuyJobs"))
                {
                    if (Input.GetKeyDown(KeyCode.U))
                    {
                        BuyJobsUI.SetActive(true);
                        examplePlayer.enabled = false;
                        machineOpen = true;
                        playerInput.enabled = false;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        Time.timeScale = 0f;
                    }
                }
            }
        }
           
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("rightclicked");
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, jobItem))
            {
                Debug.Log("raycastHit");
                if (hit.collider.TryGetComponent<JobIdentifier>(out JobIdentifier job))
                    {
                        Debug.Log("SceneOpen");
                        SceneManager.LoadScene("Job " + job.jobNumber);
                    }
            }
        }
    }

    public void CloseBuyJobs()

    {
        BuyJobsUI.SetActive(false);
        examplePlayer.enabled = true;
        machineOpen = false;
        playerInput.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        poor.SetActive(false);
    }
}