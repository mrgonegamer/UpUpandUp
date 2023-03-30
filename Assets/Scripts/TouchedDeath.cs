using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchedDeath : MonoBehaviour
{
    public GameObject gameOverMenu;

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
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
