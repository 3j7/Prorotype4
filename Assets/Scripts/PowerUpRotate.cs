using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRotate : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 rotate = new Vector3(0, 70, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(rotate * Time.deltaTime * speed);
    }
}
