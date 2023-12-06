using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowLock : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite Key;
    public void Unlock()
    {
        ChangeSpriteToKey();
    }
    private void ChangeSpriteToKey()
    {
        if (_spriteRenderer != null && Key != null)
        {
            _spriteRenderer.sprite = Key;
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
