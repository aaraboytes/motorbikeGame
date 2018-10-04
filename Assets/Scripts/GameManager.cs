using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager _instance = null;
	public GameObject gameOverScreen;
	public BikeController playerController;
	public GameObject player;
	public Transform respawnPosition;
	Transform backWheelPos,frontWheelPos;
	public GameObject explossionEffect;
	bool alive = true;
	void Awake(){
		if(_instance == null){
			_instance = this;
		}
	}
	void Start(){
		gameOverScreen.SetActive(false);
		backWheelPos = player.transform.GetChild(0).transform;
		frontWheelPos = player.transform.GetChild(1).transform;
	}
	public void GameOver(){
		gameOverScreen.SetActive(true);
		playerController.enabled = false;
		if(alive){
			GameObject currentExp = (GameObject)Instantiate(explossionEffect,player.transform.position - Vector3.forward,Quaternion.identity);
			Destroy(currentExp,1.0f);
		}
		alive = false;
	}
	public void NewGame(){
		player.transform.position = respawnPosition.position;
		player.transform.rotation = Quaternion.identity;
		player.transform.GetChild(0).transform.position = backWheelPos.position;
		player.transform.GetChild(0).transform.rotation = Quaternion.identity;
		player.transform.GetChild(0).GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		player.transform.GetChild(1).transform.position = frontWheelPos.position;
		player.transform.GetChild(1).transform.rotation = Quaternion.identity;
		player.transform.GetChild(1).GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		gameOverScreen.SetActive(false);
		playerController.enabled = true;
		alive = true;
	}
}
