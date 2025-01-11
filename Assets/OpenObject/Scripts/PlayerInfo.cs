using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public GameObject currentClickObject;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var infoHit, Mathf.Infinity, LayerMask.GetMask("Floor", "ClickedObject")))
            {
                currentClickObject = infoHit.collider.gameObject;
            }
        }
    }
}
