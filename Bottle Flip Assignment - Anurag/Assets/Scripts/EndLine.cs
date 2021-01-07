using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLine : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            canvas.SetActive(true);
        }
    }
}
