using System.Collections;
using System.Collections.Generic;
using Cinemachine;
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
    private static CinemachineConfiner2D confiner2D;
    private static CompositeCollider2D bound;
    public static bool greenActive = true;
    public static bool redActive;

    void Start()
    {
        confiner2D = GameObject.Find("Cinemachine").GetComponent<CinemachineConfiner2D>();
        redPlate = GameObject.FindGameObjectsWithTag("redPlate");
        greenPlate = GameObject.FindGameObjectsWithTag("greenPlate");
        greenActive = !redActive;
        SwitchActive();
    }

    private static void SwitchActive()
    {
        bound = confiner2D.m_BoundingShape2D.GetComponent<CompositeCollider2D>();
        
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
