using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip coinGet;
    public static AudioClip itemGet;
    public static AudioClip speechNoise;
    public static AudioClip bubbleShoot;
    public static AudioClip bubblePop;
    public static AudioClip chargeShot;
    public static AudioClip chargedBubble;
    public static AudioClip charge;
    public static AudioClip death;
    public static AudioClip tutel;
    public static AudioClip kokoSpeak2;
    public static AudioClip kokoSpeak3;
    public static AudioClip levelUp;
    public static AudioClip chest;
    public static AudioClip kokodmg;
    public static AudioClip parry;
    public static AudioClip parryHit;
    public static AudioClip skellyDrop;
    public static AudioClip slimeAscend;
    public static AudioClip slimeLand;
    public static AudioClip rat;
    public static AudioClip boom;
    public static AudioClip revive;
    public static AudioClip pop;
    public static AudioClip buy;
    public static AudioClip nobuy;
    public static AudioClip spike;
    public static AudioClip thunder;
    public static AudioClip lightning;
    public static AudioClip charge1;
    public static AudioClip charge2;
    public static AudioClip laser;
    public static AudioClip upgrade;
    public static AudioClip heal;
    public static AudioClip detect1;
    public static AudioClip detect2;
    public static AudioClip press;
    public static AudioClip unpress;
    public static AudioClip iceRespawn;
    public static AudioClip vine;
    public static AudioClip snow;
    public static AudioClip splat;
    public static AudioClip spawn;
    public static AudioClip CLUBDESPAWN;
    public static AudioClip CLUBSPAWN;
    public static AudioClip CLUBGUN;
    public static AudioClip CLUBSHOOT;
    public static AudioClip SPADE;
    public static AudioClip warp;
    public static AudioClip DIAMOND;
    public static AudioClip HEARTSPAWN;
    public static AudioClip DESTROYCHERIITEM;
    public static AudioClip LASERSWITCH;
    public static AudioClip LASERFIRE;
    public static AudioClip CARD;
    public static AudioClip wave;
    public static AudioClip cheri;
    public static AudioClip bagel;
    public static AudioClip puzzClear;
    public static AudioClip freeze;
    static AudioSource audioSrc;

  

    // Start is called before the first frame update
    void Start()
    {
      
        coinGet = Resources.Load<AudioClip>("coinSE");
        itemGet = Resources.Load<AudioClip>("itemSE");
        speechNoise = Resources.Load<AudioClip>("tapSE");
        bubbleShoot = Resources.Load<AudioClip>("BubbleShoot");
        bubblePop = Resources.Load<AudioClip>("BubblePopSE");
        chargeShot = Resources.Load<AudioClip>("chargeShotSE");
        chargedBubble = Resources.Load<AudioClip>("chargeBubbleSE");
        charge = Resources.Load<AudioClip>("chargeFullSE");
        death = Resources.Load<AudioClip>("deathSE");
        tutel = Resources.Load<AudioClip>("tutelSE");
        kokoSpeak2 = Resources.Load<AudioClip>("kokoSpeak");
        kokoSpeak3 = Resources.Load<AudioClip>("gramsSpeak");
        levelUp = Resources.Load<AudioClip>("levelUpSE");
        chest = Resources.Load<AudioClip>("chestSE");
        kokodmg = Resources.Load<AudioClip>("kokodmgSE");
        parry = Resources.Load<AudioClip>("parry");
        parryHit = Resources.Load<AudioClip>("parryHit");
        skellyDrop = Resources.Load<AudioClip>("skellyHeadDrop");
        slimeAscend = Resources.Load<AudioClip>("slimeAscend");
        slimeLand = Resources.Load<AudioClip>("slimeLand");
        rat = Resources.Load<AudioClip>("rat");
        boom = Resources.Load<AudioClip>("boom");
        revive = Resources.Load<AudioClip>("revive");
        pop = Resources.Load<AudioClip>("pop");
        buy = Resources.Load<AudioClip>("buy");
        nobuy = Resources.Load<AudioClip>("nobuy");
        spike = Resources.Load<AudioClip>("spike");
        thunder = Resources.Load<AudioClip>("thunder");
        lightning = Resources.Load<AudioClip>("lightning");
        charge1 = Resources.Load<AudioClip>("charge1");
        charge2 = Resources.Load<AudioClip>("charge2");
        laser = Resources.Load<AudioClip>("laser");
        upgrade = Resources.Load<AudioClip>("upgrade");
        heal = Resources.Load<AudioClip>("heal");
        detect1 = Resources.Load<AudioClip>("detect1");
        detect2 = Resources.Load<AudioClip>("detect2");
        press = Resources.Load<AudioClip>("press");
        unpress = Resources.Load<AudioClip>("unpress");
        iceRespawn = Resources.Load<AudioClip>("iceRespawn");
        vine = Resources.Load<AudioClip>("vine");
        snow = Resources.Load<AudioClip>("snow");
        splat = Resources.Load<AudioClip>("splat");
        spawn = Resources.Load<AudioClip>("spawn");
        CLUBDESPAWN = Resources.Load<AudioClip>("CLUBDESPAWN");
        CLUBSPAWN = Resources.Load<AudioClip>("CLUBSPAWN");
        CLUBGUN = Resources.Load<AudioClip>("CLUBGUN");
        CLUBSHOOT = Resources.Load<AudioClip>("CLUBSHOOT");
        SPADE = Resources.Load<AudioClip>("SPADE");
        warp = Resources.Load<AudioClip>("warp");
        DIAMOND = Resources.Load<AudioClip>("DIAMOND");
        HEARTSPAWN = Resources.Load<AudioClip>("HEARTSPAWN");
        DESTROYCHERIITEM = Resources.Load<AudioClip>("DESTROYCHERIITEM");
        LASERFIRE = Resources.Load<AudioClip>("LASERFIRE");
        LASERSWITCH = Resources.Load<AudioClip>("LASERSWITCH");
        CARD = Resources.Load<AudioClip>("CARD");
        wave = Resources.Load<AudioClip>("wave");
        cheri = Resources.Load<AudioClip>("cheri");
        bagel = Resources.Load<AudioClip>("bagel");
        puzzClear = Resources.Load<AudioClip>("puzzClear");
        freeze = Resources.Load<AudioClip>("freeze");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "coinSE":
                audioSrc.PlayOneShot(coinGet);
                break;
            case "itemSE":
                audioSrc.PlayOneShot(itemGet);
                break;
            case "tapSE":
                audioSrc.PlayOneShot(speechNoise);
                break;
            case "BubbleShoot":
                audioSrc.PlayOneShot(bubbleShoot);
                break;
            case "BubblePopSE":
                audioSrc.PlayOneShot(bubblePop);
                break;
            case "chargeShotSE":
                audioSrc.PlayOneShot(chargeShot);
                break;
            case "chargeBubbleSE":
                audioSrc.PlayOneShot(chargedBubble);
                break;
            case "chargeFullSE":
                audioSrc.PlayOneShot(charge);
                break;
            case "deathSE":
                audioSrc.PlayOneShot(death);
                break;
            case "tutelSE":
                audioSrc.PlayOneShot(tutel);
                break;
            case "kokoSpeak":
                audioSrc.PlayOneShot(kokoSpeak2);
                break;
            case "gramsSpeak":
                audioSrc.PlayOneShot(kokoSpeak3);
                break;
            case "chestSE":
                audioSrc.PlayOneShot(chest);
                break;
            case "kokodmgSE":
                audioSrc.PlayOneShot(kokodmg);
                break;
            case "levelUpSE":
                audioSrc.PlayOneShot(levelUp);
                break;
            case "parry":
                audioSrc.PlayOneShot(parry);
                break;
            case "parryHit":
                audioSrc.PlayOneShot(parryHit);
                break;
            case "skellyHeadDrop":
                audioSrc.PlayOneShot(skellyDrop);
                break;
            case "slimeAscend":
                audioSrc.PlayOneShot(slimeAscend);
                break;
            case "slimeLand":
                audioSrc.PlayOneShot(slimeLand);
                break;
            case "rat":
                audioSrc.PlayOneShot(rat);
                break;
            case "boom":
                audioSrc.PlayOneShot(boom);
                break;
            case "revive":
                audioSrc.PlayOneShot(revive);
                break;
            case "pop":
                audioSrc.PlayOneShot(pop);
                break;
            case "buy":
                audioSrc.PlayOneShot(buy);
                break;
            case "nobuy":
                audioSrc.PlayOneShot(nobuy);
                break;
            case "spike":
                audioSrc.PlayOneShot(spike);
                break;
            case "thunder":
                audioSrc.PlayOneShot(thunder);
                break;
            case "lightning":
                audioSrc.PlayOneShot(lightning);
                break;
            case "charge1":
                audioSrc.PlayOneShot(charge1);
                break;
            case "charge2":
                audioSrc.PlayOneShot(charge2);
                break;
            case "laser":
                audioSrc.PlayOneShot(laser);
                break;
            case "upgrade":
                audioSrc.PlayOneShot(upgrade);
                break;
            case "heal":
                audioSrc.PlayOneShot(heal);
                break;
            case "detect1":
                audioSrc.PlayOneShot(detect1);
                break;
            case "detect2":
                audioSrc.PlayOneShot(detect2);
                break;
            case "press":
                audioSrc.PlayOneShot(press);
                break;
            case "unpress":
                audioSrc.PlayOneShot(unpress);
                break;
            case "iceRespawn":
                audioSrc.PlayOneShot(iceRespawn);
                break;
            case "vine":
                audioSrc.PlayOneShot(vine);
                break;
            case "snow":
                audioSrc.PlayOneShot(snow);
                break;
            case "splat":
                audioSrc.PlayOneShot(splat);
                break;
            case "spawn":
                audioSrc.PlayOneShot(spawn);
                break;
            case "CLUBDESPAWN":
                audioSrc.PlayOneShot(CLUBDESPAWN);
                break;
            case "CLUBSPAWN":
                audioSrc.PlayOneShot(CLUBSPAWN);
                break;
            case "CLUBGUN":
                audioSrc.PlayOneShot(CLUBGUN);
                break;
            case "CLUBSHOOT":
                audioSrc.PlayOneShot(CLUBSHOOT);
                break;
            case "SPADE":
                audioSrc.PlayOneShot(SPADE);
                break;
            case "WARP":
                audioSrc.PlayOneShot(warp);
                break;
            case "DIAMOND":
                audioSrc.PlayOneShot(DIAMOND);
                break;
            case "HEARTSPAWN":
                audioSrc.PlayOneShot(HEARTSPAWN);
                break;
            case "DESTROYCHERIITEM":
                audioSrc.PlayOneShot(DESTROYCHERIITEM);
                break;
            case "LASERFIRE":
                audioSrc.PlayOneShot(LASERFIRE);
                break;
            case "LASERSWITCH":
                audioSrc.PlayOneShot(LASERSWITCH);
                break;
            case "CARD":
                audioSrc.PlayOneShot(CARD);
                break;
            case "wave":
                audioSrc.PlayOneShot(wave);
                break;
            case "cheri":
                audioSrc.PlayOneShot(cheri);
                break;
            case "bagel":
                audioSrc.PlayOneShot(bagel);
                break;
            case "puzzClear":
                audioSrc.PlayOneShot(puzzClear);
                break;
            case "freeze":
                audioSrc.PlayOneShot(freeze);
                break;
        }
        
    }
}
