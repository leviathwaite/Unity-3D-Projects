using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnStart : MonoBehaviour
{
    [SerializeField]
    private float force = 100;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
