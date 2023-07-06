using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject shield;
    public bool isShieldOn;

    void Start()
    {
        shield.SetActive(false);
        isShieldOn = false;
    }

    // Update is called once per frame
    public void activeShield()
    {
        shield.SetActive(true);
        isShieldOn = true;
        StartCoroutine(DelayShield());
    }
    private IEnumerator DelayShield()
    {

        yield return new WaitForSeconds(15);
        shield.SetActive(false);
        isShieldOn = false;
    }
}

