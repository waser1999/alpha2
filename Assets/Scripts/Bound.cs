using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bound : MonoBehaviour
{
    private CinemachineConfiner2D cinemachine;
    private SpiteEnter spites;
    private TextAnimation textAnimation;

    private void Start() {
        cinemachine = GameObject.Find("Cinemachine").GetComponent<CinemachineConfiner2D>();
        spites = GameObject.Find("Spites").GetComponent<SpiteEnter>();
        textAnimation = GetComponentInChildren<TextAnimation>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            cinemachine.m_BoundingShape2D = this.GetComponent<CompositeCollider2D>();
            spites.UpdatePostion();

            if(textAnimation != null){
                textAnimation.Typewriter();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(textAnimation != null){
            textAnimation.Exit();
        }
    }
}
