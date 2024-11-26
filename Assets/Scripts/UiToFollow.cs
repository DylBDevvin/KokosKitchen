using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiToFollow : MonoBehaviour
{

    public Transform objectToFollow;
    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(objectToFollow != null)
        {
            rectTransform.anchoredPosition = objectToFollow.localPosition;
        }

    }
}
