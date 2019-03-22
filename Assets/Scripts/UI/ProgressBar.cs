using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public Transform Bar;

    public void SetValue(float percent)
    {
        Bar.localScale = new Vector2(percent, Bar.localScale.y);        
    }

    public void SetVisible(bool v)
    {
        gameObject.SetActive(v);
    }

}
