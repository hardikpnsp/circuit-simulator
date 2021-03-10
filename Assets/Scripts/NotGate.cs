using System;
using UnityEngine;

public class NotGate : MonoBehaviour, IGate
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
            outputWire.UpdateSignal(!inputWire.signal, this);
        }
    }

}
