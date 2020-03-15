using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnimyScript : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public GameObject AasteroidExplosion;
    public GameObject ShipExplosion;
    // Start is called before the first frame update
    void Start()
    {
            player = GameObject.Find("Player");
            transform.LookAt(player.transform);
            GetComponent<Rigidbody>().velocity = transform.forward * speed * 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundary" || other.tag == "Enimy" || other.tag == "EnimyShot")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Instantiate(ShipExplosion, other.transform.position, other.transform.rotation);
        }
        if (other.tag == "Asteroid")
        {
            Instantiate(AasteroidExplosion, other.transform.position, other.transform.rotation);
        }
        Instantiate(AasteroidExplosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
