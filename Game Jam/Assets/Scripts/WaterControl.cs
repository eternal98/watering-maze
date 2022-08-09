using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterControl : MonoBehaviour
{
    public Sprite rock;

    public Color[] colors;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (gameObject.layer == LayerMask.NameToLayer("Water")) 
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Lava"))
            {
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = rock;
                collision.gameObject.layer = LayerMask.NameToLayer("Default");
                Destroy(gameObject);
            }
            if (collision.gameObject.layer == LayerMask.NameToLayer("Axit"))
            {
                gameObject.layer = LayerMask.NameToLayer("Axit");
                gameObject.GetComponent<SpriteRenderer>().color = colors[0];
            }
            if (collision.gameObject.layer == LayerMask.NameToLayer("Sponge"))
            {
                Destroy(gameObject);
            }
            if (collision.gameObject.layer == LayerMask.NameToLayer("Polluted"))
            {
                gameObject.layer = LayerMask.NameToLayer("Polluted Water");
                gameObject.GetComponent<SpriteRenderer>().color = colors[1];
            }
        }
        if (gameObject.layer == LayerMask.NameToLayer("Axit"))
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Lava"))
            {
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = rock;
                collision.gameObject.layer = LayerMask.NameToLayer("Default");
                Destroy(gameObject);
            }
            if (collision.gameObject.layer == LayerMask.NameToLayer("Sponge"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
        if (gameObject.layer == LayerMask.NameToLayer("Polluted Water"))
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Lava"))
            {
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = rock;
                collision.gameObject.layer = LayerMask.NameToLayer("Default");
                Destroy(gameObject);
            }
            if (collision.gameObject.layer == LayerMask.NameToLayer("Sponge"))
            {
                Destroy(gameObject);
            }
        }
    }
}
