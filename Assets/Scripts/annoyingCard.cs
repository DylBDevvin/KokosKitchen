using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class annoyingCard : MonoBehaviour
{
    public cheriBossScript cs;
    public GameObject cheri;
    public Animator cheriAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateWarp()
    {
        cs.Warp();
    }

    public void SetInactive()
    {
        cs.CardWarperSetInactive();
    }

    public void FireStuff()
    {
        cs.FireBulletWarp();
    }

    public void CheriSetInactive()
    {
        cheri.SetActive(false);
    }

    public void CheriSetActive()
    {
        cheri.SetActive(true);
    }

    public void CheriInvis()
    {
        cheriAnim.SetBool("invis", true);
        cheriAnim.SetBool("vis", false);
    }

    public void CheriVis()
    {
        cheriAnim.SetBool("invis", false);
        cheriAnim.SetBool("vis", true);
    }

    public void CheriIdle()
    {
        cheriAnim.SetBool("invis", false);
        cheriAnim.SetBool("vis", false);
    }
    
}
