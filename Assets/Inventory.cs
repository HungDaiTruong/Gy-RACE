using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject iconClou;
    public GameObject prefabClou;
    private bool isClou = false;

    public GameObject iconShield ;
    private bool isShield = false;
    // Start is called before the first frame update
    void Start()
    {
        iconShield.SetActive(false);
        iconClou.SetActive(false);
    }

    // Update is called once per frame
    public void getShield()
    {
        iconShield.SetActive(true);
        isShield = true;
    }
    public void getClou()
    {
        iconClou.SetActive(true);
        isClou = true;
    }

    public void useCloud() 
    {
        if (isClou)
        {
            iconClou.SetActive (false);
            isClou =false;
            Instantiate(prefabClou, GetComponent<Transform>().position+Vector3.back, Quaternion.identity);
        }
    }
    public void useShield()
    {
        if (isShield)
        {
            iconShield.SetActive(false);
            isShield = false;
            gameObject.GetComponent<shieldManager>().activeShield();
        }
    }
}
