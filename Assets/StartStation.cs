using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStation : MonoBehaviour
{
    public float startTime = 1.0f;
    public float intervalTime = 5.0f;
    public int lowerSpeed = 3;
    public int highSpeed = 6;
    public KartMovement[] kartPrefabs;
    public Joint startJoint;
    public Joint[] finalJoints;
    public Joint finalJoint;
    public GameObject parentTrain;
    public GameObject gameSystem;
    int kartIndex;
    int speed;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateKart", startTime, intervalTime);
        parentTrain = GameObject.Find("Kart");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateKart()
    {
        kartIndex = Random.Range(0, kartPrefabs.Length);
        speed = Random.Range(lowerSpeed, highSpeed);
        finalJoint = finalJoints[kartIndex];
        KartMovement childKart = Instantiate(kartPrefabs[kartIndex]);
        childKart.transform.parent = parentTrain.transform;
        childKart.Initialize(startJoint, finalJoint, finalJoints, speed); 
    }

}
