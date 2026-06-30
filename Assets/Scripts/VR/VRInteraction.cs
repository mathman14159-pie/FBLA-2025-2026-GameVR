using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using KinematicCharacterController.Examples;
using System.Collections;
using System.Collections.Generic;





public class VRInteraction : MonoBehaviour
{
    [SerializeField] private InputActionReference interactAction;
    public GameObject hand;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    Ray ray = new Ray(hand.transform.position, hand.transform.forward);

    if (Physics.Raycast(ray, out RaycastHit hit, 2f))
    {
        Debug.Log("raycastHit");
        if (interactAction.action.WasPressedThisFrame())
            {
                Debug.Log("interact pressed");
                if (hit.collider.TryGetComponent<JobIdentifier>(out JobIdentifier job))
                {
                    Debug.Log("SceneOpen");
                    SceneManager.LoadScene("Job " + job.jobNumber);
                }
            }
       
    }
    }

    
}
