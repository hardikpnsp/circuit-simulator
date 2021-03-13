using UnityEngine;

public class ConnectionSpawner : MonoBehaviour
{
    enum State
    {
        ZERO_CONNECTED,
        ONE_CONNECTED,
        ALREADY_CONNECTED
    };

    State currentState = State.ZERO_CONNECTED;

    ConnectionPoint start = null;

    [SerializeField]
    private Wire wirePrefab;

    LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 3;
        lineRenderer.enabled = false;
    }
    void backToZeroConnected()
    {
        start = null;
        lineRenderer.enabled = false;
        currentState = State.ZERO_CONNECTED;
    }

    public void RegisterConnection(ConnectionPoint connectionPoint)
    {

        bool isBadEndConnection()
        {
            return connectionPoint.connectionType == ConnectionPoint.ConnectionType.OUTPUT
                || start == connectionPoint
                || connectionPoint.wire != null;
        }

        bool isBadStartConnection()
        {
            return connectionPoint.connectionType == ConnectionPoint.ConnectionType.INPUT;
        }


        if (currentState == State.ZERO_CONNECTED)
        {
            // Can only start connection at Output and end at Input
            if (isBadStartConnection())
            {
                backToZeroConnected();
            }
            else
            {
                lineRenderer.enabled = true;
                start = connectionPoint;
                if (connectionPoint.wire != null)
                {
                    currentState = State.ALREADY_CONNECTED;
                }
                else
                {
                    currentState = State.ONE_CONNECTED;
                }
                UpdateLineRenderer();
            }
        }
        else if (currentState == State.ONE_CONNECTED)
        {
            if (isBadEndConnection())
            {
                backToZeroConnected();
            }
            else
            {
                Wire wire = Instantiate(wirePrefab, new Vector3(0, 0, 0), Quaternion.identity);
                wire.AddStartConnection(start);
                wire.AddEndConnection(connectionPoint);
                wire.Register();
                backToZeroConnected();
            }
        }
        else if (currentState == State.ALREADY_CONNECTED)
        {
            if (isBadEndConnection())
            {
                backToZeroConnected();
            }
            else
            {
                lineRenderer.enabled = false;
                Wire wire = start.wire;
                if (connectionPoint.wire == null)
                {
                    wire.AddEndConnection(connectionPoint);
                    wire.Register();
                }
                backToZeroConnected();
            }
        }
    }


    private void UpdateLineRenderer()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 middlePos = new Vector3(start.transform.position.x, mousePos.y, 0);
        Vector3[] pos = { start.transform.position, middlePos, mousePos };
        lineRenderer.SetPositions(pos);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            backToZeroConnected();
        }
        if (currentState != State.ZERO_CONNECTED)
        {
            UpdateLineRenderer();
        }
    }
}
