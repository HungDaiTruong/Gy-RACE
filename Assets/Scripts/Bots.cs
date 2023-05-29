using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bots : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] int Indextableau;
    [SerializeField] Transform[] tableau;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log((transform.position - tableau[Indextableau].position).magnitude);
        if((transform.position - tableau[Indextableau].position).magnitude <2)
        {
            Indextableau = (Indextableau + 1)%tableau.Length;
        }


       
            agent.destination = tableau[Indextableau].position;
        
    }

     
}

