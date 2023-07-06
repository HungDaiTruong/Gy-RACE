using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpereItem : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        int rand = Random.Range(0, 2);
        Debug.Log(rand);
        if (rand == 0) 
        other.gameObject.GetComponent<Inventory>().getShield();

        if (rand == 1)
        other.gameObject.GetComponent<Inventory>().getClou();
    }
}
