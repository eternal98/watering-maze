using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    //Shop
    public SpriteData data;

    public GameObject[] backgroundShop;
    public GameObject[] treeShop;

    public TextMeshProUGUI goldText;

    private void Awake()
    {
        data.level = PlayerPrefs.GetInt("level");
        if (PlayerPrefs.HasKey("money"))
        {
            data.money = PlayerPrefs.GetInt("money");
        }
        data.noBG = PlayerPrefs.GetInt("noBg");
        data.noTree = PlayerPrefs.GetInt("noTree");
        for (int i = 1; i < data.tree.Length; i++) 
        {
            if (PlayerPrefs.GetInt("tree" + i.ToString()) == 1)
            {
                data.tree[i].isOpen = true;
            } 
        }
        for (int i = 1; i < data.tree.Length; i++)
        {
            if (PlayerPrefs.GetInt("bg" + i.ToString()) == 1)
            {
                data.backgrounds[i].isOpen = true;
            }
        }
    }
    private void Start()
    {
        //Level
        for(int n = data.level + 1; n < transform.childCount; n++)
        {
            transform.GetChild(n).GetComponent<SpriteRenderer>().color = Color.gray;
            transform.GetChild(n).GetComponent<PolygonCollider2D>().enabled = false;
        }

        //Background
        for(int i = 1; i<data.backgrounds.Length; i++)
        {
            if(data.backgrounds[i].isOpen == true)
            {
                backgroundShop[i].GetComponent<Image>().color = Color.white;
                backgroundShop[i].transform.GetChild(0).gameObject.SetActive(false);
                backgroundShop[i].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        if(data.noBG == 0)
        {
            backgroundShop[0].transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            backgroundShop[data.noBG].transform.GetChild(2).gameObject.SetActive(true);
        }

        //Tree
        treeShop[0].transform.GetChild(0).GetComponent<Image>().sprite = data.tree[0].tree[data.tree[0].noUp];
        for (int i = 1; i < data.tree.Length; i++)
        {
            if (data.tree[i].isOpen == true)
            {
                treeShop[i].GetComponent<Image>().color = Color.white;
                treeShop[i].transform.GetChild(1).gameObject.SetActive(false);
                treeShop[i].transform.GetChild(2).gameObject.SetActive(false);
            }
            treeShop[i].transform.GetChild(0).GetComponent<Image>().sprite = data.tree[i].tree[data.tree[i].noUp];
        }
        if (data.noTree == 0)
        {
            treeShop[0].transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            treeShop[data.noTree].transform.GetChild(3).gameObject.SetActive(true);
        }
    }

    public void ChoiceBackground(int noBG)
    {
        if(data.backgrounds[noBG].isOpen == true)
        {
            data.noBG = noBG;
            if(noBG == 0)
            {
                backgroundShop[0].transform.GetChild(0).gameObject.SetActive(true);
                for (int i = 1; i < data.backgrounds.Length; i++)
                {
                    backgroundShop[i].transform.GetChild(2).gameObject.SetActive(false);
                }
            }
            else
            {
                backgroundShop[noBG].transform.GetChild(2).gameObject.SetActive(true);
                backgroundShop[0].transform.GetChild(0).gameObject.SetActive(false);
                for (int i = 1; i < data.backgrounds.Length; i++)
                {
                    if (i != noBG)
                    {
                        backgroundShop[i].transform.GetChild(2).gameObject.SetActive(false);
                    }
                }
            }
            GameObject background = GameObject.Find("Background");
            background.GetComponent<SpriteRenderer>().sprite = data.backgrounds[data.noBG].background;
        }
        else
        {
            
            if(int.Parse(backgroundShop[noBG].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text) <= data.money)
            {
                data.money -= int.Parse(backgroundShop[noBG].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
                PlayerPrefs.SetInt("money", data.money);
                data.backgrounds[noBG].isOpen = true;
                PlayerPrefs.SetInt("bg" + noBG.ToString(), 1);
                backgroundShop[noBG].GetComponent<Image>().color = Color.white;
                backgroundShop[noBG].transform.GetChild(0).gameObject.SetActive(false);
                backgroundShop[noBG].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    public void ChoiceTree(int noTree)
    {
        if (data.tree[noTree].isOpen == true)
        {
            data.noTree = noTree;
            if (noTree == 0)
            {
                treeShop[0].transform.GetChild(1).gameObject.SetActive(true);
                for (int i = 1; i < data.tree.Length; i++)
                {
                    treeShop[i].transform.GetChild(3).gameObject.SetActive(false);
                }
            }
            else
            {
                treeShop[noTree].transform.GetChild(3).gameObject.SetActive(true);
                treeShop[0].transform.GetChild(1).gameObject.SetActive(false);
                for (int i = 1; i < data.tree.Length; i++)
                {
                    if (i != noTree)
                    {
                        treeShop[i].transform.GetChild(3).gameObject.SetActive(false);
                    }
                }
            }
        }
        else
        {

            if (int.Parse(treeShop[noTree].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text) <= data.money)
            {
                data.money -= int.Parse(treeShop[noTree].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text);
                PlayerPrefs.SetInt("money", data.money);
                data.tree[noTree].isOpen = true;
                PlayerPrefs.SetInt("tree" + noTree.ToString(), 1);
                treeShop[noTree].GetComponent<Image>().color = Color.white;
                treeShop[noTree].transform.GetChild(1).gameObject.SetActive(false);
                treeShop[noTree].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    // Level
    private Vector3 _dragOffset;
    public float maxX;
    public float maxY;

    private void Update()
    {
        Drag();
        goldText.text = data.money.ToString();
    }

    void Drag()
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
    Vector3 GetMousePosY()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos.x = 0;
        return mousePos;
    }
}
