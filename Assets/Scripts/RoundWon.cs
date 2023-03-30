using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundWon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject gameOverMenu;

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collidedWithThis)
    {
        if (collidedWithThis.transform.name == "Player")
        {
            Debug.Log("Game Won!");
            Time.timeScale = 0;
            EnableGameOverMenu();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
