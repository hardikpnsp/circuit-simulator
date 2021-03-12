using System;
using UnityEngine;

public class Probe : Movable, IGate
{
    Wire inputWire;

    [SerializeField]
    bool signal = false;
    public bool FullyConnected { get; set; }

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }
    public void CheckFullyConnected()
    {
        if (inputWire != null)
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
                inputWire = null;
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
            default:
                throw new Exception("ID not supported");
        }
        CheckFullyConnected();
    }

    public void UpdateLogic()
    {
        if (FullyConnected)
        {
            signal = inputWire.signal;
            UpdateColor();
        }
    }

    void UpdateColor()
    {
        if (signal)
        {
            spriteRenderer.color = Color.yellow;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }
}
