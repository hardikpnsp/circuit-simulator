using UnityEngine;

public class ConnectionPoint: MonoBehaviour
{
    public string id;

    public Gate logicGate;

    public void RegisterWire(Wire wire)
    {
        logicGate.RegisterWire(id, wire);
    }

    internal void DeRegisterWire()
    {
        logicGate.DeRegisterWire(id);
    }
}