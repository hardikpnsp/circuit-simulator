using UnityEngine;

public abstract class Gate : MonoBehaviour, IGate
{
    public bool fullyConnected { get; set; }

    public virtual void CheckFullyConnected()
    {
        throw new System.NotImplementedException();
    }

    public virtual void DeRegisterWire(string id)
    {
        throw new System.NotImplementedException();
    }

    public virtual void RegisterWire(string id, Wire wire)
    {
        throw new System.NotImplementedException();
    }

    public virtual void UpdateLogic()
    {
        throw new System.NotImplementedException();
    }
}