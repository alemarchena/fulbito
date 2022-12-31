

using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Pelota : MonoBehaviour
{
    //variables para el tiro

    public float velocidad = 15.0f;
    public float peso = 100f;
    private float gravedadAlcaer = -100;
    private Vector3 gravedadOri;
    private Rigidbody rigidbody = null;
    private Collider collider = null;


    private void Start()
    {
        collider = GetComponent<Collider>();
        rigidbody = GetComponent<Rigidbody>();
        gravedadOri = Physics.gravity; //guardo la gravedad original
        Physics.gravity = new Vector3(0, gravedadAlcaer, 0); //modifico la gravedad para que caiga mas rapido
    }

   
    public void Patea(Vector3 target)
    {
        rigidbody.isKinematic = false;
        StartCoroutine(SimularDisparo(target));
    }

    private IEnumerator SimularDisparo(Vector3 target)
    {
        // Short delay added before Projectile is thrown
        //yield return new WaitForSeconds(1.5f);

        // Move projectile to the position of throwing object + add some offset if needed.
        transform.position = transform.position + new Vector3(0, 0.0f, 0);

        // Calculate distance to target
        float distanciaAlObjetivo = Vector3.Distance(transform.position, target);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float velocidadDisparo = distanciaAlObjetivo  / (Mathf.Sin(2 * velocidad * Mathf.Deg2Rad) / peso);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(velocidadDisparo) * Mathf.Cos(velocidad * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(velocidadDisparo) * Mathf.Sin(velocidad * Mathf.Deg2Rad);

        // Calculate flight time.
        float duracionVuelo = distanciaAlObjetivo / Vx;

        // Rotate projectile to face the target.
        transform.rotation = Quaternion.LookRotation(target - transform.position);

        float transcurreTiempo = 0;
        while (transcurreTiempo < duracionVuelo)
        {
            transform.Translate(0, (Vy - (peso * transcurreTiempo)) * Time.deltaTime, Vx * Time.deltaTime );
            transcurreTiempo += Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            Debug.Log("Atajo");
            StartCoroutine(ParaPelota());
        }
        if (other.tag == "Sensor") {
            Debug.Log("Gol");
        }
    }

    IEnumerator ParaPelota() {

        yield return new WaitForSeconds(3f);

        rigidbody.isKinematic = true;

    }
}
