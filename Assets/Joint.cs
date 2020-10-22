using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public Joint[] nextJoints;
    public Joint nextJoint;
    int index = 0;
    float angle = 0;
    Vector3 currentDirection;
    Vector3 nextDirection;

    // Start is called before the first frame update
    void Start()
    {
        nextJoint = nextJoints[index];
        currentDirection = Vector3.forward;
        nextDirection = nextJoint.transform.position - transform.position;
        angle = Vector3.SignedAngle(currentDirection, nextDirection, Vector3.up);
        transform.Rotate(0, 0, -angle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick()
    {
        index = (index + 1) % nextJoints.Length;
        nextJoint = nextJoints[index];
        currentDirection = nextDirection;
        nextDirection = nextJoint.transform.position - transform.position;
        angle = Vector3.SignedAngle(currentDirection, nextDirection, Vector3.up);
        transform.Rotate(0, 0, -angle);
    }
}
