using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class moveConstantly : MonoBehaviour {
    public float endX, duration;

    private void Start()
    {
        transform.DOLocalMoveX(endX, duration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

}
