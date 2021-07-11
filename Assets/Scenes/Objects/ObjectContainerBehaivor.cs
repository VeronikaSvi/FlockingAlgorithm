using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Object))]

public class ObjectContainerBehaivor : MonoBehaviour
{
    private Object bird;
    public float radius;
    public float boundaryForce;
    // Start is called before the first frame update
    void Start()
    {
        bird = GetComponent<Object>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.transform.position.magnitude > radius) {
            bird.velocity += this.transform.position.normalized * (radius - bird.transform.position.magnitude) * boundaryForce * Time.deltaTime;
        }
    }
}
