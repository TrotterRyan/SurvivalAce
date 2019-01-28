using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    
    public float BulletSpeed = 5;

    void Update()
    {
        transform.Translate(new Vector3(0, BulletSpeed * Time.deltaTime, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {

        Destroy(gameObject);
    }

}