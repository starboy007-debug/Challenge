using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0.0f;
    private int Difficultlevel = 1;
    private int maxDifficultlevel = 10;
    private int scoreTonextlevel = 10;
    private bool isdeath = false;
    private int coinscore;

    public Deathmenu deathmenu;
    public Text scoretext;
    public Text cointext;
    void Update()
    {

        if (isdeath)
            return;
        if(score > scoreTonextlevel)
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

        scoreTonextlevel *= 2;
        Difficultlevel++;
        GetComponent<PlayerMotor>().setspeed(Difficultlevel);
    }
   
    public void Ondeath()
    {
        isdeath = true;
        if(PlayerPrefs.GetFloat("HighScore") < score)
            PlayerPrefs.SetFloat("HighScore", score);

        deathmenu.Togglemenu(score);
    }
}
