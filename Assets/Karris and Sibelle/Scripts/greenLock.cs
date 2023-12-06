using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GreenLock : MonoBehaviour
{

    private Animator _animator;

    [SerializeField] private TextMeshProUGUI LockText;
    bool inZone = false;

    //Generate interaction text
    private void Start()
    {
        LockText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inZone = true;
            LockText.enabled = true;
     
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inZone = false;
            LockText.enabled = false;
        }
    }

    //Unlock box and generate button
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerInventory.Instance.IsInInventory("KEY"))
        {
            TryUnlock();
        }
    }
    private void TryUnlock()
    {
        PlayerInventory.Instance.RemoveItemFromInventory("KEY");
        Destroy(gameObject);
        
    }
}