using System;

public class OrGate : Movable, IGate
{
    Wire inputWireA;
    Wire inputWireB;
    Wire outputWire;

    public bool FullyConnected { get; set; }
    public void CheckFullyConnected()
    {
        if (inputWireA != null && inputWireB != null && outputWire != null)
        {
            FullyConnected = true;
        }
        else
        {
            FullyConnected = false;
        }
    }

    public void DeRegisterWire(string id)
    {
        switch (id)
        {
            case "Input_A":
                inputWireA = null;
                break;
            case "Input_B":
                inputWireB = null;
                break;
            case "Output_A":
                outputWire = null;
                break;
            default:
                throw new Exception("ID not supported");
        }
        CheckFullyConnected();
        UpdateLogic();
    }

    public void RegisterWire(string id, Wire wire)
    {
        switch (id)
        {
            case "Input_A":
                inputWireA = wire;
                break;
            case "Input_B":
                inputWireB = wire;
                break;
            case "Output_A":
                outputWire = wire;
                break;
            default:
                throw new Exception("ID not supported");
        }
        CheckFullyConnected();
        UpdateLogic();
    }

    public void UpdateLogic()
    {
        if (FullyConnected)
        {
            bool newSignal = inputWireA.signal || inputWireB.signal;
            if (newSignal != outputWire.signal)
            {
                outputWire.UpdateSignal(newSignal, this);
            }
        }
        else if (outputWire != null && outputWire.signal)
        {
            outputWire.UpdateSignal(false, this);
        }
    }
}
