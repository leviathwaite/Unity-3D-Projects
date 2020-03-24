using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvadersController : MonoBehaviour
{
    [SerializeField]
    private float moveTime = 2;
    [SerializeField]
    private bool movingRight = true;
    [SerializeField]
    private float moveSpeed = 5;
    [SerializeField]
    private float moveSpeedIncreaseFactor = 1.5f;
    [SerializeField]
    private float maxSpeed = 10;
    [SerializeField]
    private float moveDownSpeed = 20;
    [SerializeField]
    private float boundsX = 6;
    [SerializeField]
    private float lowerBoundsY = -4;

    [SerializeField]
    private float moveTimer = 0;

    private float startingMoveSpeed;
    private SpawnGrid spawnGrid;
    private MoveOnCommand[] invadersMoveOnCommand;

    // Start is called before the first frame update
    void Start()
    {
        startingMoveSpeed = moveSpeed;

        spawnGrid = GetComponent<SpawnGrid>();
        SetupInvadersMoveCommand();
    }

    private void Reset()
    {
        
    }

    private void SetupInvadersMoveCommand()
    {
        
        invadersMoveOnCommand = new MoveOnCommand[spawnGrid.LengthOfGameObjectsArray];
        GameObject[] gameObjects = spawnGrid.GameObjects;

        for (int i = 0; i < invadersMoveOnCommand.Length; i++)
        {
            invadersMoveOnCommand[i] = gameObjects[i].GetComponent<MoveOnCommand>();
        }
    }

    private void ResetMoveTimer()
    {
        moveTimer = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        TickMoveTimer();
    }

    // Move Timer needs work, randomly jumps too far.
    private void TickMoveTimer()
    {
        moveTimer -= Time.deltaTime;
        if(moveTimer < 0)
        {
            ResetMoveTimer();
            MoveInvaders();
        }
    }

    private void MoveInvaders()
    {
        

        if(movingRight)
        {
            foreach (MoveOnCommand invader in invadersMoveOnCommand)
            {
                invader.MoveTransform(moveSpeed, Vector3.right);
            }
        }
        else
        {
            foreach (MoveOnCommand invader in invadersMoveOnCommand)
            {
                invader.MoveTransform(moveSpeed, Vector3.left);
            }
        }

        CheckForBounds();
    }

    private void CheckForBounds()
    {
        foreach (MoveOnCommand invader in invadersMoveOnCommand)
        {
            if (movingRight)
            {
                if (invader.Position.x > boundsX)
                {
                    movingRight = false;
                    MoveDown();
                }
            }
            else
            {
                if (invader.Position.x < -boundsX)
                {
                    movingRight = true;
                    MoveDown();
                }
            }
            
        }
    }

    private void MoveDown()
    {
        foreach (MoveOnCommand invader in invadersMoveOnCommand)
        {
            invader.MoveTransform(moveDownSpeed, Vector3.down);
        }

        IncreaseMoveSpeed();
    }

    private void IncreaseMoveSpeed()
    {
        moveSpeed *= moveSpeedIncreaseFactor;
    }
}
