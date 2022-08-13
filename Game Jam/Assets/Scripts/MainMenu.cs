using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //Shop
    public SpriteData data;

    public GameObject[] backgroundShop;
    public GameObject[] treeShop;

    private void Start()
    {
        for(int i = 1; i<data.backgrounds.Length; i++)
        {
            if(data.backgrounds[i].isOpen == true)
            {
                backgroundShop[i].GetComponent<Button>().enabled = true;
                backgroundShop[i].GetComponent<Image>().color = Color.white;
                backgroundShop[i].transform.GetChild(0).gameObject.SetActive(false);
                backgroundShop[i].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    // Level
    public enum Direction { X, Y}

    public Direction direction;

    private Vector3 _dragOffset;
    public float maxX;
    public float maxY;

    private void Update()
    {
        if (direction == Direction.Y)
        {
            if (transform.position.y < 0)
            {
                transform.position = new Vector3(transform.position.x, 0);
            }
            if (transform.position.y > maxY)
            {
                transform.position = new Vector3(transform.position.x, maxY);
            }

            if (Input.GetMouseButtonDown(0))
            {
                _dragOffset = transform.position - GetMousePosY();
            }
            if (Input.GetMouseButton(0))
            {
                transform.position = GetMousePosY() + _dragOffset;
            }
        }
        if(direction == Direction.X)
        {
            if (transform.position.x < 0)
            {
                transform.position = new Vector3(0, transform.position.y);
            }
            if (transform.position.x > maxX)
            {
                transform.position = new Vector3(maxX, transform.position.y);
            }

            if (Input.GetMouseButtonDown(0))
            {
                _dragOffset = transform.position - GetMousePosX();
            }
            if (Input.GetMouseButton(0))
            {
                transform.position = GetMousePosX() + _dragOffset;
            }
        }
    }

    Vector3 GetMousePosY()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos.x = 0;
        return mousePos;
    }
    Vector3 GetMousePosX()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos.y = 0;
        return mousePos;
    }
}
