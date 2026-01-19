using UnityEngine;
using UnityEngine.InputSystem;
using KinematicCharacterController.Examples;

public class pauseLogic : MonoBehaviour
{
    public ExamplePlayer examplePlayer;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public PlayerInput playerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        examplePlayer.enabled = false;
        pauseMenu.SetActive(true);
        playerInput.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        }
    }
    public void Resume()
    {
        examplePlayer.enabled = true;
        pauseMenu.SetActive(false);
        playerInput.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Options()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
