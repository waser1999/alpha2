using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static PlateShow;

public class SwitchTrigger : MonoBehaviour
{
    private GameObject plate;

    private void Start()
    {
        plate = GameObject.Find("Plates");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ExecuteEvents.Execute<IPlateActive>(plate, null, (handler, data) => handler.SwitchPlates());
        }
    }
}
