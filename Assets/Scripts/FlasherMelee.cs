using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlasherMelee : MonoBehaviour
{
    [SerializeField] private FlashScript flashEffect;

    private MeleeEnemy me;

    ///
    private void Start()
    {
        me = FindObjectOfType<MeleeEnemy>();


    }

    // Update is called once per frame
    void Update()
    {

        if (me.TakingDmg == true)
        {
            flashEffect.Flash();
        }

    }
}
