using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowButton : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite YellowButtonDown;
    public yellowLock Lock;
    private bool _pressed = false;
    static int _pressedCount = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ChangeSpriteToYellowButtonDown();
            _pressedCount++;
            if (_pressedCount == 3)
            {
                Lock.Unlock();
            }
            Destroy(this);
        }
    }

    private void ChangeSpriteToYellowButtonDown()
    {
        if (_spriteRenderer != null && YellowButtonDown != null)
        {
            _spriteRenderer.sprite = YellowButtonDown;
        }
    }
}
