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
        if(ElympicsBehaviour.TryGetInput(PredictableFor, out var inputReader))
        {
            inputReader.Read(out currentInput.direction);
            inputReader.Read(out currentInput.jump);
        }
        movement.Movement(currentInput.direction, currentInput.jump);
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
    }
}
