using System;
using UnityEngine;

public class Switch : Movable, IGate
{
    Wire outputWire;

    [SerializeField]
    bool signal = false;

    SpriteRenderer spriteRenderer;

    public bool FullyConnected { get; set; }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }
    public void DeRegisterWire(string id)
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
        UpdateLogic();
    }

    public void RegisterWire(string id, Wire wire)
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
        UpdateLogic();
    }
    public void CheckFullyConnected()
    {
        if (outputWire != null)
        {
            FullyConnected = true;
        }
        else
        {
            FullyConnected = false;
        }
    }

    public void UpdateLogic()
    {
        if (FullyConnected && outputWire.signal != signal)
        {
            outputWire.UpdateSignal(signal, this);
        }
    }

    void UpdateColor()
    {
        if (signal)
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.red;
        }
    }

    public void OnMouseUpAsButton()
    {
        signal = !signal;
        UpdateColor();
        UpdateLogic();
    }
}
