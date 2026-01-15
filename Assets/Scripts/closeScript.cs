using UnityEngine;
using Unity.UI;

public class closeScript : MonoBehaviour
{
    public GameObject UIObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseUI()
    {
        UIObject.SetActive(false);
    }
}
