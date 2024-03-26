using System.Collections;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public float minTime = 3f;
    public float maxTime = 4f;
    public Transform targetVehicle;
    public float forwardOffset = 50f; // Offset hacia adelante desde el vehículo
    public float spawnHeight = 10f; // Altura de generación de los obstáculos

    void Start()
    {
        StartCoroutine(SpawnCoRoutine(0));
    }

    IEnumerator SpawnCoRoutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        // Calculamos la posición del objeto para que esté adelante del vehículo
        Vector3 spawnPosition = targetVehicle.position + targetVehicle.forward * forwardOffset;
        // Generamos el objeto en una posición aleatoria en el eje X dentro del rango del vehículo
        spawnPosition.x += Random.Range(-4f, 4f);
        // Establecemos la altura de generación
        spawnPosition.y = spawnHeight;
        // Generamos el objeto
        Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], spawnPosition, Quaternion.identity);

        // Esperamos un tiempo aleatorio para la siguiente generación
        StartCoroutine(SpawnCoRoutine(Random.Range(minTime, maxTime)));

    }
}