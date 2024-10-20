using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScript : MonoBehaviour
{
    public static CoinScript instance;

    public static int coinAmount;
    [SerializeField] private TMP_Text coinText;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Update()
    {
        if (coinAmount > PlayerPrefs.GetInt("CoinAmount"))
        {
            PlayerPrefs.SetInt("CoinAmount", coinAmount);
            Debug.Log("Saved");
        }

        UpdateUi();
    }

    void UpdateUi()
    {

        // coinText.text = PlayerPrefs.GetInt("CoinAmount", 0).ToString();

        coinText.text = coinAmount.ToString();
        
    }
}
