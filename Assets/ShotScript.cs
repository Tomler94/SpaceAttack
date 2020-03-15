using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 myVector = new Vector3(0.1f, 0f, 0.1f);
        GetComponent<Rigidbody>().velocity = myVector * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
