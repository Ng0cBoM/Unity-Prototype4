using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2;
    private Rigidbody enemyRb;
    private GameObject player;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lockDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lockDirection*speed);
        if (transform.position.y < - 10) { Destroy(gameObject); }
    }
}
