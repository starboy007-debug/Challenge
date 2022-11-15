using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Deathmenu : MonoBehaviour
{
    public Text scoretext;
    public Image background;

    private bool isShowned = false;
    private float transition = 0.0f;

    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShowned)
            return;

        transition += Time.deltaTime;
        background.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black,transition);
    }

    public void Togglemenu(float score)
    {
        gameObject.SetActive(true);
        scoretext.text = ((int)score).ToString();
        isShowned = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Tomenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
