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

    public void RegisterConnection(ConnectionPoint connectionPoint)
    {
        if (currentState == State.ZERO_CONNECTED)
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
        else if (currentState == State.ONE_CONNECTED)
        {
            if (start == connectionPoint)
            {
                start = null;
                currentState = State.ZERO_CONNECTED;
            }
            else
            {
                lineRenderer.enabled = false;
                Wire wire = Instantiate(wirePrefab, new Vector3(0, 0, 0), Quaternion.identity);
                wire.AddStartConnection(start);
                wire.AddEndConnection(connectionPoint);
                wire.Register();
                start = null;
                currentState = State.ZERO_CONNECTED;
            }
        }
        else if (currentState == State.ALREADY_CONNECTED)
        {
            if (start == connectionPoint)
            {
                start = null;
                currentState = State.ZERO_CONNECTED;
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
                start = null;
                currentState = State.ZERO_CONNECTED;
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
        if (currentState != State.ZERO_CONNECTED)
        {
            UpdateLineRenderer();
        }
    }
}
