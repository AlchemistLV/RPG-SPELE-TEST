using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour {
    public void NewGameBtn(string newGame)
    {
        SceneManager.LoadScene(newGame);
    }
    public void ExitGameBtn()
    {
        Application.Quit();
    }
}
