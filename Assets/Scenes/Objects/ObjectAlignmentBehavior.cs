using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Object))]

public class ObjectAlignmentBehavior : MonoBehaviour
{
    private Object bird;

    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        bird = GetComponent<Object>();
    }

    // Update is called once per frame
    void Update()
    {
        var objects = FindObjectsOfType<Object>();
        var average = Vector3.zero;
        var found = 0;

        foreach (var bird in objects.Where(o => o != bird))
        {
            var diff = bird.transform.position - this.transform.position;
            if (diff.magnitude < radius)
            {
                average += bird.velocity;
                found += 1;
            }
        }


        if (found > 0)
        {
            average = average / found;
            bird.velocity += Vector3.Lerp(bird.velocity, average, Time.deltaTime);
        }
    }
}
