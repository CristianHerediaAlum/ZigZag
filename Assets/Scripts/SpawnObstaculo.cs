using UnityEngine;

public class SpawnObstaculo : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform ground;
    public float spawnHeight = 0.5f; // Altura del suelo donde aparecerá el prefab
    public int numberOfPrefabsToSpawn = 5; // Número máximo de prefabs a generar

    void Start()
    {
        SpawnPrefabs();
    }

    void SpawnPrefabs()
    {
        if (ground == null)
        {
            Debug.LogError("No se ha asignado el objeto de suelo.");
            return;
        }

        for (int i = 0; i < numberOfPrefabsToSpawn; i++)
        {
            // Generamos un valor booleano aleatorio en cada iteración del bucle
            bool obstaculo = Random.value > 0.5f;

            if(obstaculo){
                float randomX = Random.Range(-ground.localScale.x / 2f, ground.localScale.x / 2f); // Ajuste para el suelo
                float randomZ = Random.Range(-ground.localScale.z / 2f, ground.localScale.z / 2f); // Ajuste para el suelo

                Vector3 spawnPosition = new Vector3(randomX, spawnHeight, randomZ);

                GameObject newPrefab = Instantiate(prefabToSpawn, ground.position + spawnPosition, Quaternion.identity);
            }
        }
    }
}

