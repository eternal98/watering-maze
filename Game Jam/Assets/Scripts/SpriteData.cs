using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpriteData : ScriptableObject
{
    public int money;

    public int level;

    public BackgroundData[] backgrounds;
    public int noBG;

    public TreeData[] tree;
    public int noTree;
}

[System.Serializable]
public struct BackgroundData
{
    public Sprite background;
    public bool isOpen;
}

[System.Serializable]
public struct TreeData
{
    public Sprite[] tree;
    public int noUp;
    public bool isOpen;
}
