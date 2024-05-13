using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bound : MonoBehaviour
{
    public CinemachineConfiner2D cinemachine;

    private void Start() {
        cinemachine = GameObject.Find("Cinemachine").GetComponent<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            cinemachine.m_BoundingShape2D = this.GetComponent<CompositeCollider2D>();
        }
    }
}
