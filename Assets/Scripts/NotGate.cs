using System;

public class NotGate : Movable, IGate
{
    Wire inputWire;
    Wire outputWire;

    public bool FullyConnected { get; set; }

    public void DeRegisterWire(string id)
    {
        switch (id)
        {
            case "Input_A":
                inputWire = null;
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
                inputWire = wire;
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

    public void CheckFullyConnected()
    {
        if (inputWire != null && outputWire != null)
        {
            FullyConnected = true;
        } else
        {
            FullyConnected = false;
        }
    }

    public void UpdateLogic()
    {
        if (FullyConnected)
        {
            bool newSignal = !inputWire.signal;
            if (newSignal != outputWire.signal)
            {
                outputWire.UpdateSignal(newSignal, this);
            }
            else if (outputWire != null && outputWire.signal)
            {
                outputWire.UpdateSignal(false, this);
            }
        }
    }
}
