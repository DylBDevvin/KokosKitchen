using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flareRotatey : MonoBehaviour
{
    public float speed;
    public Transform target;
    public GameObject cardTarget;
    public bool card;
    public bool ball;
    public float s;
    public GameObject boom;
    private Vector3 zAxis = new Vector3(0, 0, 1);

    public float cd;
    public float cdm;
    // Start is called before the first frame update
    void Start()
    {
        if (card)
        {
            cardTarget = GameObject.FindGameObjectWithTag("CheriCardRotate");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (card)
        {
            cardTarget = GameObject.FindGameObjectWithTag("CheriCardRotate");
        }

        if (!card)
        {
            if (!ball)
            {
                transform.RotateAround(target.transform.position, zAxis, speed);
            }
        }

        if (card)
        {
            transform.RotateAround(cardTarget.transform.position, zAxis, speed);
        }

        if (ball)
        {
            cd += Time.deltaTime;
            Debug.Log("ballin");

            Vector3 direction = target.position - transform.position;
            direction = Quaternion.Euler(0, 0, s) * direction;
            float distanceThisFrame = speed * Time.deltaTime;
            transform.Translate(direction.normalized * distanceThisFrame, Space.World);

            if (transform.position == target.position || cdm <= cd)
            {
                Instantiate(boom, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
