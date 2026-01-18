using UnityEngine;
using UnityEngine.SceneManagement;

public class typingCode : MonoBehaviour
{
    public int timeTyped = 0;
    public GameObject word1;
    public GameObject word2;    
    public GameObject word3;
    public GameObject word4;
    public GameObject word5;
    public GameObject word6;
    public GameObject word7;
    public GameObject word8;
    public GameObject word9;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("timesTyped", 0 );

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timeTyped += 1;
        }
        if (timeTyped > 0)
        {
            word1.SetActive(true);
        }
        if (timeTyped > 5)
        {
            word2.SetActive(true);
        }
        if (timeTyped > 12)
        {
            word3.SetActive(true);
        }
        if (timeTyped > 17)
        {
            word4.SetActive(true);
        }
        if (timeTyped > 22)
        {
            word5.SetActive(true);
        }
        if (timeTyped > 24)
        {
            word6.SetActive(true);
        }
        if (timeTyped > 30)
        {
            word7.SetActive(true);
        }
        if (timeTyped > 34)
        {
            word8.SetActive(true);
        }
        if (timeTyped > 39)
        {
            word9.SetActive(true);
        }
    
    }
    public void closeJob()
    {
        PlayerPrefs.SetInt("timesTyped", timeTyped);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Job 5");
        Debug.Log("Close" + PlayerPrefs.GetInt("timesTyped"));
    }
}
