using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScreenFaderScript : MonoBehaviour
{
    public PlayerMovement pm;

    public void L()
    {
        pm.LoadFromJson();
    }

    public void N()
    {
        pm.StartItUp();
    }
}
