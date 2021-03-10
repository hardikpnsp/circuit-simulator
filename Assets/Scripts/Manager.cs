using UnityEngine;

public class Manager : MonoBehaviour
{
    public NotGate notGatePrefab;
    public Wire wirePrefab;
    public Switch switchPrefab;

    void Start()
    {
        ConnectionPoint outputO, inputA, inputB, outputA, outputB;

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


        Wire wireO = Instantiate(wirePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        wireO.startConnectionPoint = outputO;
        wireO.endConnectionPoint = inputA;


        Wire wireA = Instantiate(wirePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        wireA.startConnectionPoint = outputA;
        wireA.endConnectionPoint = inputB;

        wireO.Register();
        wireA.Register();
    }

}
