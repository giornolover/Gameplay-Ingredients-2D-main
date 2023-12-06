using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerInventory.Instance.IsInInventory("YELLOWGEM") == true)
        {
            PlayerInventory.Instance.RemoveItemFromInventory("YELLOWGEM");
            SceneManager.LoadScene("GameOver");
            Debug.Log("Crying");
        }
    }
}
