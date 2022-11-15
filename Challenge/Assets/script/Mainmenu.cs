using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Mainmenu : MonoBehaviour
{
    public Text Highscoretext;
    void Start()
    {
        Highscoretext.text = "HighScore:" + ((int)PlayerPrefs.GetFloat("HighScore")).ToString();
    }


    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void quit()
    {
        Application.Quit();
    }
}
