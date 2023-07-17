using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InputStruct 
{
    public int direction;
    public int jump;

    public Vector3 mousePos;
}

public class Inputs : MonoBehaviour
{
    public InputStruct inputStruct;

    public void UpdateInput() 
    {
        inputStruct.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        inputStruct.direction = (int)Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)) inputStruct.jump=1;
    }

    public InputStruct GetInput() 
    {
        InputStruct returnstruct = inputStruct;
        inputStruct.direction = 0;
        inputStruct.jump = 0;
        inputStruct.mousePos = transform.position + transform.right;
        return returnstruct;
    }
}
