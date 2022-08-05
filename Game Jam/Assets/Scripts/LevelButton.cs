using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField]public int scene;
    private Vector3 currentPos;

    private void OnMouseDown()
    {
        currentPos = transform.position;
    }
    private void OnMouseUp()
    {
        if (transform.position == currentPos)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
