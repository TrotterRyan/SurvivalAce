using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathScript : MonoBehaviour
{
    public Transform player;
    Vector3 startPosition;
    Quaternion startRotation;
    Rigidbody rb;
    public GameObject planeModel;
    public GameObject otherPlayer;
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, otherPlayer.transform.position) < 750f)
        {
            //Mathf.Lerp(Time.timeScale, 0, 0.8f);
            Time.timeScale = 0.3f;  
        } else
        {
            //Mathf.Lerp(Time.timeScale, 1, 0.2f);
            Time.timeScale = 1f;
        }
        Debug.Log(Time.timeScale);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("Death"))
        {
            //Destroy(gameObject);
            // Instantiate(gameObject, Spawn);

            StartCoroutine(Respawn());
        }
    }
    
   IEnumerator Respawn()
   {
        planeModel.SetActive(false);
        rb.isKinematic = true;

        yield return new WaitForSecondsRealtime(3);

        transform.rotation = startRotation;
        player.transform.position = startPosition;

        rb.isKinematic = false;
        planeModel.SetActive(true);
    }
}