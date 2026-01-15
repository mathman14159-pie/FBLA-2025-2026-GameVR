using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class PlayerModeManager : MonoBehaviour
{
    public GameObject desktopPlayer;
    public GameObject xrPlayer;

    void Start()
    {
        Invoke(nameof(CheckXR), 0.5f);
    }

    void CheckXR()
    {
        List<XRDisplaySubsystem> displays = new List<XRDisplaySubsystem>();
        SubsystemManager.GetSubsystems(displays);

        bool xrRunning = false;
        foreach (var d in displays)
        {
            if (d.running)
            {
                xrRunning = true;
                break;
            }
        }

        if (xrRunning)
        {
            desktopPlayer.SetActive(false);
            xrPlayer.SetActive(true);
        }
        else
        {
            xrPlayer.SetActive(false);
            desktopPlayer.SetActive(true);
        }
    }
}
