using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour
{
    private Vector3 localPosition;
    private GameObject spites;
    private GameObject player;
    private GameObject canvasController;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        spites = GameObject.Find("Spites");
        canvasController = GameObject.FindGameObjectWithTag("GameController");
    }

    public void Exit(){
        Application.Quit();
    }

    public void Replay()
    {
        ExecuteEvents.Execute<IUpdatePosition>(spites, null, (handler, data) => 
            localPosition = handler.GetPosition()
        );
        player.transform.position = localPosition;
        ExecuteEvents.Execute<ICanvasController>(canvasController, null, (handler, data) => handler.HideCanvas());
    }
}
