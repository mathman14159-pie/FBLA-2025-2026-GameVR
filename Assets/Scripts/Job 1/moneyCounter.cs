using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using KinematicCharacterController.Examples;
using UnityEngine.SceneManagement;

public class moneyCounter : MonoBehaviour
{
    public ExamplePlayer examplePlayer;
    public static bool machineOpen = false;
    public PlayerInput playerInput;
    [SerializeField] GameObject ClockOutUI;
    public static moneyCounter instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is createdpublic static ScoreCounter instance;
    public TMP_Text scoreText;
    public TMP_Text moneyText;
    public int currentMoney;
    public int moneyPayout;
    public int moneyPayoutAmount;
    public int moneyFromTyping;
    
    void Awake()
    {
        instance = this;
    }
    
    
    void Start()
    {
        currentMoney = PlayerPrefs.GetInt("Money");
        scoreText.text = "" + currentMoney.ToString();
        moneyPayout = 0;
    }

    public void IncreaseMoney(int v)
    {
        currentMoney += moneyPayoutAmount;
        PlayerPrefs.SetInt("Money", currentMoney);
    }
    public void DecreseMoney(int v)
    {
        currentMoney -= v;
        PlayerPrefs.SetInt("Money", currentMoney);
    }
    public void CleanedTrash()
    {
        moneyPayout += 1;
    }
        public void ServedCoffe()
    {
        moneyPayout += 1;
    }
    public void FoundEvidence()
    {
        moneyPayout += 5;
    }
    public void RightSuspect()
    {
        moneyPayout += 15;
        CalcPayoutNoPause();
        PlayerPrefs.SetInt("Money", currentMoney);
    }
    public void WrongSuspect()
    {
        moneyPayout -= 10;
        CalcPayoutNoPause();
        PlayerPrefs.SetInt("Money", currentMoney);
    }
    public void CalcPayout()
    {
        examplePlayer.enabled = false;
        machineOpen = true;
        ClockOutUI.SetActive(true);
        playerInput.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        moneyFromTyping = PlayerPrefs.GetInt("timesTyped");
        moneyPayoutAmount = moneyPayout;
        moneyText.text = "$" + moneyPayoutAmount.ToString();
        PlayerPrefs.SetInt("timesTyped", 0);
    }
    public void CalcPayout5()
    {
        examplePlayer.enabled = false;
        machineOpen = true;
        ClockOutUI.SetActive(true);
        playerInput.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        moneyFromTyping = PlayerPrefs.GetInt("timesTyped");
        moneyPayout = moneyFromTyping;
        moneyPayoutAmount = moneyPayout;
        moneyText.text = "$" + moneyPayoutAmount.ToString();
        PlayerPrefs.SetInt("timesTyped", 0);
    }
    public void CalcPayoutNoPause()
    {
        moneyPayoutAmount = moneyPayout;
        currentMoney += moneyPayoutAmount;
    }
    public void CloseUI()
    {
        examplePlayer.enabled = true;
        machineOpen = false;
        ClockOutUI.SetActive(false);
        playerInput.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
    public void ClockOut()
    {
        examplePlayer.enabled = true;
        machineOpen = false;
        ClockOutUI.SetActive(false);
        playerInput.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        IncreaseMoney(1);
        SceneManager.LoadScene("Bedroom");
    }
    public void AccuseSuspect1()
    {
        Debug.Log("wrong");
        WrongSuspect();
        PlayerPrefs.SetInt("Money", currentMoney);

    }
    public void AccuseSuspect2()
    {
        Debug.Log("wrong");
        WrongSuspect();
        PlayerPrefs.SetInt("Money", currentMoney);
    }
    public void AccuseSuspect3()
    {
        Debug.Log("wrong");
        WrongSuspect();
        PlayerPrefs.SetInt("Money", currentMoney);
        
    }
    public void AccuseSuspect4()
    {
        Debug.Log("right");
        RightSuspect();
        PlayerPrefs.SetInt("Money", currentMoney);
        
    }
    public void CalcTypeToMoney()
    {
        moneyFromTyping = PlayerPrefs.GetInt("timesTyped");
        moneyPayout = moneyFromTyping;
        examplePlayer.enabled = false;
        machineOpen = true;
        ClockOutUI.SetActive(true);
        playerInput.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        moneyPayoutAmount = moneyPayout;
        moneyText.text = "$" + moneyPayoutAmount.ToString();
    }
}
