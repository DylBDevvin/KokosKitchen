using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMenuScript : MonoBehaviour
{
    public MenuScript ms;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("TitleCardActivator"))
        {
            ms.canOpenMenu = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TitleCardActivator"))
        {
            ms.canOpenMenu = true;
        }
    }


}
