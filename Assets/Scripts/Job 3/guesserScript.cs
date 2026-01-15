using UnityEngine;
using UnityEngine.InputSystem;
using KinematicCharacterController.Examples;
using UnityEngine.SceneManagement;

public class guesserScript : MonoBehaviour
{
    public ExamplePlayer examplePlayer;
    public PlayerInput playerInput;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactDistance = 3f;

    public GameObject Suspect1;
    public GameObject Suspect2;
    public GameObject Suspect3;
    public GameObject Suspect4;
    public static bool fileOpen = false;
    public GameObject UIObject1;
    public GameObject UIObject2;
    public GameObject UIObject3;
    public GameObject UIObject4;
    public GameObject Results1;
    public GameObject Results2;
    public GameObject Results3;
    public GameObject Results4;


    void Start()
    {
        if (playerCamera == null)
            playerCamera = Camera.main;
    }

    void Update()
    {
        if (fileOpen)
        {
            return;
        }
        if (!Input.GetKeyDown(KeyCode.U))
            return;

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            Debug.Log("Hit: " + hit.collider.name);
            
            
            if (hit.collider.CompareTag("Suspect1"))
            {
                examplePlayer.enabled = false;
                fileOpen = true;
                Suspect1.SetActive(true);
                playerInput.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
            }
            else if (hit.collider.CompareTag("Suspect2"))
            {
                examplePlayer.enabled = false;
                fileOpen = true;
                Suspect2.SetActive(true);
                playerInput.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
                
            }
            else if (hit.collider.CompareTag("Suspect3"))
            {
                examplePlayer.enabled = false;
                fileOpen = true;
                Suspect3.SetActive(true);
                playerInput.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
            }
            else if (hit.collider.CompareTag("Suspect4"))
            {
                examplePlayer.enabled = false;
                fileOpen = true;
                Suspect4.SetActive(true);
                playerInput.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
            }
        }
        
    }

    public void CloseUI1()
    {
        examplePlayer.enabled = true;
        fileOpen = false;
        UIObject1.SetActive(false);
        playerInput.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
    public void CloseUI2()
    {
        examplePlayer.enabled = true;
        fileOpen = false;
        UIObject2.SetActive(false);
        playerInput.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
    public void CloseUI3()
    {
        examplePlayer.enabled = true;
        fileOpen = false;
        UIObject3.SetActive(false);
        playerInput.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
    public void CloseUI4()
    {
        examplePlayer.enabled = true;
        fileOpen = false;
        UIObject4.SetActive(false);
        playerInput.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
    public void OpenResults1()
    {
        Results1.SetActive(true);
        UIObject1.SetActive(false);
        Debug.Log("wrong");
        moneyCounter.instance.WrongSuspect();
        
    }
    public void OpenResults2()
    {
        Results2.SetActive(true);
        UIObject2.SetActive(false);
        Debug.Log("wrong");
        moneyCounter.instance.WrongSuspect();
    }
    public void OpenResults3()
    {
        Results3.SetActive(true);
        UIObject3.SetActive(false);
        Debug.Log("wrong");
        moneyCounter.instance.WrongSuspect();
    }
    public void OpenResults4()
    {
        Results4.SetActive(true);
        UIObject4.SetActive(false);
        Debug.Log("wrong");
        moneyCounter.instance.RightSuspect();
    }
    
}
