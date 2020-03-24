using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO Add pooling
public class SpawnPrefab : MonoBehaviour
{
    public GameObject prefabToSpawn;

    [SerializeField]
    private Vector3 spawnPositionOffset = Vector3.zero;
    [SerializeField]
    private Vector3 spawnRotation = Vector3.zero;
    [SerializeField]
    private string spawnTag = "PlayerBullet";
    [SerializeField]
    private Transform parent = null;
    [SerializeField]
    private Color color = new Color(1, 0, 1, 1); // pink
    
    // Start is called before the first frame update
    void Start()
    {
        Material _material = GetComponentInChildren<Renderer>().material;
        if(_material)
        {
            _material.color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnGameObject()
    {
        GameObject temp = Instantiate(prefabToSpawn, transform.position + spawnPositionOffset, Quaternion.Euler(spawnRotation));
        temp.tag = spawnTag;
        if(parent)
        {
            temp.transform.parent = parent;
        }
    }
}
