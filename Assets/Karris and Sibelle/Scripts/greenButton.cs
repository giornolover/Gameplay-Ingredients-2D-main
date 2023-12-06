using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class greenButton : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite GreenButtonDown;
    [SerializeField] private Animator Floater;

    private Animator _animator;

    private bool _pressedGreen = false;
    static int _downCount = 0;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ChangeSpriteToGreenButtonDown();
        }
    }

    private void ChangeSpriteToGreenButtonDown()
    {
        if (_spriteRenderer != null && GreenButtonDown != null)
        {
            _spriteRenderer.sprite = GreenButtonDown;
            _pressedGreen = true;
            _downCount++;

            if (_downCount == 3 && _animator == null)
            {
                    Floater.GetComponent<Animator>().SetTrigger("Up");
                    Debug.Log("Animating");
            }
            Destroy(this);
        }
    }
}
