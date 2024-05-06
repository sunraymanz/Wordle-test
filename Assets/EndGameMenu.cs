using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public TextMeshProUGUI resultToken;
    public TextMeshProUGUI guessToken;
    private void Start()
    {
        if (FindObjectOfType<BoardManager>().correctness == 5)
        {
            resultToken.color = Color.green;
            resultToken.text = "!!! you rock !!!";
        }
        else
        {
            resultToken.color = Color.red;
            resultToken.text = "!!! try again !!!";
        }
        guessToken.text = "guess use : "+ FindObjectOfType<BoardManager>().rowIndex;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
