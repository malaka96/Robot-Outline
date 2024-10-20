using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frontWheel;
    [SerializeField] private Rigidbody2D _backWheel;
    [SerializeField] private Rigidbody2D _carRb;
    [SerializeField] private float _carMoveSpeed = 5f;
    

    AudioSource _carAudioSource;
    private float _horzontalInput = 1.5f;

    void Start()
    {
        _carAudioSource = GetComponent<AudioSource>();
        
    }


    void Update()
    {
        // _horzontalInput = Input.GetAxis("Horizontal");
        // Debug.Log(_horzontalInput);

        if (Time.timeScale == 0)
        {
            _carAudioSource.Pause();
        }
        else
        {
            if(Time.timeScale == 1)
            {
                if (!_carAudioSource.isPlaying)
                {
                    _carAudioSource.UnPause();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        _frontWheel.AddTorque(_horzontalInput * _carMoveSpeed * Time.fixedDeltaTime);
        _backWheel.AddTorque(_horzontalInput * _carMoveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Speed Increaser"))
        {
            _horzontalInput *= 1.2f;
        }
    }


}
