using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour {
    public GameObject confetti;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(confetti, transform.position, Quaternion.identity);
            Invoke("NextLevel", 3.0f);
        }
    }
    void NextLevel()
    {
        GameManager._instance.NextLevel();
    }
}
