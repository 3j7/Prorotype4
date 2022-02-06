using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool hasPowerup;
    public float powerupTime = 20;
    public float speed = 10.0f;
    private float powerupStrengh = 15.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    // Start is called before the first frame update
    void Start()
    {
        
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
      
       
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward  * speed * forwardInput );
        powerupIndicator.transform.position = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
           
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpTime());
            powerupIndicator.gameObject.SetActive(true);
        }
    }
    IEnumerator PowerUpTime()
    {
       
        yield return new WaitForSeconds(powerupTime);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            Debug.Log("Collided with : " + collision.gameObject.name + "with powerup to  set" + hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrengh, ForceMode.Impulse);
        }
    }
}
