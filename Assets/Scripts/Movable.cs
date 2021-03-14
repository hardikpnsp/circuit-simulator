using UnityEngine;
using UnityEngine.EventSystems;

public class Movable : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    private bool selected;
    private Vector3 offset;

    void Update()
    {
        if (selected)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos + offset;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            DeleteGate();
        }
    }

    public void DeleteGate()
    {
        ConnectionPoint[] connectionPoints = GetComponentsInChildren<ConnectionPoint>();
        foreach (ConnectionPoint connection in connectionPoints)
        {
            if (connection.wire != null)
            {
                connection.wire.DeRegister(connection);
            }
        }
        Destroy(gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            selected = true;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = transform.position - mousePos;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        selected = false;
    }
}
