using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private CanvasGroup canvasGroup; 
    private PlayerMovement player;
    private bool canvasVisible;

    private void Start() {
        canvasGroup = GameObject.Find("Canvas").GetComponent<CanvasGroup>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        HideCanvas();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            ShowCanvas();
        }
    }

    private void Update() {
        if(Input.GetButtonDown("Cancel")){
            if(canvasVisible){
                HideCanvas();
            }else{
                ShowCanvas();
            }
        }
    }

    private void HideCanvas(){
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        player.enabled = true;
        Time.timeScale = 1f;
        canvasVisible = false;
    }

    private void ShowCanvas(){
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        player.enabled = false;
        Time.timeScale = 0f;
        canvasVisible = true;
    }
}
