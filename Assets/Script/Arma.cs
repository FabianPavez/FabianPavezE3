using System.Collections;
using UnityEngine;

public class Arma : MonoBehaviour
{
    Renderer nave;
    float rateOfFire = 0.1f;
    [SerializeField]
    GameObject balablanca;
    [SerializeField]
    GameObject balanegra;
    
    void Start()
    {
        //pool dinamico, incrementa a si la cantidad requerida es mayor;;;

        ObjectPooling.PreLoad(balablanca, 20);
        ObjectPooling.PreLoad(balanegra, 10);
        nave = GetComponent<Renderer>();
        nave.material.SetColor("_Color", Color.white);
    }

    
    void Update()
        {

            if (nave.material.color == Color.white)
            {

                if (Input.GetButtonDown("Fire1"))
                {
                    InvokeRepeating("Disparo1", 0.01f, rateOfFire);

                }
            }
            else if (nave.material.color == Color.black)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    InvokeRepeating("Disparo2", 0.01f, rateOfFire);

                }
            }

            if (Input.GetButtonUp("Fire1"))
            {
                CancelInvoke("Disparo1");
                CancelInvoke("Disparo2");
            }


            if (Input.GetButtonDown("Fire2"))
            {
                Debug.Log("CAMBIANDO COLOR");
                if (nave.material.color == Color.white)
                {
                    nave.material.SetColor("_Color", Color.black);
                    CancelInvoke("Disparo1");

                }
                else if (nave.material.color == Color.black)
                {
                    nave.material.SetColor("_Color", Color.white);

                    CancelInvoke("Disparo2");
                }

            }
        }


        void Disparo1()
    {
        Vector2 vector = Salida();

        GameObject c = ObjectPooling.GetObject(balablanca);
        c.transform.position = vector;
        StartCoroutine(DeSpawn(balablanca, c, 2.0f));
    }

    void Disparo2()
    {
        Vector2 vector = Salida();
        GameObject s = ObjectPooling.GetObject(balanegra);
        s.transform.position = vector;
        StartCoroutine(DeSpawn(balanegra, s, 2.0f));
    }
    Vector2 Salida()
    {
        Vector2 vector = new Vector3(transform.position.x,transform.position.y, transform.position.z);
        return vector;
    }
    IEnumerator DeSpawn(GameObject primitive, GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        ObjectPooling.RecicleObject(primitive, go);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("balanegra"))
        {
            if (nave.material.color == Color.white)
            {
                Debug.Log("balanegra siendo blanco");
                GameManager.vida -= 1;
            }

        }
        if (collision.gameObject.CompareTag("balablanca"))
        {
            if (nave.material.color == Color.black)
            {
                Debug.Log("balablanca siendo negro");
                GameManager.vida -= 1;
            }

        }
    }
}





