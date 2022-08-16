using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SpriteData data;
    public GameObject chaneScenePanel;

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

    private void Start()
    {
        chaneScenePanel.GetComponent<Animator>().SetTrigger("Open");
        Invoke("CloseChangePanel", 1);
    }
    void CloseChangePanel()
    {
        chaneScenePanel.SetActive(false);
    }


    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public IEnumerator ChangeScene(int sc)
    {
        chaneScenePanel.SetActive(true);
        chaneScenePanel.GetComponent<Animator>().SetTrigger("Close");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sc);
    }
    public void RestartLevel()
    {
        StartCoroutine(ChangeScene(SceneManager.GetActiveScene().buildIndex));
    }
    public void NextLevel()
    {
        StartCoroutine(ChangeScene(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void GoHome()
    {
        StartCoroutine(ChangeScene(0));
    }
}
