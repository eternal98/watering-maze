using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SpriteData data;

    private void Awake()
    {
        GameObject background = GameObject.Find("Background");
        background.GetComponent<SpriteRenderer>().sprite = data.backgrounds[data.noBG].background;
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            GameObject tree = GameObject.Find("Tree");
            tree.GetComponent<SpriteRenderer>().sprite = data.tree[data.noTree].tree[data.tree[data.noTree].noUp];
        }
    }


    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void ChangeScene(int sc)
    {
        SceneManager.LoadScene(sc);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
