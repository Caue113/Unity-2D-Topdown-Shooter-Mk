using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestRaycast : MonoBehaviour
{
    public GameObject fruta1;
    public GameObject fruta2;

    public Fruta nomeFruta1;
    public Fruta nomeFruta2;

    public int pontos = 0;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // 3D test
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Debug.Log("3D Ray Test");
            //Debug.Log(ray);
            Debug.DrawRay(Camera.main.transform.position, ray.GetPoint(100f), Color.cyan, 3f);

            RaycastHit objHit;

            if (Physics.Raycast(ray, out objHit, 100))
            {
                Debug.Log(objHit.collider.gameObject.name);

                if (objHit.collider.gameObject.GetComponent<Fruta>())
                {
                    Debug.Log("É uma fruta");

                    

                    //Pegar primeira fruta
                    if(fruta1 == null)
                    {
                        fruta1 = objHit.collider.gameObject;
                        nomeFruta1 = objHit.collider.gameObject.GetComponent<Fruta>();
                    }
                    else if(fruta2 == null)
                    {
                        fruta2 = objHit.collider.gameObject;
                        nomeFruta2 = objHit.collider.gameObject.GetComponent<Fruta>();
                    }


                    //Se as duas frutas forem iguais
                    if(nomeFruta1.nome == nomeFruta2.nome)
                    {
                        //Dar pontos por acertar
                        pontos = pontos + 10;

                        //Remover as frutas
                        Destroy(fruta1);
                        Destroy(fruta2);

                        Debug.Log(fruta1 + " " + fruta2);
                        fruta1 = null;
                        fruta2 = null;
                        nomeFruta1 = null;
                        nomeFruta2 = null;
                    }
                    else
                    {
                        Debug.Log("As duas não são iguais :[");
                        fruta1 = null;
                        fruta2 = null;
                        nomeFruta1 = null;
                        nomeFruta2 = null;
                    }
                }
            }
        }
        
    }
}
