using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LeverActivate : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _repairedSprite;
    [SerializeField] private Sprite _activatedSprite;
    [SerializeField] private Animator Bridge;
    private Animator _animator;
    private bool inZone = false;
    private bool repaired = false;
    private bool activated = false;

    //Dispaly UI text for 5 seconds after hitting broken lever box
    [SerializeField] private TextMeshProUGUI LeverText;

    private void Awake()
    {
        LeverText.enabled = false;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Repair();    // Check for repair input
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inZone = true;
            LeverText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inZone = false;
            LeverText.enabled = false;
        }
    }

    // How to fix lever box
    private void Repair()
    {
        if (Input.GetKeyDown(KeyCode.E) && inZone == true)
        {
            if(!repaired)
            {
                LeverFix();
                Debug.Log("Fixed");
            }
            else if (!activated)
            {
                Activate();
            }
            
        }
    }

    private void LeverFix()
    {
        if (PlayerInventory.Instance.IsInInventory("BROKENHANDLE") == true)
        {
            PlayerInventory.Instance.RemoveItemFromInventory("BROKENHANDLE");
            repaired = true;

            if (repaired == true)
            {
                ChangeSpriteToRepairedSprite();
            }
        }
    }

    private void Activate()
    {
        if (inZone == true && repaired == true)
        {
            activated = true;
            if (activated == true)
            {
                ChangeSpriteToActivateSprite();
                PlayAnimation();
            }
            Debug.Log("Activated");
        }
    }

    private void ChangeSpriteToRepairedSprite()
    {
        if (_spriteRenderer != null && _repairedSprite != null)
        {
            _spriteRenderer.sprite = _repairedSprite;
        }
    }

    private void ChangeSpriteToActivateSprite()
    {
        if (_spriteRenderer != null && _activatedSprite != null)
        {
            _spriteRenderer.sprite = _activatedSprite;
        }

    }
    void PlayAnimation()
    {
        if (_animator == null && activated == true)
        {
            Bridge.GetComponent<Animator>().SetTrigger("Down");
            Debug.Log("BRIDGE GO DOWN");
        }
    }
}