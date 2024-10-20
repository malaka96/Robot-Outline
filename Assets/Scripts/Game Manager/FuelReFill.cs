using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelReFill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            FuelScript.instance.ReFillFuel();
        }

    }
}
