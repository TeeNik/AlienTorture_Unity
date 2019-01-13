using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    private Rigidbody2D _rb;

    public void Init()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

}
