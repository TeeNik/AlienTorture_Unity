using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDirection : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        float angle= 180 * Mathf.Atan2(mousePosition.y, mousePosition.x) / Mathf.PI; ;
        int horizontalDirection= (mousePosition.x>0) ? 1 : -1; 
        transform.rotation = Quaternion.Euler(0, 90-horizontalDirection*90,-90+ horizontalDirection*(90 + angle)); 
    }
}
