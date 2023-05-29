using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private PlayerLapper playerLapper;

    private Transform movePositionTransform;
    private CheckpointScript checkpointScript;

    public Transform pivot;
    public Transform wheel;
    public Transform innerRing;

    public float maxSpeed;
    public float acceleration;
    public float handling;
    public float steeringSensitivity = 1f;

    private Rigidbody rb;
    private float currentSpeed;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerLapper = GetComponent<PlayerLapper>();
        checkpointScript = FindObjectOfType<CheckpointScript>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Goal();
    }

    private void FixedUpdate()
    {
        Move();
        VehicleRotations();
    }

    // Method to get the next destination of the AI
    private void Goal()
    {
        movePositionTransform = checkpointScript.collectionObject.transform.GetChild((playerLapper.checkpointIndex + 1) % CheckpointScript.checkpointNumber);
        navMeshAgent.SetDestination(movePositionTransform.position);
    }

    private void Move()
    {
        // True speed of the vehicle in-game
        float realSpeed = transform.InverseTransformDirection(rb.velocity).z;

        // Calculate the desired speed based on the current conditions
        if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, Time.deltaTime * (acceleration / 2f));
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0f, Time.deltaTime * handling / 5f);
        }

        // Calculate the desired direction towards the next waypoint
        Vector3 desiredDirection = movePositionTransform.position - transform.position;
        desiredDirection.y = 0f;
        desiredDirection.Normalize();

        // Calculate the desired velocity based on the current speed and desired direction
        Vector3 desiredVelocity = desiredDirection * currentSpeed;

        // Apply the desired velocity to the Rigidbody for smoother movement
        rb.velocity = desiredVelocity;

        // Adjust the NavMeshAgent's speed to match the desired speed
        navMeshAgent.speed = currentSpeed;
    }

    private void VehicleRotations()
    {
        // Rotates the wheel based on the current speed
        if (currentSpeed > 0f)
        {
            wheel.Rotate((currentSpeed * currentSpeed) * 1.73f * Time.deltaTime, 0f, 0f);
        }
        else if (currentSpeed < 0f)
        {
            wheel.Rotate(-(currentSpeed * currentSpeed) * 1.73f * Time.deltaTime, 0f, 0f);
        }

        // Tilt the vehicle sideways based on the steering input
        float zRotation = Mathf.Lerp(0f, -SteerInput() * 130f, Mathf.Abs(SteerInput()));
        pivot.localRotation = Quaternion.Euler(0f, 0f, zRotation);

        // Rotates the inner ring so it stays upright according to the ground
        innerRing.rotation = Quaternion.LookRotation(pivot.forward, Vector3.up);
    }

    private float SteerInput()
    {
        // Calculate the desired direction towards the next waypoint
        Vector3 desiredDirection = movePositionTransform.position - transform.position;
        desiredDirection.y = 0f;
        desiredDirection.Normalize();

        // Calculate the angle between the desired direction and the vehicle's forward direction
        float angle = Vector3.SignedAngle(transform.forward, desiredDirection, Vector3.up);

        // Normalize the angle to a range of -1 to 1 with steering sensitivity
        float normalizedAngle = Mathf.Clamp(angle / 180f, -1f, 1f) * steeringSensitivity;

        return normalizedAngle;
    }
}
