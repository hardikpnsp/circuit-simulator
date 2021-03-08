using System;
using UnityEngine;

public class NotGate : Gate
{
    Wire inputWire;
    Wire outputWire;

    public override void DeRegisterWire(string id)
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

    public override void RegisterWire(string id, Wire wire)
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

    public override void CheckFullyConnected()
    {
        if (inputWire != null && outputWire != null)
        {
            Debug.Log("Fully Connected!");
            fullyConnected = true;
        } else
        {
            fullyConnected = false;
        }
    }

}
