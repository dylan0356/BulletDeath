using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string sceneName;
    public GameObject EndScreenUI;

    public void StartGameButton()
    {
        SceneManager.LoadScene(sceneName);

    }

    public void EndGameButton()
    {
        SceneManager.LoadScene("Title");
    }

    public void EndGame() {
        EndScreenUI.SetActive(true);
    }

    public void RestartGameLevel() {
        //Load the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //set fire speed in UpgradeSystem to 1 to reset it for restart
            UpgradeSystem.fireSpeed = 1;
            
            //set the money to 0 in MoneyHandler to reset it for restart
            MoneyHandler.moneyVal = 0;

            //set the score to 0 in ScoreScript to reset it for restart
            ScoreScript.scoreVal = 0;
    }
}
