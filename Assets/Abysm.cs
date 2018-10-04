using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abysm : MonoBehaviour {
    public Transform spawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            player.transform.position = spawnPoint.position;
            player.transform.rotation = Quaternion.identity;
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
