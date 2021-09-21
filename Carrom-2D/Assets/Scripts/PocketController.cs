using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketController : MonoBehaviour
{
    public  Transform strikerTransform;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Coin")// || collision.gameObject.tag == "Striker")
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Striker")
        {
            strikerTransform.position = new Vector3(0, -1.73f, 0);
        }
    }
}
