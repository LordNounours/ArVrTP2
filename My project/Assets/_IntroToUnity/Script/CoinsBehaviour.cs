using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsBehaviour : MonoBehaviour
{
    private AudioSource collisionSound; 
    public GameObject fx;
    public GameObject worldObject;

    void Start() {
        collisionSound = GameObject.Find("World").GetComponent<AudioSource>();
        worldObject = GameObject.Find("World");
    }

    void Update() {

    }

    void OnTriggerEnter(Collider other) { // OnCollisionEnter
        if (other.tag == "Player") {
         worldObject.SendMessage("AddHit");
         Instantiate(fx, transform.position, Quaternion.identity);
            if (collisionSound) {
                collisionSound.Play();
            }
            Destroy(gameObject);
        }
    }
}
