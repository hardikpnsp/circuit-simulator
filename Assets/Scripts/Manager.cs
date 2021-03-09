using UnityEngine;

public class Manager : MonoBehaviour
{
    public NotGate notGatePrefab;
    public Wire wirePrefab;

    void Start()
    {
        ConnectionPoint inputA, inputB, inputC, outputA, outputB, outputC;

        NotGate notGateA = Instantiate(notGatePrefab, new Vector3(-5, 0, 0), Quaternion.identity);
        ConnectionPoint[] pointsA = notGateA.GetComponentsInChildren<ConnectionPoint>();

        inputA = pointsA[0];
        outputA = pointsA[1];

        NotGate notGateB = Instantiate(notGatePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        ConnectionPoint[] pointsB = notGateB.GetComponentsInChildren<ConnectionPoint>();

        inputB = pointsB[0];
        outputB = pointsB[1];

        NotGate notGateC = Instantiate(notGatePrefab, new Vector3(5, 0, 0), Quaternion.identity);
        ConnectionPoint[] pointsC = notGateC.GetComponentsInChildren<ConnectionPoint>();

        inputC = pointsC[0];
        outputC = pointsC[1];

        Wire wireA = Instantiate(wirePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        wireA.startConnectionPoint = outputA;
        wireA.endConnectionPoint = inputB;

        Wire wireB = Instantiate(wirePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        wireB.startConnectionPoint = outputB;
        wireB.endConnectionPoint = inputC;

        wireB.Register();
        wireA.Register();
    }

}
