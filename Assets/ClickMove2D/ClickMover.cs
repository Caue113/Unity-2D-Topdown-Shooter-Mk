using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClickMover : MonoBehaviour
{
    public float speed = 15f;

    public Vector2 currPoint = Vector2.zero;
    public Vector2 nextPoint = Vector2.zero;

    public bool isMoving = false;

    float distance = 0f;
    float lerp = 0f;

    /* Outer references */
    public GameObject visualReference;

    void Start()
    {

    }

    void Update()
    {


        if(Input.GetMouseButtonDown(0))
        {

            //3D test
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            Debug.Log("3D Ray Test");
            Debug.Log(ray);
            RaycastHit objHit;

            if (Physics.Raycast(ray, out objHit, 100))
            {
                Debug.Log(objHit.collider.gameObject.name);
            }


            //2D test
            RaycastHit2D objHit2d;

            if (Physics2D.Raycast(Camera.main.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {

            }
            


            Debug.DrawRay(Camera.main.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

            
        }


        //Move jogador
        if(Input.GetMouseButtonDown(1))
        {
            //Always reset
            lerp = 0f;


            currPoint = transform.position;
            nextPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            distance = Vector2.Distance(transform.position, nextPoint);

            /*
            Debug.Log("Curr:"+Input.mousePosition);
            Debug.Log("Next:"+nextPoint);
            Debug.Log("Dist:" + distance);
            */


            isMoving = true;
            InstantiateReference();
        }

        
        if (isMoving)
        {
            lerp += (speed * Time.deltaTime) / distance;
            Debug.Log("lerp:" + lerp);

            transform.position = Vector2.Lerp(currPoint, nextPoint, lerp);

            if(lerp >= 1f) 
            {
                isMoving = false;
                lerp = 0f;
            }
        }
    }

    private void InstantiateReference()
    {
        Instantiate(visualReference, nextPoint, Quaternion.identity);
    }


}
