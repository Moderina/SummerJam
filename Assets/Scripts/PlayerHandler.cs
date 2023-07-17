using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Elympics;

public class PlayerHandler : ElympicsMonoBehaviour, IInputHandler, IUpdatable
{
    [SerializeField] private Inputs inputs;
    [SerializeField] private MOve movement;

    private void Update() 
    {
        if(Elympics.Player != PredictableFor) return;
        inputs.UpdateInput();
    }
    public void ElympicsUpdate()
    {
        
        InputStruct currentInput;
        currentInput.direction = 0;
        currentInput.jump = 0;
        currentInput.mousePos = transform.position + transform.right;
        if(ElympicsBehaviour.TryGetInput(PredictableFor, out var inputReader))
        {
            float x,y,z;
            inputReader.Read(out currentInput.direction);
            inputReader.Read(out currentInput.jump);
            inputReader.Read(out x);
            inputReader.Read(out y);
            inputReader.Read(out z);
            currentInput.mousePos = new Vector3(x,y,z);
        }
        movement.Movement(currentInput.direction, currentInput.jump, currentInput.mousePos);
    }

    public void OnInputForBot(IInputWriter inputSerializer)
    {
        //throw new System.NotImplementedException();
    }

    public void OnInputForClient(IInputWriter inputSerializer)
    {
        InputStruct currentInputs = inputs.GetInput();
        inputSerializer.Write(currentInputs.direction);
        inputSerializer.Write(currentInputs.jump);
        inputSerializer.Write(currentInputs.mousePos.x);
        inputSerializer.Write(currentInputs.mousePos.y);
        inputSerializer.Write(currentInputs.mousePos.z);
    }
}
