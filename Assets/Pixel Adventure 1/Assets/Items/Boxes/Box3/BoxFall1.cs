using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxFall1 : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Froggy>(out var froggy))
        {
            Debug.Log("asd");
            SceneManager.LoadScene("SampleScene");
        }
    }
}
