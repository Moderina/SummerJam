using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InputStruct 
{
    public int direction;
    public int jump;
}

public class Inputs : MonoBehaviour
{
    public InputStruct inputStruct;

    public void UpdateInput() 
    {
        inputStruct.direction = (int)Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)) inputStruct.jump=1;
    }

    public InputStruct GetInput() 
    {
        InputStruct returnstruct = inputStruct;
        inputStruct.direction = 0;
        inputStruct.jump = 0;
        return returnstruct;
    }
}
