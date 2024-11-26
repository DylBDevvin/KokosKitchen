using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSliderThing : MonoBehaviour
{
    public Image hpImage;
    public Image hpEffectImage;

    public GameObject bg;
    public GameObject effect;
    public GameObject hpFill;

    

    public float hp;
    public bool dead;

    [SerializeField] public float maxHp;
    [SerializeField] private float hurtSpeed = 0.005f;

    

    private void Start()
    {
      
        hp = maxHp;   
    }

    private void Update()
    {
        if(hp <= 0)
        {
            dead = true;
            bg.SetActive(false);
            effect.SetActive(false);
            hpFill.SetActive(false);
        }

        if(hp > 0)
        {
            dead = false;
        }
       if(maxHp != hp && !dead)
        {
            bg.SetActive(true);
            effect.SetActive(true);
            hpFill.SetActive(true);
        }
        if(maxHp == hp)
        {
            bg.SetActive(false);
            effect.SetActive(false);
            hpFill.SetActive(false);
        }

        hpImage.fillAmount = hp / maxHp;

        if (hpEffectImage.fillAmount > hpImage.fillAmount)
        {
            hpEffectImage.fillAmount -= hurtSpeed;
        }
        else
        {
            hpEffectImage.fillAmount = hpImage.fillAmount;
        }
    }


}
