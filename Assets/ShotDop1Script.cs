using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotDop1Script : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 myVector = new Vector3(-1f, 0f, 1f);
        GetComponent<Rigidbody>().velocity = myVector * speed;
    }

}
