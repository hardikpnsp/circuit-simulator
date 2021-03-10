using System;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public ConnectionPoint startConnectionPoint;

    [SerializeField]
    public List<Tuple<ConnectionPoint, LineRenderer>> endConnectionPoints = new List<Tuple<ConnectionPoint, LineRenderer>>();

    public bool render = false;

    public bool signal = false;

    public HashSet<IGate> registeredGates = new HashSet<IGate>();

    [SerializeField]
    public GameObject WireChildPrefab;

    void Update()
    {
        if (render)
        {
            Vector3 startPos = startConnectionPoint.transform.position;
            foreach (Tuple<ConnectionPoint, LineRenderer> tuple in endConnectionPoints)
            {
                LineRenderer lineRenderer = tuple.Item2;
                ConnectionPoint connectionPoint = tuple.Item1;
                Vector3 endPos = connectionPoint.transform.position;
                Vector3 middlePoint = new Vector3(startPos.x, endPos.y);
                Vector3[] pos = { startPos, middlePoint, endPos };
                lineRenderer.SetPositions(pos);
            }
        }
    }

    public void AddEndConnection(ConnectionPoint connectionPoint)
    {
        GameObject wireChild = Instantiate(WireChildPrefab, Vector3.zero, Quaternion.identity);
        wireChild.transform.SetParent(gameObject.transform);
        LineRenderer lineRenderer = wireChild.GetComponent<LineRenderer>();
        endConnectionPoints.Add(new Tuple<ConnectionPoint, LineRenderer>(connectionPoint, lineRenderer));
    }

    public void AddStartConnection(ConnectionPoint connectionPoint)
    {
        startConnectionPoint = connectionPoint;
    }

    public void Register()
    {
        registeredGates.Add(startConnectionPoint.logicGate);
        foreach (Tuple<ConnectionPoint, LineRenderer> tuple in endConnectionPoints)
        {
            registeredGates.Add(tuple.Item1.logicGate);
            tuple.Item1.RegisterWire(this);
        }
        startConnectionPoint.RegisterWire(this);
        render = true;
        UpdateSignal();
    }

    public void DeRegister(ConnectionPoint deregisterConnectionPoint)
    {
        render = false;
        registeredGates = new HashSet<IGate>();
        if (startConnectionPoint == deregisterConnectionPoint)
        {
            startConnectionPoint.DeRegisterWire();
            Destroy(gameObject);
        } 
        else
        {
            deregisterConnectionPoint.DeRegisterWire();
            registeredGates.Remove(deregisterConnectionPoint.logicGate);
        }
    }

    public void UpdateSignal()
    {
        foreach (IGate logicGate in registeredGates)
        {
            logicGate.UpdateLogic();
        }
    }

    public void UpdateSignal(bool newSignal, IGate currentLogicGate)
    {
        signal = newSignal;
        foreach (IGate logicGate in registeredGates)
        {
            if (logicGate != currentLogicGate)
            {
                logicGate.UpdateLogic();
            }
        }
    }
}
