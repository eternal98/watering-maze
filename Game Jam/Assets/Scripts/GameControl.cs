using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private float currentZ;
    private float clickZ;
    private float newZ;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnMouseDown()
    {
        currentZ = rb.rotation;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        clickZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    }
    private void OnMouseDrag()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        newZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rb.MoveRotation((newZ - clickZ) + currentZ);
    }
}
