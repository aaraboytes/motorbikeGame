using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager _instance = null;
	
	public GameObject explossionEffect;
    public string[] sceneNames;

    BikeController playerController;
    GameObject gameOverScreen;

    bool alive = true;
	void Awake(){
		if(_instance == null){
			_instance = this;
		}else if (_instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
	}
	void Start(){
        gameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen");
		gameOverScreen.SetActive(false);
        playerController = Transform.FindObjectOfType<BikeController>();
	}
    private void Update()
    {
        if (gameOverScreen == null)
        {
            gameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen");
            gameOverScreen.SetActive(false);
        }
        if(playerController == null) playerController = Transform.FindObjectOfType<BikeController>();
    }
    public void GameOver(){
		gameOverScreen.SetActive(true);
		playerController.enabled = false;
	}
    public void NextLevel()
    {
        int actualScene = 0;
        for(int i = 0;i<sceneNames.Length;i++)
        if(SceneManager.GetActiveScene().name == sceneNames[i])
            actualScene = i;
        SceneManager.LoadScene(sceneNames[actualScene+1]);
    }
}
