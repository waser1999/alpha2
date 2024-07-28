using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static PlateShow;

public class SwitchTrigger : MonoBehaviour
{
    private PlateShow plate;

    private void Start()
    {
        plate = GameObject.Find("Plates").GetComponent<PlateShow>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            plate.SwitchPlates();
        }
    }
}
