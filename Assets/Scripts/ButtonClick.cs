using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour
{
    private Vector3 localPosition;
    private SpiteEnter spites;
    private GameObject player;
    private EndGame canvasController;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        spites = GameObject.Find("Spites").GetComponent<SpiteEnter>();
        canvasController = GameObject.FindGameObjectWithTag("GameController").GetComponent<EndGame>();
    }

    public void Exit(){
        Application.Quit();
    }

    public void Replay()
    {
        localPosition = spites.GetPosition();
        player.transform.position = localPosition;
        canvasController.HideCanvas();
    }
}
