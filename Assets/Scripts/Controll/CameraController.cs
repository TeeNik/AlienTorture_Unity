using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 _target;
    private Rigidbody2D _rb;
    private GameObject _player;
    public GameObject Main;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = Main.GetComponent<GameLayer>().Player;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.x >= Screen.width || Input.mousePosition.x <= 0 || Input.mousePosition.y <= 0 || Input.mousePosition.y >= Screen.height)
        {
            Vector3 mouseDir = Input.mousePosition - new Vector3(Screen.width, Screen.height) / 2;
            _target =_player.transform.position+mouseDir.normalized*4;
        }
        else
            _target = _player.transform.position;
        if ((transform.position - _target).magnitude > 0.5)
            _rb.velocity = (_target - transform.position).normalized*80;
    }
}
