using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private PlayerLapper playerLapper;

    [SerializeField]
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
        checkpointScript = FindObjectOfType<CheckpointScript>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerLapper = GetComponent<PlayerLapper>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        navMeshAgent.Warp(checkpointScript.collectionObject.transform.GetChild(0).transform.position - new Vector3(-20f, 0, 0f));
        navMeshAgent.transform.rotation = checkpointScript.collectionObject.transform.GetChild(0).transform.rotation * Quaternion.Euler(0, -90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Goal();
    }

    private void FixedUpdate()
    {
        Move();
        Steer();
        VehicleRotations();
    }

    // Method to get the next destination of the AI
    private void Goal()
    {
        if(movePositionTransform == null)
        {
            checkpointScript = FindObjectOfType<CheckpointScript>();
        }
        movePositionTransform = checkpointScript.collectionObject.transform.GetChild((playerLapper.checkpointIndex + 1) % CheckpointScript.checkpointNumber);
        navMeshAgent.SetDestination(movePositionTransform.position);
    }

    private void Move()
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = (navMeshAgent.steeringTarget - transform.position).normalized * maxSpeed;

        // Calculate steering force
        Vector3 steeringForce = desiredVelocity - rb.velocity;

        // Apply acceleration to the rigidbody
        rb.AddForce(steeringForce * acceleration, ForceMode.Acceleration);

        // Limit the velocity to the maximum speed
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        // Adjust the agent's rotation based on its velocity
        if (rb.velocity.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rb.velocity.normalized, transform.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, handling * Time.deltaTime);
        }

        // Update the current speed based on the rigidbody's velocity magnitude
        currentSpeed = rb.velocity.magnitude;
    }

    private void Steer()
    {
        // Calculate the target rotation towards the current target position
        Quaternion targetRotation = Quaternion.LookRotation(navMeshAgent.steeringTarget - transform.position, transform.up);

        // Calculate the relative rotation needed to reach the target rotation
        Quaternion relativeRotation = Quaternion.Inverse(transform.rotation) * targetRotation;

        // Calculate the angle between the current forward direction and the target direction
        float angle = Vector3.Angle(transform.forward, targetRotation * Vector3.forward);

        // Calculate the steering amount based on the angle and steering sensitivity
        float steeringAmount = Mathf.Clamp01(angle / steeringSensitivity);

        // Calculate the desired speed based on the steering amount and max speed
        float desiredSpeed = maxSpeed * steeringAmount;

        // Calculate the deceleration rate based on the difference between desired and current speed
        float decelerationRate = (currentSpeed - desiredSpeed) / currentSpeed;

        // Apply the steering rotation to the agent's transform
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, handling * Time.deltaTime);

        // Adjust the agent's velocity based on the deceleration rate
        rb.velocity *= Mathf.Max(1f - decelerationRate, 0f);
    }




    /*private void Move()
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
        if (movePositionTransform != null)
        {
            Vector3 desiredDirection = movePositionTransform.position - transform.position;
            desiredDirection.y = 0f;
            desiredDirection.Normalize();


            // Calculate the desired velocity based on the current speed and desired direction
            Vector3 desiredVelocity = desiredDirection * currentSpeed;


            // Apply the desired velocity to the Rigidbody for smoother movement
            rb.velocity = desiredVelocity;
        }

        // Adjust the NavMeshAgent's speed to match the desired speed
        navMeshAgent.speed = currentSpeed;
        navMeshAgent.acceleration = acceleration;
    }*/

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
        if (movePositionTransform != null)
        {
            Vector3 desiredDirection = movePositionTransform.position - transform.position;
            desiredDirection.y = 0f;
            desiredDirection.Normalize();

            // Calculate the angle between the desired direction and the vehicle's forward direction
            float angle = Vector3.SignedAngle(transform.forward, desiredDirection, Vector3.up);

            // Normalize the angle to a range of -1 to 1 with steering sensitivity
            float normalizedAngle = Mathf.Clamp(angle / 180f, -1f, 1f) * steeringSensitivity;

            return normalizedAngle;
        }
        else return 0;
    }
}
