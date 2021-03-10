using System;
using UnityEngine;

public class Switch : Gate
{
    Wire outputWire;

    [SerializeField]
    bool signal = false;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public override void DeRegisterWire(string id)
    {
        switch (id)
        {
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
        if (outputWire != null)
        {
            fullyConnected = true;
        }
        else
        {
            fullyConnected = false;
        }
    }

    public override void UpdateLogic()
    {
        // Do nothing
    }

    private void OnMouseDown()
    {
        signal = !signal;
        if (signal)
        {
            spriteRenderer.color = new Color(0.0f, 0.7f, 0.03f);
        } else
        {
            spriteRenderer.color = new Color(0.7f, 0.0f, 0.03f);
        }
        if (fullyConnected)
        {
            outputWire.UpdateSignal(signal, this);
        }
    }
}
