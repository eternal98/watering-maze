using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private Vector3 _dragOffset;
    public float maxY;

    private void Update()
    {
        if(transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0);
        }
        if (transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _dragOffset = transform.position - GetMousePos();
        }
        if (Input.GetMouseButton(0))
        {
            transform.position = GetMousePos() + _dragOffset;
        }
    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos.x = 0;
        return mousePos;
    }
}
