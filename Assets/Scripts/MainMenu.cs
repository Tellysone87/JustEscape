// Author: Shantel Williams
// Date: 12/5/2020
// File Name: MainMenu
// 
// Description: This code is to operate the title screen buttons 
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads next scene
    }

    public void quitGame()
    {
        EditorApplication.isPlaying = false;
        Application.Quit(); // quits editor application
    }

    public void Instructions()
    {
        SceneManager.LoadScene("instruction"); // Loads instruction Scene
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("TitleScreen"); // Loads instruction Scene
    }
}
