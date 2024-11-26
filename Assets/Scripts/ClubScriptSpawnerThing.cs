using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubScriptSpawnerThing : MonoBehaviour
{

    public GameObject ClubSpawnLocation;
    public GameObject club;
    public int xSpawnRange;
    public int ySpawnRange;
    public bool canSpawnClub;
    public int clubCount;
    public int maxClubCount;
    public MeleeEnemy1 me1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (me1.dead)
        {
            gameObject.SetActive(false);
        }
        if (canSpawnClub)
        {
            SpawnClubGuy();
        }
       
    }

    public void SpawnClubGuy()
    {
        if (canSpawnClub)
        {
            // SoundManagerScript.PlaySound("CLUBSPAWN");
            if (!me1.dead)
            {


                xSpawnRange = Random.Range(937, 959);
                ySpawnRange = Random.Range(559, 547);
                ClubSpawnLocation.transform.position = new Vector3(xSpawnRange, ySpawnRange, 0);
                Instantiate(club, ClubSpawnLocation.transform.position, ClubSpawnLocation.transform.rotation);
                clubCount += 1;
            }
        }

        if(clubCount >= maxClubCount)
        {
            canSpawnClub = false;
            clubCount = 0;
        }
    }

    public void ClubFire()
    {
        canSpawnClub = true;
    }
}
