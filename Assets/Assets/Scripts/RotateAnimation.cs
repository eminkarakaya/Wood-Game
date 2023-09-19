using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RotateAnimation : MonoBehaviour
{
    Vector3 rot = new Vector3(0, 180, 0);
    Sequence seq;
    void Start()
    {
        seq = DOTween.Sequence();
        seq.Append (transform.DORotate(rot, 3f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            seq.Kill();
            Destroy(this);
        }
    }
}
