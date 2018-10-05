using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAbysm : MonoBehaviour {
    public Transform spawnPoint;
    GameObject player = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject;
            Invoke("Respawn", 1.5f);
        }
    }
    void Respawn()
    {
        player.transform.position = spawnPoint.position;
        player.transform.rotation = Quaternion.identity;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
