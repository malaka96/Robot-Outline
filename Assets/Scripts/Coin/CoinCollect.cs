using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public enum CoinValue
    {
        coinV5,
        coinV10,
        coinV25,
        coinV50
    }

    [SerializeField] private CoinValue coinValue;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (coinValue == CoinValue.coinV5)
            {
                CoinScript.coinAmount += 5;

            }
            else if (coinValue == CoinValue.coinV10)
            {
                CoinScript.coinAmount += 10;
            }
            else if (coinValue == CoinValue.coinV25)
            {
                CoinScript.coinAmount += 20;
            }
            else if (coinValue == CoinValue.coinV50)
            {
                CoinScript.coinAmount += 50;
            }
            Destroy(this.gameObject);
        }
    }
}
