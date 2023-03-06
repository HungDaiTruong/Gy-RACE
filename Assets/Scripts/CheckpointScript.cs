using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public bool trigger = false;
    public GameObject vehicule;
    public bool last = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vehicule.Collider.OnCollisionEnter() && transform.parent != null)
        {
            if ((GetComponentInParent<Checkpoint>().trigger && GetComponentInParent<Checkpoint>()) || last)
            {
                trigger = true;
            }
            else if(!GetComponentInParent<Checkpoint>())
            {
                trigger = true;
                last = false;
            }

            if (transform.GetChild(0))
            {
                last = true;
            }

            if (last)
            {
                Debug.Log(last);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == vehicule && transform.parent != null)
        {
            if ((GetComponentInParent<Checkpoint>().trigger && GetComponentInParent<Checkpoint>()) || last)
                {
                    trigger = true;
                }
                else if(!GetComponentInParent<Checkpoint>())
                {
                    trigger = true;
                    last = false;
                }

                if (transform.GetChild(0))
                {
                    last = true;
                }

                if (last)
                {
                    Debug.Log(last);
                }
        }
    }
}
