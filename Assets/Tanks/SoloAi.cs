using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloAi : MonoBehaviour, IUpdate
{
    private Transform playerTransform;
    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    
    public void Tick()
    {
        if (playerTransform == null)
        {
            return;
        }
        transform.LookAt(playerTransform);
        transform.Translate(0, 0, 0.05f);
    }
}
