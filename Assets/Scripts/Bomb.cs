using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item
{
    private float remainingDuration; // Remaining duration of the bomb

    public GameObject explosionPrefab; // Prefab for the explosion effect
    public float throwForce = 30f; // Force to throw the bomb forward
    public float explosionForce = 100f; // Force of the explosive pull
    public float explosionRadius = 30f; // Radius of the explosive pull
    public float explosionDelay = 1f; // Delay before the bomb explodes after collision
    public float pullDelay = 0.3f; // Delay before the pull effect starts
    public float pullDuration = 0.7f; // Duration of the pull effect

    private Rigidbody rb; // Reference to the Rigidbody component
    private bool hasExploded = false; // Flag to track if the bomb has exploded

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (remainingDuration > 0f)
        {
            remainingDuration -= Time.deltaTime;
            if (remainingDuration <= 0f)
            {
                EndUse();
            }
        }
    }

    public override void Use()
    {
        remainingDuration = duration; // Set the remaining duration to the total duration

        PlayerLocomotion playerLocomotion = GetComponentInParent<PlayerLocomotion>();

        Vector3 throwDirection = Quaternion.Euler(15f, 0f, 0f) * transform.forward; // Calculate the throw direction with an angle
        rb.isKinematic = false; // Enable the Rigidbody
        rb.AddForce(throwDirection * (throwForce + playerLocomotion.currentSpeed * 0.5f), ForceMode.VelocityChange); // Throw the bomb forward
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasExploded)
        {
            hasExploded = true;

            // Invoke the explosion effect after the specified delay
            Invoke("TriggerExplosion", explosionDelay);
        }
    }

    private void TriggerExplosion()
    {
        // Instantiate the explosion effect
        GameObject explosionObject = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Invoke the pull effect after the specified delay
        StartCoroutine(TriggerPull());

        // Destroy the explosion effect after the specified duration
        Destroy(explosionObject, pullDelay + pullDuration);
    }

    private IEnumerator TriggerPull()
    {
        yield return new WaitForSeconds(pullDelay);

        // Apply explosive force to nearby objects with specific tags
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player") || collider.CompareTag("Player2") || collider.CompareTag("AI"))
            {
                Rigidbody otherRb = collider.GetComponent<Rigidbody>();
                PlayerLocomotion playerLocomotion = collider.GetComponent<PlayerLocomotion>();

                if (otherRb != null && !playerLocomotion.isShielded)
                {
                    Vector3 direction = (collider.transform.position - transform.position).normalized;
                    otherRb.AddForce(direction * explosionForce, ForceMode.VelocityChange);
                    otherRb.AddForce(Vector3.up * explosionForce, ForceMode.VelocityChange); 
                }
            }
        }

        GetComponent<Collider>().enabled = false;
        GetComponent<Renderer>().enabled = false;

        yield return new WaitForSeconds(pullDuration);

        EndUse();
    }

    public override void EndUse()
    {
        Debug.Log("Bomb item ended!");
        Destroy(gameObject);
    }
}
