using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingIndicatorCollider : MonoBehaviour
{
    [SerializeField] private GameObject drawingIndicator;
    private Animator indicatorAnimator;

    public DrawManager drawManager;

    private void Awake()
    {
        indicatorAnimator = drawingIndicator.GetComponent<Animator>();
        indicatorAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                PauseMenu.canPauseMenu = false;
                drawManager._canDraw = true;
                drawingIndicator.SetActive(true);
                this.gameObject.SetActive(false);
                Time.timeScale = 0f;
            
        }
    }
}
