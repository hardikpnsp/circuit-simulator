using UnityEngine;

public class ConnectionPoint: MonoBehaviour
{
    public string id;

    public IGate logicGate;

    private void Awake()
    {
        logicGate = GetComponentInParent<IGate>();
    }

    public void RegisterWire(Wire wire)
    {
        logicGate.RegisterWire(id, wire);
    }

    internal void DeRegisterWire()
    {
        logicGate.DeRegisterWire(id);
    }
}