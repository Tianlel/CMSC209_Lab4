using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBehavior : MonoBehaviour
{

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = this.transform.forward * 10;
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
