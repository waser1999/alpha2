using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bound : MonoBehaviour
{
    private CinemachineConfiner2D cinemachine;
    private GameObject spites;

    private void Start() {
        cinemachine = GameObject.Find("Cinemachine").GetComponent<CinemachineConfiner2D>();
        spites = GameObject.Find("Spites");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            cinemachine.m_BoundingShape2D = this.GetComponent<CompositeCollider2D>();
            ExecuteEvents.Execute<IUpdatePosition>(spites, null, (handler, data) => handler.UpdatePostion());
        }
    }
}
