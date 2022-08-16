using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField]public int scene;
    private Vector3 currentPos;
    public GameObject chaneScenePanel;

    private void OnMouseDown()
    {
        currentPos = transform.position;
    }
    private void OnMouseUp()
    {
        if (transform.position == currentPos)
        {
            StartCoroutine(ChangeScene());
        }
    }

    public IEnumerator ChangeScene()
    {
        chaneScenePanel.GetComponent<Animator>().SetTrigger("Close");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
