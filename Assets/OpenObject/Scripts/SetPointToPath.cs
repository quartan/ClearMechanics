using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPointToPath : MonoBehaviour
{
    public Transform Target;
    public MakePathToObject MakePathToObject;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            MakePathToObject.SetTarget(Target);
        }
    }
}
