using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 2f;
    public GameObject completeUI;   
    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Restart();
          
        }
       
    }

    public void Restart()
    {
        StartCoroutine("Restart2");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator Restart2()
    {
        yield return new WaitForSeconds(restartDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void EndComplete()
    {
        Debug.Log("Hooooray");
        completeUI.SetActive(true);
    }
}
