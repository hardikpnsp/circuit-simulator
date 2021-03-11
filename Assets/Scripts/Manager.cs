using UnityEngine;

public class Manager : MonoBehaviour
{
    public NotGate notGatePrefab;
    public Wire wirePrefab;
    public Switch switchPrefab;
    public Probe probePrefab;

    void Start()
    {
        ConnectionPoint outputO, inputA, inputB, outputA, outputB, outputC, inputC, inputP1, inputP2, inputP3;

        Switch s = Instantiate(switchPrefab, new Vector3(-5, 0, 0), Quaternion.identity);
        ConnectionPoint[] pointO = s.GetComponentsInChildren<ConnectionPoint>();

        outputO = pointO[0];

        NotGate notGateA = Instantiate(notGatePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        ConnectionPoint[] pointsA = notGateA.GetComponentsInChildren<ConnectionPoint>();

        inputA = pointsA[0];
        outputA = pointsA[1];

        NotGate notGateB = Instantiate(notGatePrefab, new Vector3(5, -2, 0), Quaternion.identity);
        ConnectionPoint[] pointsB = notGateB.GetComponentsInChildren<ConnectionPoint>();

        inputB = pointsB[0];
        outputB = pointsB[1];

        NotGate notGateC = Instantiate(notGatePrefab, new Vector3(5, 2, 0), Quaternion.identity);
        ConnectionPoint[] pointsC = notGateC.GetComponentsInChildren<ConnectionPoint>();

        inputC = pointsC[0];
        outputC = pointsC[1];

        Probe p1 = Instantiate(probePrefab, new Vector3(7, -2, 0), Quaternion.identity);
        ConnectionPoint[] pointsP1 = p1.GetComponentsInChildren<ConnectionPoint>();

        inputP1 = pointsP1[0];

        Probe p2 = Instantiate(probePrefab, new Vector3(7, 2, 0), Quaternion.identity);
        ConnectionPoint[] pointsP2 = p2.GetComponentsInChildren<ConnectionPoint>();

        inputP2 = pointsP2[0];

        Probe p3 = Instantiate(probePrefab, new Vector3(7, 0, 0), Quaternion.identity);
        ConnectionPoint[] pointsP3 = p3.GetComponentsInChildren<ConnectionPoint>();

        inputP3 = pointsP3[0];

        Wire wireO = Instantiate(wirePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        wireO.AddStartConnection(outputO);
        wireO.AddEndConnection(inputA);
        wireO.Register();

        Wire wireA = Instantiate(wirePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        wireA.AddStartConnection(outputA);
        wireA.AddEndConnection(inputB);
        wireA.AddEndConnection(inputC);
        wireA.AddEndConnection(inputP3);
        wireA.Register();

        Wire wireP1 = Instantiate(wirePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        wireP1.AddStartConnection(outputB);
        wireP1.AddEndConnection(inputP1);

        Wire wireP2 = Instantiate(wirePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        wireP2.AddStartConnection(outputC);
        wireP2.AddEndConnection(inputP2);

        wireP1.Register();
        wireP2.Register();

    }

}
