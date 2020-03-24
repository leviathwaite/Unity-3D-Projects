using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO make sigleton?
public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private string horizontalAxisString = "Horizontal";
    [SerializeField]
    private string verticalAxisString = "Vertical";
    [SerializeField]
    private string fire1String = "Fire1";

    private Vector2 inputAxis;
    private bool isFire1Released = false;

    public Vector2 InputAxis
    {
        get{ return inputAxis; }
    }

    public bool IsFire1Released
    {
        get { return isFire1Released; }
    }

    // Start is called before the first frame update
    void Start()
    {
        inputAxis = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        inputAxis.x = Input.GetAxis(horizontalAxisString);
        inputAxis.y = Input.GetAxis(verticalAxisString);

        isFire1Released = Input.GetButtonUp(fire1String);
    }
}
