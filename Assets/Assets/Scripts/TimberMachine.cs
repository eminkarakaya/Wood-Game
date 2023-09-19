using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TimberMachine : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    bool isWork;
    Sequence seq;
    [SerializeField] private Transform vacuumPoint;
    [SerializeField] private DropMachine dropMachine;
    Vector3 rot = new Vector3(0, 180, 0);
        //private void OnEnable()
        //{
        //    dropMachine.onWork += SawAnim;
        //    dropMachine.onWork += VacuumAnim;
        //}
        //private void OnDisable()
        //{
        //    dropMachine.onWork -= SawAnim;
        //    dropMachine.onWork -= VacuumAnim;
        //}
    void Start()
    {

    }
    public void VacuumAnim()
    {
        if (isWork)
        {
            return;
        }
        var obj = dropMachine.GetLastCollectable();
        if (obj == null)
        {
            StopSawAnim();
            return;
        }
        Debug.Log(obj);
        obj.transform.DOMove(vacuumPoint.position, .2f);
    }
    public void SawAnim()
    {
        seq = DOTween.Sequence();
        seq.Append(transform.DORotate(rot, .3f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear));
    }
    public void StopSawAnim()
    {
        seq.Kill();
    }
    public void IsWorkFalse()
    {
        isWork = false;
        VacuumAnim();
    }

}
