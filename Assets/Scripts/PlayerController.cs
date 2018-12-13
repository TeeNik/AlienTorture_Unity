using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    public float Speed = 2;

	void Update () {
        float translation = Input.GetAxis("Vertical") * Speed;
        float rotation = Input.GetAxis("Horizontal") * Speed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        Vector3 move = new Vector3(rotation, translation, 0);
        //move.Normalize();

        transform.Translate(move);
    }
}
