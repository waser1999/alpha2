using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IUpdatePosition: IEventSystemHandler{
    void UpdatePostion();
    Vector3 GetPosition();
}

public class SpiteEnter : MonoBehaviour, IUpdatePosition
{
    private Transform player;
    private Vector3 playerPosition;
    public float margin;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        UpdatePostion();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.transform.position = playerPosition;
        }
    }

    public void UpdatePostion()
    {
        playerPosition = player.position;
        if(player.localScale.x == 1){
            playerPosition += margin * Vector3.left;
        }else{
            playerPosition += margin * Vector3.right;
        }
    }

    public Vector3 GetPosition()
    {
        return playerPosition;
    }
}
