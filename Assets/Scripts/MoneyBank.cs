using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBank : MonoBehaviour
{
    public Text moneyText;
    public int Money;
    public float moneytoadd;
    public float moneyMult = 1;
    public int result;

    private void Start()
    {
        SetMoneyText();
    }

    public void SetMoneyText()
    {
        moneyText.text = "$" + Money;
    }

    public void GetMoney(int m)
    {
        moneytoadd = m * moneyMult;
        result = Mathf.RoundToInt(moneytoadd);
        Money += result;
        SetMoneyText();
    }

    public void SubMoney(int m)
    {
        if (Money >= m)
        {
            Money -= m;
        }
        else
        {
            Money = 0;
        }
        //Just a bit more code to make sure that the Money won't go below 0
        SetMoneyText();
    }
}
