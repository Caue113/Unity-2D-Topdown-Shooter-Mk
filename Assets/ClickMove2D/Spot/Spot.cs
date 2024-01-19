using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillSpot()
    {
        Destroy(this.gameObject);
    }
}
