using UnityEngine;

public interface IGate
{
    public bool FullyConnected { get; set; }
    public void RegisterWire(string id, Wire wire);
    public void DeRegisterWire(string id);
    void CheckFullyConnected();
    void UpdateLogic();
}
