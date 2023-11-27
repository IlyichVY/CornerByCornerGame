using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball") Invoke("FallDown", 0.2f);// falls after 0.2 sec
    }
    void FallDown()
    {
        GetComponentInParent<Rigidbody>().isKinematic = false;
        GetComponentInParent<Rigidbody>().useGravity = true;
        Destroy(transform.parent.gameObject, 2f);
    }
}
