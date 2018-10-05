using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float zOffset;
    public float yOffset;
	public float speed;
	void Start () {
		if (target == null) {
			target = GameObject.FindGameObjectWithTag ("Player").transform;
		}
		transform.position = new Vector3 (target.position.x, target.position.y+yOffset, zOffset);
	}

	void Update () {
		transform.position = Vector3.Lerp (transform.position, new Vector3(target.position.x,target.position.y + yOffset,zOffset), speed * Time.deltaTime);
	}
}
