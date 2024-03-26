using System.Collections;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public float minTime = 3f;
    public float maxTime = 4f;
    public Transform targetVehicle;
    public float forwardOffset = 50f; // Offset hacia adelante desde el veh�culo
    public float spawnHeight = 10f; // Altura de generaci�n de los obst�culos

    void Start()
    {
        StartCoroutine(SpawnCoRoutine(0));
    }

    IEnumerator SpawnCoRoutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        // Calculamos la posici�n del objeto para que est� adelante del veh�culo
        Vector3 spawnPosition = targetVehicle.position + targetVehicle.forward * forwardOffset;
        // Generamos el objeto en una posici�n aleatoria en el eje X dentro del rango del veh�culo
        spawnPosition.x += Random.Range(-4f, 4f);
        // Establecemos la altura de generaci�n
        spawnPosition.y = spawnHeight;
        // Generamos el objeto
        Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], spawnPosition, Quaternion.identity);

        // Esperamos un tiempo aleatorio para la siguiente generaci�n
        StartCoroutine(SpawnCoRoutine(Random.Range(minTime, maxTime)));

    }
}