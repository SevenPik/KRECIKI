using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform barrel;
    public float shootingDistance;
    public GameObject Wie¿aBullet;
    public float FireRate;
    float nextTimeToFire;


    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player != null)
        {
            float distance = (transform.position - player.position).magnitude;
            if (distance < shootingDistance)
            {
                Vector3 aimdirection = (transform.position - player.position).normalized;
                float angle = Mathf.Atan2(aimdirection.y, aimdirection.x) * Mathf.Rad2Deg;
                barrel.localEulerAngles = new Vector3(0, 0, angle - 90);
            } else
            {

            }
        }
    }
}
