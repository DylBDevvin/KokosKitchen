using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float health;
    public float maxHP;
    public int level;
    public float[] position;

    public bool csUnlocked;
    public bool tripleShotUnlocked;
    public bool pUnlocked1;
    public bool pUnlocked2;
    public bool pUnlocked3;
    public bool gen1;
    public bool gen2;
    public bool gen3;

    public bool cityTPU;
    public bool beachTPPU;
    public bool royalTPU;
    public bool caveTPU;
    public bool wrongNTPU;
    public bool fFluTPU;
    public bool cEXTTPU;
    public bool cINTTPU;

    public bool shop1Unlocked;
    public bool shop2Unlocked;
    public bool shop3Unlocked;
    public bool shop4Unlocked;
    public bool shop5Unlocked;

    public bool laserUnlocked;
    public bool bouncyUnlocked;
    public bool healUnlocked;
    public bool doubleParryUnlocked;
    public bool healAndSpeedUnlocked;
    public bool tripleParryUnlocked;
    public bool healAndSpeedAndAttackUnlocked;
    public bool potatoUnlocked;
    public bool vineBoomUnlocked;
    public bool glubglubUnlocked;


    public int strength;
    public float cd;
    public float speed;
    public float moneyMult = 1f;
    public float xpMult = 1f;
    public int maxPcount = 5;
    public float dMult = 1;
    public int slimeAttack = 3;
    public float slimeCooldown = 5;

    public int rats;
    public int money;

    public int ssPrice1;
    public int ssPrice2;
    public int ss2Price1;
    public int ss2Price2;
    public int ss3Price1;
    public int ss3Price2;
    public int ss4Price1;
    public int ss4Price2;
    public int ss5Price1;
    public int ss5Price2;

    public bool glubbed;

    public bool genTut1;
    public bool genTut2;
    public bool genTut3;

    public bool genTutUnlocked1;
    public bool genTutUnlocked2;
    public bool genTutUnlocked3;

    //maybe instead of float array do it one at a time? float positiion x, float position y, etc.
}
