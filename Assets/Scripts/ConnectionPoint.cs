using UnityEngine;

public class ConnectionPoint : MonoBehaviour
{
    public string id;

    public IGate logicGate;

    public Wire wire = null;

    ConnectionSpawner connectionSpawner;

    private void Awake()
    {
        connectionSpawner = FindObjectOfType<ConnectionSpawner>();
        logicGate = GetComponentInParent<IGate>();
    }

    public void RegisterWire(Wire wire)
    {
        this.wire = wire;
        logicGate.RegisterWire(id, wire);
    }

    internal void DeRegisterWire()
    {
        wire = null;
        logicGate.DeRegisterWire(id);
    }

    private void OnMouseUpAsButton()
    {
        connectionSpawner.RegisterConnection(this);
    }
}