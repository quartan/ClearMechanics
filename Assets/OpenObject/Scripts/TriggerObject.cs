using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    private OpenObject OpenObject;

    private void Start()
    {
        OpenObject = transform.parent.GetComponent<OpenObject>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            OpenObject.OnTrigStay();
        }
    }
}
