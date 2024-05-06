using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateShow : MonoBehaviour
{
    public GameObject redPlate;
    void Start()
    {
        redPlate = GameObject.FindGameObjectWithTag("redPlate");
        redPlate.SetActive(false);
    }

    void Update()
    {
        
    }
}
