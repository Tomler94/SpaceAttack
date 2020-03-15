using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoundary : MonoBehaviour
{
    //Вызываается наряд, как только какой-либо объект пересекает границу
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
