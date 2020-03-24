using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMoventAlongAxis : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10;
    [SerializeField]
    private bool moveAlongX = true;
    [SerializeField]
    private bool moveAlongY = true;
    // TODO have camera figure out bounds
    [SerializeField]
    private Vector3 bounds = new Vector3(8.75f, 5, 1);

    private PlayerInput playerInput;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 newPos = rb.position;

        if(moveAlongX)
        {
            newPos.x += playerInput.InputAxis.x * moveSpeed * Time.fixedDeltaTime;
            newPos.x = Mathf.Clamp(newPos.x, -bounds.x, bounds.x);
        }
        

        if(moveAlongY)
        {
            newPos.y += playerInput.InputAxis.y * moveSpeed * Time.fixedDeltaTime;
            newPos.y = Mathf.Clamp(newPos.y, -bounds.y, bounds.y);
        }
        

        rb.MovePosition(newPos);
    }
}
