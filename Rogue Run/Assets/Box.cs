using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box : MonoBehaviour
{
    private GameObject gameOverText;

    private void Awake() 
    {
        gameOverText = GameObject.Find("gameOver");
          
    }

    private void Start() 
    {
        if(gameOverText.activeSelf == true)
            gameOverText.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collider) 
    {
        Time.timeScale = 0;
        GetComponent<AudioSource>().Play();
        gameOverText.SetActive(true);
    }
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneRestart();
        }    
    }
    public void SceneRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}