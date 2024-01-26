using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaycastMove : MonoBehaviour
{
    GameObject personagemSelecionado;

    Vector3 posInicial;
    Vector3 posFinal;
    float distancia;

    public float velocidadeMover = 1f;
    bool podeMover;

    float lerp;
    
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.GetPoint(100f), Color.cyan, 3f);

            RaycastHit objHit;

            if (Physics.Raycast(ray, out objHit, 100))
            {
                Debug.Log(objHit.collider.gameObject.name);


                if (objHit.collider.GetComponent<Personagem>())
                {
                    personagemSelecionado = objHit.collider.gameObject;
                }
                else
                {
                    //Deselecionar
                    personagemSelecionado = null;
                    posInicial = Vector3.zero;
                    posFinal = Vector3.zero;
                }

            }
        }



        //Escolher onde mover
        if (Input.GetMouseButtonDown(1))
        {
            if(!personagemSelecionado)
            {
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.GetPoint(100f), Color.yellow, 3f);

            RaycastHit objHit;

            if (Physics.Raycast(ray, out objHit, 100))
            {
                //Layer 6 = chão. Podemos mover.
                if(objHit.collider.gameObject.layer == 6)
                {
                    podeMover = true;
                    lerp = 0;

                    posInicial = personagemSelecionado.transform.position;
                    posFinal = objHit.point;


                    personagemSelecionado.GetComponent<NavMeshAgent>().SetDestination(posFinal);

                    distancia = Vector3.Distance(posInicial, posFinal);
                }                
            }
        }

        //Mover
        /*
        if(personagemSelecionado != null && podeMover)
        {
            lerp += velocidadeMover * Time.deltaTime / distancia;

            //Dessa maneira, o personagem abaixará, entrando no chão. Não ideial
            //personagemSelecionado.transform.position = Vector3.Lerp(posInicial, posFinal, lerp);

            Vector3 posAlterado = Vector3.Lerp(posInicial, posFinal, lerp);
            personagemSelecionado.transform.position = new Vector3(posAlterado.x, personagemSelecionado.transform.position.y, posAlterado.z);

            if(lerp >= 1f)
            {
                lerp = 0f;
                podeMover = false;
            }
        }
        */
    }
}
