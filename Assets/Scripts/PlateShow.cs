using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IPlateActive : IEventSystemHandler
{
    void SwitchPlates();
}

public class PlateShow : MonoBehaviour, IPlateActive
{
    private static GameObject[] redPlate;
    private static GameObject[] greenPlate;
    public static bool greenActive = true;
    public static bool redActive;

    void Start()
    {
        redPlate = GameObject.FindGameObjectsWithTag("redPlate");
        greenPlate = GameObject.FindGameObjectsWithTag("greenPlate");
        greenActive = !redActive;
        SwitchActive();
    }

    public static void SwitchActive()
    {
        foreach (GameObject redObject in redPlate)
        {
            redObject.SetActive(redActive);
        }

        foreach (GameObject greenObject in greenPlate)
        {
            greenObject.SetActive(greenActive);
        }
    }

    public void SwitchPlates()
    {
        redActive = !redActive;
        greenActive = !greenActive;
        SwitchActive();
    }
}
