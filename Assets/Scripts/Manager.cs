using UnityEngine;

public class Manager : MonoBehaviour
{
    public NotGate notGatePrefab;
    public Wire wirePrefab;
    public Switch switchPrefab;

    void Start()
    {
        ConnectionPoint outputO, inputA, inputB, outputA, outputB, outputC, inputC;

        Switch s = Instantiate(switchPrefab, new Vector3(-5, 0, 0), Quaternion.identity);
        ConnectionPoint[] pointO = s.GetComponentsInChildren<ConnectionPoint>();

        outputO = pointO[0];

        NotGate notGateA = Instantiate(notGatePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        ConnectionPoint[] pointsA = notGateA.GetComponentsInChildren<ConnectionPoint>();

        inputA = pointsA[0];
        outputA = pointsA[1];

        NotGate notGateB = Instantiate(notGatePrefab, new Vector3(5, 0, 0), Quaternion.identity);
        ConnectionPoint[] pointsB = notGateB.GetComponentsInChildren<ConnectionPoint>();

        inputB = pointsB[0];
        outputB = pointsB[1];

        NotGate notGateC = Instantiate(notGatePrefab, new Vector3(5, 2, 0), Quaternion.identity);
        ConnectionPoint[] pointsC = notGateC.GetComponentsInChildren<ConnectionPoint>();

        inputC = pointsC[0];
        outputC = pointsC[1];


        Wire wireO = Instantiate(wirePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        wireO.AddStartConnection(outputO);
        wireO.AddEndConnection(inputA);

        Wire wireA = Instantiate(wirePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        wireA.AddStartConnection(outputA);
        wireA.AddEndConnection(inputB);
        wireA.AddEndConnection(inputC);

        wireO.Register();
        wireA.Register();
    }

}
