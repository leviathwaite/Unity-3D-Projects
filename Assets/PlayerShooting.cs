using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnPrefab))]
public class PlayerShooting : MonoBehaviour
{
    private SpawnPrefab spawnPrefab;
    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        spawnPrefab = GetComponent<SpawnPrefab>();
        playerInput = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInput.IsFire1Released)
        {
            spawnPrefab.SpawnGameObject();
        }
    }
}
