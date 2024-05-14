using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IUpdatePosition: IEventSystemHandler{
    void UpdatePostion();
}

public class SpiteEnter : MonoBehaviour, IUpdatePosition
{
    private Vector3 playerPosition;
    public float margin;

    private void Start() {
        UpdatePostion();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Debug.Log("enter");
            other.transform.position = playerPosition;
        }
    }

    public void UpdatePostion()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerPosition = player.position;
        if(player.localScale.x == 1){
            playerPosition += margin * Vector3.left;
        }else{
            playerPosition += margin * Vector3.right;
        }
    }
}
