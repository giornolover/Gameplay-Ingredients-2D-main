using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagEnd : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerInventory.Instance.IsInInventory("REDGEM") == true)
        {
            PlayerInventory.Instance.RemoveItemFromInventory("REDGEM");
            SceneManager.LoadScene("Level2");
        }
    }
}
