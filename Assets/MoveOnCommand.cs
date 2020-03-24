using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnCommand : MonoBehaviour
{
    public Vector3 Position
    {
        get { return transform.position; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTransform(float moveSpeed, Vector3 direction)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
