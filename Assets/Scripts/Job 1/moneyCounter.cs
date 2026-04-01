using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using KinematicCharacterController.Examples;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class moneyCounter : MonoBehaviour
{
    public ExamplePlayer examplePlayer;
    public static bool machineOpen = false;
    public PlayerInput playerInput;
    [SerializeField] GameObject ClockOutUI;
    public GameObject StarsUI;
    public static moneyCounter instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is createdpublic static ScoreCounter instance;
    public TMP_Text scoreText;
    public TMP_Text moneyText;
    public TMP_Text starText;
    public int currentMoney;
    public int moneyPayout;
    public int moneyPayoutAmount;
    public int moneyFromTyping;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject star4;
    public int stars;
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
    public void CalcStars()
    {
        stars = Random.Range(1, 4);
        if (stars == 1)
        {
            star1.SetActive(true);
            starText.text = "bad";
        }
        if (stars == 2)
        {
            star2.SetActive(true);
            starText.text = "meh";
        }
        if (stars == 3)
        {
            star3.SetActive(true);
            starText.text = "okay";
        }
        if (stars == 4)
        {
            star4.SetActive(true);
            starText.text = "Good";
        }
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
        
        IncreaseMoney(1);
        ClockOutUI.SetActive(false);
        StarsUI.SetActive(true);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        star4.SetActive(false);
        CalcStars();
    }
    public void returnToBedroom()
    {
        examplePlayer.enabled = true;
        machineOpen = false;
        ClockOutUI.SetActive(false);
        playerInput.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
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
