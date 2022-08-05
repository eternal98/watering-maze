using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWater : MonoBehaviour
{
    public GameObject water;
    public int quantity;
    public float delayTime;
    public float speed;

    private void Start()
    {
        StartCoroutine(SpawnLiquid());
    }

    IEnumerator SpawnLiquid()
    {
        for(int i = 0; i<quantity; i++)
        {
            Instantiate(water, transform.position + new Vector3(Random.Range(-0.5f,0.5f),0,0), Quaternion.identity);
            yield return new WaitForSeconds(1/speed);
        }
        Destroy(this);
    }
}
