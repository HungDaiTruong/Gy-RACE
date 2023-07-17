using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLocomotion : MonoBehaviour
{
    // Vehicle parts
    public Transform pivot;
    public Transform wheel;
    public Transform innerRing;
    public Transform pod;

    // Handlers for each customization
    public WheelComponentHandler wheelComponentHandler;
    public EngineComponentHandler engineComponentHandler;
    public EnergySystemComponentHandler energySystemComponentHandler;

    // Player's item script
    private PlayerItem playerItem;

    private PlayerControls inputActions;
    public Rigidbody rb;

    [Header("Vehicle Stats")]
    [SerializeField]
    public float realSpeed = 0f;
    [SerializeField]
    public float currentSpeed;
    [SerializeField][Range(10, 100)]
    public float maxSpeed;
    [SerializeField][Range(1, 2)]
    private float turboMultiplier;
    [SerializeField][Range(10, 100)]
    private int backingSpeed;
    [SerializeField][Range(1, 5)]
    public int acceleration;
    [SerializeField][Range(1, 5)]
    public int handling;
    [SerializeField][Range(0, 300)]
    public int energy;
    [SerializeField][Range(100, 300)]
    public int energyCapacity;
    [SerializeField][Range(10, 50)]
    private int energyConsumption;
    [SerializeField][Range(10, 50)]
    private int energyRegeneration;
    [SerializeField]
    private int weight;

    [Space(10)]

    [Header("Player Inputs")]
    [SerializeField]
    private Vector2 movementInput;
    [SerializeField]
    private float driftInput;
    [SerializeField]
    private float turboInput;
    [SerializeField]
    private bool itemInput;
    [SerializeField]
    public bool lookingBackInput;
    [SerializeField]
    private bool isDrifting;
    [SerializeField]
    private bool isTurboing;

    [SerializeField]
    private float skippingInput1;
    [SerializeField]
    private float skippingInput2;

    [Space(10)]

    [Header("Vehicle Status")]
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private float lastGroundedTime;
    [SerializeField]
    public bool isSlowed;
    [SerializeField]
    public bool isShielded;
    [SerializeField]
    public bool isSkipping;

    public void OnEnable()
    {
        inputActions = new PlayerControls();
        inputActions.Enable();
    }

    public void OnDisable()
    {
        inputActions.Disable();
    }

    // Start is called before the first frame update
    private void Awake()
    {
        // Check for the number of players and destroys the surplus
        GameObject[] players1 = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] players2 = GameObject.FindGameObjectsWithTag("Player2");
        if (players1.Length > 1)
        {
            Destroy(players1[0]);
        }
        if (players2.Length > 1)
        {
            Destroy(players2[0]);
        }

        if (!CompareTag("AI"))
        {
            DontDestroyOnLoad(gameObject);
        }

        rb = GetComponent<Rigidbody>();
        playerItem = GetComponent<PlayerItem>();
    }

    private void Update()
    {
        // The Player 1 uses ZQSD Shift on default
        if(gameObject.CompareTag("Player"))
        {
            movementInput = inputActions.Player.Movement.ReadValue<Vector2>();
            driftInput = inputActions.Player.Drift.ReadValue<float>();
            turboInput = inputActions.Player.Turbo.ReadValue<float>();
            itemInput = inputActions.Player.Item.WasPressedThisFrame();
            lookingBackInput = inputActions.Player.Camera.WasPressedThisFrame();
        }

        // The Player 2 uses ARROWS LeftCtrl on default
        if (gameObject.CompareTag("Player2"))
        {
            movementInput = inputActions.Player2.Movement.ReadValue<Vector2>();
            driftInput = inputActions.Player2.Drift.ReadValue<float>();
            turboInput = inputActions.Player2.Turbo.ReadValue<float>();
            itemInput = inputActions.Player2.Item.WasPressedThisFrame();
            lookingBackInput = inputActions.Player2.Camera.WasPressedThisFrame();
        }

        ItemHandler();

        skippingInput1 = inputActions.UI.Skip1.ReadValue<float>();
        skippingInput2 = inputActions.UI.Skip2.ReadValue<float>();

        if(skippingInput1 > 0 && skippingInput2 > 0 && (CompareTag("Player") || CompareTag("Player2")))
        {
            isSkipping = true;
        }
        else
        {
            isSkipping = false;
        }
    }

    private void FixedUpdate()
    {
        if (!gameObject.CompareTag("AI"))
        {
            Move();
            Steer();
            IsGrounded();
            VehicleRotations();
            EnergyHandler();
        }
    }

    // Handles forward and backward movement
    private void Move()
    {
        // True speed of the vehicle ingame
        realSpeed = transform.InverseTransformDirection(rb.velocity).z;

        // If forward/backward then the current speed value of the vehicle works up towards the maximum speed
        if (movementInput.y > 0 && isGrounded)
        {
            // If the turbo is activated and the player is moving forward
            if (turboInput > 0 && energy > 0)
            {
                isTurboing = true;
                currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed * turboMultiplier, Time.deltaTime * (acceleration / 2f));
            }
            // If the turbo isn't activated and the player isn't pressing anything
            else
            {
                isTurboing = false;
                currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed * movementInput.y, Time.deltaTime * (3f * acceleration / 30f));
            }
        }
        // If the player is backing up
        else if(movementInput.y < 0 && isGrounded)
        {
            isTurboing = false;
            currentSpeed = Mathf.Lerp(currentSpeed, backingSpeed * movementInput.y, Time.deltaTime * (3f * acceleration / 10f));
        }
        else
        {
            if (isGrounded)
            {
                // If grounded, the vehicle's speed value cannot be built up and decelerates back to the true speed
                isTurboing = false;
                currentSpeed = Mathf.Lerp(currentSpeed, 0f, Time.deltaTime * handling / 5f);
            }
            else
            {
                // If airborne, the vehicle can continue to build up it's speed value regardless of the true speed
                isTurboing = false;
                currentSpeed = Mathf.Lerp(currentSpeed, 0f, Time.deltaTime * handling / 5f);
            }
        }

        // Apply the current speed values into a forward vector force
        Vector3 force = transform.forward * currentSpeed;

        force.y = rb.velocity.y;
        rb.mass = weight;
        // Apply the force to the rigidbody velocity
        if (isGrounded)
        {
            rb.velocity = force;
        }
        //Debug.DrawRay(transform.position, transform.forward, Color.blue);
    }

    // Method that handles all the steering and drifting movements
    private void Steer()
    {
        Vector3 steerForce;
        float steerAmount;

        // Drifting animations and drifting force
        if (movementInput.x > 0 && driftInput > 0 && isGrounded && realSpeed > maxSpeed * 0.5f)
        {
            isDrifting = true;
            pivot.localRotation = Quaternion.Lerp(pivot.localRotation, Quaternion.Euler(0f, 90f, 0f), Time.deltaTime);

            // Calculate the surface normal and apply the drifting force in that direction
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit))
            {
                Vector3 surfaceNormal = hit.normal;
                Vector3 driftForce = Vector3.Cross(surfaceNormal, Vector3.up).normalized;
                rb.AddForce(driftForce * -(currentSpeed * weight) / 5f * Time.deltaTime, ForceMode.Acceleration);
            }
        }
        else if (movementInput.x < 0 && driftInput > 0 && isGrounded && realSpeed > maxSpeed * 0.5f)
        {
            isDrifting = true;
            pivot.localRotation = Quaternion.Lerp(pivot.localRotation, Quaternion.Euler(0f, -90f, 0f), Time.deltaTime);

            // Calculate the surface normal and apply the drifting force in that direction
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit))
            {
                Vector3 surfaceNormal = hit.normal;
                Vector3 driftForce = Vector3.Cross(surfaceNormal, Vector3.up).normalized;
                rb.AddForce(driftForce * (currentSpeed * weight) / 5f * Time.deltaTime, ForceMode.Acceleration);
            }
        }
        else
        {
            isDrifting = false;
            pivot.localRotation = Quaternion.Lerp(pivot.localRotation, Quaternion.Euler(0f, pivot.localRotation.y, 0f), Time.deltaTime);
        }

        // If the actual speed is too high, then steering becomes more difficult
        if (isDrifting)
        {
            steerAmount = realSpeed > 50f / handling ? (realSpeed / (1f / handling * 3.5f) * movementInput.x) : steerAmount = (realSpeed / (0.5f / handling * 2.5f) * movementInput.x);
        }
        else
        {
            steerAmount = realSpeed > 50f / handling ? (realSpeed / (5f / handling) * movementInput.x) : steerAmount = (realSpeed / (2f / handling) * movementInput.x);
        }
        steerForce = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + steerAmount, transform.eulerAngles.z);
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, steerForce, 3 * Time.deltaTime);
    }

    // Method that manages the vehicle's energy levels
    private void EnergyHandler()
    {
        if (isTurboing)
        {
            // Drains the energy when turboing
            energy = (int)Mathf.Clamp(energy - Time.deltaTime * energyConsumption, 0, energyCapacity);
        }
        else if (isDrifting)
        {
            // Regenerates the energy when drifting
            energy = (int)Mathf.Clamp(energy + Time.deltaTime * energyRegeneration * 5, 0, energyCapacity);
        }
    }

    private void ItemHandler()
    {
        if(itemInput)
        {
            playerItem.UseItem();
        }
    }

    private void IsGrounded()
    {
        // Sends a raycast downward to check if there is ground, if so then rotate the vehicle according to the ground normal
        RaycastHit hit;
        if(Physics.Raycast(transform.position + new Vector3(0f, 0.2f, 0f), -transform.up, out hit, 1.5f))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.up * 2, hit.normal) * transform.rotation, 7.5f * Time.deltaTime);
            isGrounded = true;
            lastGroundedTime = Time.time; // Update the last grounded time
        }
        // Else if the vehicle is airborne, then rotate the vehicle back to the vertical global axis
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.up * 2, Vector3.up) * transform.rotation, 3f * Time.deltaTime);
            isGrounded = false;

            // Check if the vehicle hasn't been grounded for X seconds
            if (Time.time - lastGroundedTime >= 5f && FindObjectOfType<OutOfBounds>() != null)
            {
                lastGroundedTime = Time.time;
                FindObjectOfType<OutOfBounds>().OnTriggerEnter(GetComponent<Collider>());
            }
        }
        //Debug.DrawRay(transform.position + new Vector3(0f, 0.2f, 0f), -transform.up, Color.red, 10f);
    }

    public IEnumerator IsSlowed(float duration)
    {
        if (!isShielded)
        {
            isSlowed = true;

            currentSpeed /= 4f;
            realSpeed /= 4f;
            maxSpeed /= 2f;

            yield return new WaitForSeconds(duration);

            isSlowed = false;
            maxSpeed = (int)wheelComponentHandler.speed;
        }
    }

    private void VehicleRotations()
    {
        // Rotates the wheel according to the real speed
        if (currentSpeed > 0f)
        {
            wheel.Rotate((realSpeed * realSpeed) * 1.73f * Time.deltaTime, 0f, 0f);
        }
        else if(currentSpeed < 0f)
        {
            wheel.Rotate(-(realSpeed * realSpeed) * 1.73f * Time.deltaTime, 0f, 0f);
        }

        // Tilt the vehicle sideway for a more dynamic steering, the more intense the steering speed, the lower the vehicle tilts
        if (movementInput.x > 0)
        {
            float zRotation = -Mathf.Clamp(currentSpeed * 1.3f, -130, maxSpeed);
            pivot.localRotation = Quaternion.Lerp(pivot.localRotation, Quaternion.Euler(0f, 0f, zRotation), Time.deltaTime);
        }
        else if (movementInput.x < 0)
        {
            float zRotation = Mathf.Clamp(currentSpeed * 1.3f, -130, maxSpeed);
            pivot.localRotation = Quaternion.Lerp(pivot.localRotation, Quaternion.Euler(0f, 0f, zRotation), Time.deltaTime);
        }

        // Rotates the inner ring so it stays upright according to the ground
        innerRing.rotation = Quaternion.LookRotation(pivot.forward, Vector3.up);
    }

    public void EnableMovements()
    {
        // Removes the constraints of the displayed menu vehicule
        rb.constraints = ~RigidbodyConstraints.FreezePosition;
    }

    public void ApplyStats()
    {
        // Apply the selected stats from the menu to the playable vehicle
        maxSpeed = (int)wheelComponentHandler.speed;
        handling = (int)wheelComponentHandler.handling;
        acceleration = (int)engineComponentHandler.acceleration;
        turboMultiplier = engineComponentHandler.turboMultiplier;
        energyConsumption = (int)energySystemComponentHandler.energyConsumption;
        energyRegeneration = (int)energySystemComponentHandler.energyRegeneration;
    }
}
