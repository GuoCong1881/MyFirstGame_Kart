using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartMovement : MonoBehaviour
{
    public Joint previousJoint;
    public Joint currentJoint;
    public Joint nextJoint;
    public int speed;
    public Vector3 currentDirection;
    public Vector3 nextDirection;
    public float angle;
    public Joint finalJoint;
    public Joint[] finalJoints;
    public GameObject gameSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        gameSystem = GameObject.Find("Game System");
    }
    
    public void Initialize(Joint currentJoint, Joint finalJoint, Joint[] finalJoints, int speed)
    {
        transform.position = currentJoint.transform.position;
        this.speed = speed;
        this.currentJoint = currentJoint;
        this.nextJoint = currentJoint.nextJoint;
        this.finalJoint = finalJoint;
        this.finalJoints = finalJoints;
        this.currentDirection = Vector3.forward;
        this.nextDirection = nextJoint.transform.position - currentJoint.transform.position;
        this.angle = Vector3.SignedAngle(currentDirection, nextDirection, Vector3.up);
        transform.Rotate(Vector3.up, angle);

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, currentJoint.transform.position)< Vector3.Distance(currentJoint.transform.position, nextJoint.transform.position))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else
        {
            ChangeJoint();
        }

        foreach (Joint joint in finalJoints)
        {
            if (Vector3.Distance(transform.position, joint.transform.position) < 0.2)
            {
                
                if (joint == finalJoint)
                {
                    Destroy(gameObject);
                    Debug.Log("Car arrives the right gate!");
                    gameSystem.GetComponent<GameSystem>().AddMark();
                }
                else
                {
                    Destroy(gameObject);
                    Debug.Log("Car arrives the wrong gate T T");
                    gameSystem.GetComponent<GameSystem>().DeductMark();
                }

            }
        }
        /*
        if (gameSystem.GetComponent<GameSystem>().gameStarted == false)
        {
            Destroy(gameObject);
        }
        */
        
    }
    void ChangeJoint()
    {
        //this.previousJoint = currentJoint;
        this.currentJoint = nextJoint;
        this.nextJoint = currentJoint.nextJoint;
        this.currentDirection = nextDirection;
        this.nextDirection = nextJoint.transform.position - currentJoint.transform.position;
        angle = Vector3.SignedAngle(currentDirection, nextDirection, Vector3.up);
        transform.Rotate(Vector3.up, angle);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Cars collide!");
        gameSystem.GetComponent<GameSystem>().Collide();
        Destroy(gameObject);
    }

}
