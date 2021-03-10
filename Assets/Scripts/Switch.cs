using System;
using UnityEngine;

public class Switch : MonoBehaviour, IGate
{
    Wire outputWire;

    [SerializeField]
    bool signal = false;

    SpriteRenderer spriteRenderer;

    public bool FullyConnected { get; set; }

    private void Start()
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
        // Do nothing
    }

    void UpdateColor()
    {
        if (signal)
        {
            spriteRenderer.color = new Color(0.0f, 0.7f, 0.03f);
        }
        else
        {
            spriteRenderer.color = new Color(0.7f, 0.0f, 0.03f);
        }
    }

    private void OnMouseDown()
    {
        signal = !signal;
        UpdateColor();
        if (FullyConnected)
        {
            outputWire.UpdateSignal(signal, this);
        }
    }
}
