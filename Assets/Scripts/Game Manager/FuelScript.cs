using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelScript : MonoBehaviour
{
    public static FuelScript instance;

    [SerializeField] private Image _fuelImage;
    [SerializeField, Range(1f, 10f)] private float _fuelDrainSpeed = 1f;
    [SerializeField] private Gradient _gradient;
    private float _maxFuelAmount = 100f;

    private float _currentFuelAmount;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        _currentFuelAmount = _maxFuelAmount;
        UpdateUI();
    }


    void Update()
    {
        _currentFuelAmount -= Time.deltaTime * _fuelDrainSpeed;
        UpdateUI();

        if(_currentFuelAmount <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    void UpdateUI()
    {
        _fuelImage.fillAmount = (_currentFuelAmount / _maxFuelAmount);
        _fuelImage.color = _gradient.Evaluate(_fuelImage.fillAmount);
    }

    public void ReFillFuel()
    {
        _currentFuelAmount = _maxFuelAmount;
        UpdateUI();
    }
}
