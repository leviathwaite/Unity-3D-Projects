using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrid : MonoBehaviour
{
    public GameObject prefabToSpawn;

    [SerializeField]
    private int numberPerRow = 11;
    [SerializeField]
    private int numberPerColumn = 5;
    [SerializeField]
    private float rowSpacing = 1;
    [SerializeField]
    private float columnSpacing = 1;

    private GameObject[] gameObjects;

    public GameObject[] GameObjects
    {
        get { return gameObjects; }
    }

    public int LengthOfGameObjectsArray
    {
        get { return (numberPerRow * numberPerColumn) - 1; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        SpawnPrefabs();
    }

    private void SpawnPrefabs()
    {
        gameObjects = new GameObject[numberPerRow * numberPerColumn];

        Vector3 spawnPosition = transform.position;
        spawnPosition.x -= (numberPerRow * rowSpacing) / 2;
        spawnPosition.y += (numberPerColumn * columnSpacing) / 2;

        float startingPositionX = spawnPosition.x;

        int counter = 0;

        for (int i = 0; i < numberPerColumn; i++)
        {
            for (int j = 0; j < numberPerRow; j++)
            {
                GameObject temp = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
                temp.transform.parent = transform;
                gameObjects[counter] = temp;
                counter++;

                spawnPosition.x += rowSpacing;
            }

            spawnPosition.x = startingPositionX;
            spawnPosition.y += columnSpacing;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
