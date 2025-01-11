using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCamera : MonoBehaviour
{
    public bool MoveOn = false;
    public Transform currentTransform;


    private void Start()
    {
        currentTransform = GameObject.Find("CameraTransform").transform;
    }

    public bool StartMoveTo(ClassMoveTo classMoveTo)
    {
        if (!MoveOn)
        {
            MoveOn = true;
            transform.DOMove(classMoveTo.transform.position, classMoveTo.time).SetEase(Ease.Linear);
            transform.DORotate(classMoveTo.transform.eulerAngles, classMoveTo.time).SetEase(Ease.Linear);
            StartCoroutine(WaitMoveCamera(classMoveTo.time));
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator WaitMoveCamera(float time)
    {
        yield return new WaitForSeconds(time);
        MoveOn = false;
    }

}
