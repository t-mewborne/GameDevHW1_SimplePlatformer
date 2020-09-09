using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collected a Coin!");
        //if ("Player".Equals(collision.gameObject.tag))
        //{
            Destroy(this.gameObject);
        //}
    }
}