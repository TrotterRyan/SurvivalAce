using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    //do it for the meme and praise the booty
    // praise the sun
    public GameObject BulletPrefab;
    //public Transform bulletspawn;
    public float BulletSpeed;
    public float BulletCooldownTime;
    public float BulletLastFireTime;
    Transform PlaneModel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire") && Time.time - BulletLastFireTime > BulletCooldownTime)
        {
            GameObject Bullet = Instantiate(BulletPrefab, PlaneModel.transform.position + new Vector3(1, 0, 0), transform.rotation);
            Bullet.GetComponent<Bullet>().BulletSpeed = BulletSpeed;
            Bullet.transform.Rotate(Vector3.right * 90);
            Destroy(Bullet, 30f);
            BulletLastFireTime = Time.time;
        }
    }
}
