using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject particle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        Instantiate(particle, transform.position, Quaternion.identity);
        GameManager.instance.Collected += 1;
        Destroy(gameObject);
    }
}
