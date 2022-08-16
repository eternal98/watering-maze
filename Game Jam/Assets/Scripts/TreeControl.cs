using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeControl : MonoBehaviour
{
    public float maxHealth;
    private float health;
    public GameObject healthBar;

    public GameObject winPanel;
    public GameObject losePanel;

    public GameObject moneyText;

    private void Start()
    {
        
    }
    private void Update()
    {
        healthBar.transform.localScale = new Vector3( Mathf.Clamp01(health / maxHealth), healthBar.transform.localScale.y, healthBar.transform.localScale.z); 

        if(health >= maxHealth)
        {
            Invoke("Win", 2);
        }
    }
    void Win()
    {
        winPanel.SetActive(true);
        GameObject gameManager = GameObject.Find("Game Manager");
        if (gameManager.GetComponent<GameManager>().data.level < SceneManager.GetActiveScene().buildIndex)
        {
            moneyText.SetActive(true);
            gameManager.GetComponent<GameManager>().data.money += 50;
            gameManager.GetComponent<GameManager>().data.level++;
            PlayerPrefs.SetInt("level", gameManager.GetComponent<GameManager>().data.level);
            PlayerPrefs.SetInt("money", gameManager.GetComponent<GameManager>().data.money);
        }
    }
    void Lose()
    {
        losePanel.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(Grow());
            health++;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Polluted Water"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(Grow());
            health--;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Axit") || collision.gameObject.layer == LayerMask.NameToLayer("Lava"))
        {
            Lose();
        }
    }

    IEnumerator Grow()
    {
        gameObject.transform.localScale = new Vector3(1.1f, 1.1f, 1);
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.localScale = new Vector3(1f, 1f, 1);
    }
}
