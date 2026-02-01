using UnityEngine;
using UnityEngine.InputSystem;
using KinematicCharacterController.Examples;
using UnityEngine.SceneManagement;

public class pauseLogic : MonoBehaviour
{
    public ExamplePlayer examplePlayer;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject mainMenu;
    public GameObject spanishMainMenu;
    public GameObject HowToPlayMenuasset;
    public PlayerInput playerInput;
    public bool englishOrSpanish;

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
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }
    public void CloseOptions()
    {
        if (englishOrSpanish != false)
        {
            optionsMenu.SetActive(false);
            spanishMainMenu.SetActive(true);
            pauseMenu.SetActive(true);
        }
        else
        {
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
            pauseMenu.SetActive(true);
        }
        
    }
    public void HowToPlayMenu()
    {
        mainMenu.SetActive(false);
        HowToPlayMenuasset.SetActive(true);
    }
    public void CloseHowToPlayMenu()
    {
        mainMenu.SetActive(true);
        HowToPlayMenuasset.SetActive(false);
    }
    public void startPlayerSelection()
    {
        SceneManager.LoadScene("PlayerSelection");
    }
    public void startGame()
    {
        SceneManager.LoadScene("Bedroom");
    }
    public void spanishMode(bool isOn)
    {
        englishOrSpanish = isOn;
    }
    
}
