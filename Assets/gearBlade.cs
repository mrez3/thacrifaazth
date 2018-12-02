using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class gearBlade : gear {

    Animator animator;
    AudioSource audioSource;

    public float stopIn = 1;
    public Sprite bloodyGear;
    public AudioClip wooshSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public override void stop(Color c)
    {

        DOTween.To(x => animator.speed = x, animator.speed, 0, stopIn);

    }

    public void woosh()
    {
        audioSource.PlayOneShot(wooshSound);
    }

}
