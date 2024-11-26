using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextHandler : MonoBehaviour
{
    public GameObject floatingPoints;
    public MeleeEnemy1 me1;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition += new Vector3(0, 4, 0);
    }



    private void SetBoolBack()
    {
        gameObject.SetActive(false);

    }
}
