using System;
using System.Collections;
using UnityEngine;

public class Clock : Movable, IGate
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
        Debug.Log("OK");
        StartCoroutine("PulseClock");
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
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.red;
        }
    }

    private IEnumerator PulseClock()
    {
        while (true)
        {
            signal = !signal;
            UpdateColor();
            if (FullyConnected)
            {
                outputWire.UpdateSignal(signal, this);
            }
            Debug.Log("One");
            yield return new WaitForSeconds(0.5f);
        }
    }
}
