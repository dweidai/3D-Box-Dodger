using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public GameObject completeUI;

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Restart();
            Invoke("Restart", restartDelay);
        }
       
    }

    public void Restart()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndComplete()
    {
        Debug.Log("Hooooray");
        completeUI.SetActive(true);
    }
}
