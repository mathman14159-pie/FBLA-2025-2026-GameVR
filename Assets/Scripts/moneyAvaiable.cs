using UnityEngine;
using TMPro;

public class moneyAvaiable : MonoBehaviour
{
    public TMP_Text moneyText;
    public int currentMoney;
    public GameObject money1;
    public GameObject money2;
    public GameObject money3;
    public GameObject money4;
    public GameObject money5;
    public GameObject money6;
    public GameObject money7;
    public GameObject money8;
    public GameObject money9;
    public GameObject money10;
    public GameObject job1;
    public GameObject job2;
    public GameObject job3;
    public GameObject poor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money1.SetActive(false);
        money2.SetActive(false);
        money3.SetActive(false);
        money4.SetActive(false);
        money5.SetActive(false);
        money6.SetActive(false);
        money7.SetActive(false);
        money8.SetActive(false);
        money9.SetActive(false);
        money10.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentMoney = PlayerPrefs.GetInt("Money");
        moneyText.text = "$" + currentMoney.ToString();
        if (currentMoney > 5)
        {
            money1.SetActive(true);
        }
        if (currentMoney > 20)
        {
            money2.SetActive(true);
        }
        if (currentMoney > 30)
        {
            money3.SetActive(true);
        }
        if (currentMoney > 40)
        {
            money4.SetActive(true);
        }
        if (currentMoney > 50)
        {
            money5.SetActive(true);
        }
        if (currentMoney > 60)
        {
            money6.SetActive(true);
        }
        if (currentMoney > 70)
        {
            money7.SetActive(true);
        }
        if (currentMoney > 80)
        {
            money8.SetActive(true);
        }
        if (currentMoney > 90)
        {
            money9.SetActive(true);
        }
        if (currentMoney > 100)
        {
            money10.SetActive(true);
        }
    }
    public void BuyJob1()
    {
        if (currentMoney >= 30)
        {
            currentMoney -= 30;
            job1.SetActive(false);
            PlayerPrefs.SetInt("Money", currentMoney);
        }
        else
        {
            poor.SetActive(true);
            Invoke("YouAreTooPoor", 3);
        }
        
        
    }
    public void BuyJob2()
    {
        if (currentMoney >= 50)
        {
            currentMoney -= 50;
            job2.SetActive(false);
            PlayerPrefs.SetInt("Money", currentMoney);
        }
        else
        {
            poor.SetActive(true);
            Invoke("YouAreTooPoor", 3);
            PlayerPrefs.SetInt("Money", currentMoney);
        }
        
        
    }
    public void BuyJob3()
    {
        if (currentMoney >= 90)
        {
            currentMoney -= 90;
            job3.SetActive(false);
            PlayerPrefs.SetInt("Money", currentMoney);
            
        }
        else
        {
            poor.SetActive(true);
            Invoke("YouAreTooPoor", 1.0f);
        }
        
    }
    public void YouAreTooPoor()
    {
        poor.SetActive(false);
    }
}
