using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0.0f;
    private int Difficultlevel = 1;
    private int maxDifficultlevel = 5;
    private int scoreTonextlevel = 10;
    private bool isdeath = false;
    private int coinscore;

    public Deathmenu deathmenu;
    public Text scoretext;
    public Text cointext;

    public GameObject level;
    void Update()
    {
        if (isdeath)
            return;
        if(coinscore > scoreTonextlevel)
        {
            LevelUp();
        }
        score += Time.deltaTime * Difficultlevel;
        scoretext.text = ((int)score).ToString();

        // coinscore = Coin.currentCoin;
        coinscore = Player.coins;
        cointext.text = ((int)coinscore).ToString();
    }

    private void LevelUp()
    {
        if (Difficultlevel == maxDifficultlevel)
            return;
       // level.SetActive(true);
       // level.GetComponent<Text>().text = "Level" + Difficultlevel;
        scoreTonextlevel += 100;
        Difficultlevel++;
        level.SetActive(true);
        level.GetComponent<Text>().text = "Level " + Difficultlevel;
        GetComponent<PlayerMotor>().setspeed(Difficultlevel);
        StartCoroutine(Hidelevel());
    }
   
    IEnumerator Hidelevel()
    {
        yield return new WaitForSeconds(1.5f);
        level.SetActive(false);
    }

    public void Ondeath()
    {
        isdeath = true;
        if(PlayerPrefs.GetFloat("HighScore") < coinscore)
            PlayerPrefs.SetFloat("HighScore", coinscore);

        deathmenu.Togglemenu(coinscore);
    }
}
