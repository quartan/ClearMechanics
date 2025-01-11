using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenObject : MonoBehaviour
{
    public float TimeOpen = 1f;
    public bool ObjectOpen = false;

    private Transform TheLastCameraTransform;
    private Vector3 TheLastPlayerPosition;

    private MoveCamera mCam;
    private Transform CameraTransform;
    private Transform PlayerTransform;

    private Transform Player;
    private PlayerInfo _playerInfo;
    private PlayerMove _playerMove;

    private ClassMoveTo classMoveTo = new();




    private void Start()
    {
        mCam = Camera.main.GetComponent<MoveCamera>();
        Player = GameObject.FindWithTag("Player").transform;
        _playerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
        _playerMove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        CameraTransform = transform.Find("CameraTransform");
        PlayerTransform = transform.Find("PlayerTransform");
        classMoveTo.transform = CameraTransform;
        classMoveTo.time = TimeOpen;
    }

    public void OnTrigStay()
    {
        if (_playerInfo.currentClickObject == gameObject && !ObjectOpen && !mCam.MoveOn)
        {
            classMoveTo.transform = CameraTransform;
            ObjectOpen = true;
            TheLastCameraTransform = mCam.currentTransform;
            TheLastPlayerPosition = Player.position;
            mCam.StartMoveTo(classMoveTo);
            _playerMove.StopPlayerMove();
            _playerMove.MovePlayer(PlayerTransform.position);
        }
    }

    private void Update()
    {
        if (ObjectOpen && Input.GetMouseButtonDown(1) && !mCam.MoveOn)
        {
            classMoveTo.transform = TheLastCameraTransform;
            mCam.StartMoveTo(classMoveTo);
            _playerMove.MovePlayer(TheLastPlayerPosition);
            _playerInfo.currentClickObject = null;
            ObjectOpen = false;
            _playerMove.ReturnPlayerMove();
        }
    }

}
public class ClassMoveTo
{
    public Transform transform;
    public float time;
}

