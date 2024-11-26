using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
    private Transform follow = null;

    private Vector3 originalLocalPosition;
    private Quaternion originalLocalRotation;

    public PlayerMovement pm;
    public SpriteRenderer sr;
    public BoxCollider2D boxCollider;
    public Animator anim;

    public void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponentInChildren<BoxCollider2D>();
    }
    private void Awake()
    {
        originalLocalPosition = follow.localPosition;
        originalLocalRotation = follow.localRotation;
    }

    private void Update()
    {
        if (pm.dead)
        {
           // gameObject.SetActive(true);
            sr.enabled = true;
            boxCollider.enabled = true;
            anim.enabled = true;
        }
    }
}
