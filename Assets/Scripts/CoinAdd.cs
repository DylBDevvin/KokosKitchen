using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAdd : MonoBehaviour
{
    public int moneytoadd;
    // int to add to the MONEY
    private MoneyBank mbank;

    void Start()
    {
        mbank = FindObjectOfType<MoneyBank>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mbank.GetMoney(moneytoadd); // adds the int and turns it into MONEY
            Destroy(gameObject);
            SoundManagerScript.PlaySound("coinSE");
        }
    }
}
