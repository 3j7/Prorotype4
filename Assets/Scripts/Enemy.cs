using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float bottomBound = -30;
    public float speed = 1.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirecrion = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce( lookDirecrion * speed);
        if(transform.position.y < bottomBound)
        {
            Destroy(gameObject);
        }
    }
}
