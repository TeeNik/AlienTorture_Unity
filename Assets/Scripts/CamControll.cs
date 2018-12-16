using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControll : MonoBehaviour
{
    private Vector3 _target;
    private Rigidbody2D _rb;
    private GameObject _player;
    // Start is called before the first frame update
    //void Start()
    //{
    //    _rb = GetComponent<Rigidbody2D>();
    //    _player = GameObject.Find("Player(Clone)");
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    _target = _player.transform.position;
    //    if ((transform.position - _target).magnitude > 0.5)
    //        _rb.velocity = transform.position - _target;
    //}
}
