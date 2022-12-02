using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [SerializeField] private LayerMask ignoreLayer;
    public Text cuenta;
    public float tiempo = 0.0f;
    public bool cronometro = false;
    // Start is called before the first frame update
    void Start()
    {
        IEnumerator coroutine()
            {

                yield return new WaitForSeconds(5f);

            }
    }

    // Update is called once per frame
    void Update()
    {
        
         
         tiempo -= Time.deltaTime;
         cuenta.text = "Tiempo:" + " " + tiempo.ToString ("f0");

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10f, ignoreLayer))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.green);
            Vector3 hitPosition = hit.point;
            string hitName = hit.transform.name;
            string hitTag = hit.transform.tag;
            float hitDistance = hit.distance;
        }

        else
        {
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
        }

        if (Input.GetButtonDown("Fire1"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit rayHit;

                    if (Physics.Raycast(ray, out rayHit))
                    {
                        Debug.Log(rayHit.transform.tag);

                        if (rayHit.transform.tag == ("Cubo1"))
                            {  
                                 SceneManager.LoadScene("Scene1 1");                               
                            }
        
                        if (rayHit.transform.tag == ("Cubo2"))
                            { 
                                 SceneManager.LoadScene("Scene1 2");
                            }

                        if (rayHit.transform.tag == ("Esfera"))
                            {
                                 SceneManager.LoadScene("Scene1 3");
                            }

        transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
    }
    }
    }
}


























