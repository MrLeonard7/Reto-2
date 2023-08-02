using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekpointController : MonoBehaviour
{
    public static ChekpointController instance;
    
    public Chekpoint[] chekpoints;

    public Vector3 spawnPoint;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        chekpoints = FindObjectsOfType<Chekpoint>();

        spawnPoint = PlayerController.instance.transform.position;
    }

    public void DeactivateCheckpoints()
    {
        for(int i = 0; i < chekpoints.Length; i++)
        {
            chekpoints[i].ResetCheckpoint();
        }
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
