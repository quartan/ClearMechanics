using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleChooseObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float Coefficient = 1.08f;
    private Vector3 MaxScale;
    private Vector3 MinScale;
    private bool IncreaseScale = false;
    public bool On = true;
    private void Start()
    {
        MinScale = transform.localScale;
        MaxScale = new Vector3(MinScale.x * Coefficient, MinScale.y * Coefficient, MinScale.z * Coefficient);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        IncreaseScale = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IncreaseScale = false;
    }

    private void Update()
    {
        if (On && IncreaseScale && transform.localScale.x < MaxScale.x)
        {
            Vector3 scale = new Vector3(transform.localScale.x + Time.deltaTime * MinScale.x, transform.localScale.y + Time.deltaTime * MinScale.y, transform.localScale.z + Time.deltaTime * MinScale.z);
            if (scale.x > MaxScale.x)
            {
                scale = MaxScale;
            }
            transform.localScale = scale;
        }
        else if (transform.localScale.x > MinScale.x && (!On || !IncreaseScale))
        {
            Vector3 scale = new Vector3(transform.localScale.x - Time.deltaTime * MinScale.x, transform.localScale.y - Time.deltaTime * MinScale.y, transform.localScale.z - Time.deltaTime * MinScale.z);
            if (scale.x < MinScale.x)
            {
                scale = MinScale;
            }
            transform.localScale = scale;
        }
    }
}
