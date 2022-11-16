using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int currentCoin;
    float speed;

    private void Start()
    {
        speed = Random.Range(35f, 45f);
    }
    private void Update()
    {
        //   currentCoin = coins;
        currentCoin = PlayerMotor.coins;
        transform.Rotate(0, speed * Time.deltaTime, 0, Space.World);

    }
    private void OnTriggerEnter(Collider other)
    {
      //  Debug.Log("It Work!");
     //   currentCoin++;
        currentCoin = PlayerMotor.coins;
        Destroy(this.gameObject);
      //  coins += 1;
        
    }
}
