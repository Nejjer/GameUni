using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class SpawnerEntities : MonoBehaviour
{
    [SerializeField] private GameObject spawnableObject;
    [SerializeField] private SpawnIn spawnIn;
    [SerializeField] private float frequencyPerSecond;
    [SerializeField] private int fieldWidth;
    [SerializeField] private int fieldHeight;
    [SerializeField] private float checkDarkRadius;
    [SerializeField] private int countTryingSpawn;
    [SerializeField] private float darkScope;


    private void Start() => StartCoroutine(SpawnCoroutine());

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(frequencyPerSecond);
        }
    }

    private void Spawn()
    {
        for (var i = 0; i < countTryingSpawn; i++)
        {
            var x = Random.Range(-fieldWidth / 2, fieldWidth / 2);
            var y = Random.Range(-fieldHeight / 2, fieldHeight / 2);
            transform.position = new Vector3(x, y);
            var items = Physics2D.OverlapCircleAll(transform.position, checkDarkRadius);
            foreach (var item in items)
            {
                if (item.TryGetComponent(out Light2D light))
                {
                    if (light.intensity <= darkScope && spawnIn == SpawnIn.Dark
                        || light.intensity > darkScope && spawnIn == SpawnIn.Light
                        || spawnIn == SpawnIn.Anywhere)
                    {
                        Instantiate(spawnableObject, transform.position, Quaternion.identity);
                        return;
                    }
                }
                else if (spawnIn == SpawnIn.Dark || spawnIn == SpawnIn.Anywhere)
                {
                    Instantiate(spawnableObject, transform.position, Quaternion.identity);
                    return;
                }
            }

            if (spawnIn == SpawnIn.Dark || spawnIn == SpawnIn.Anywhere)
            {
                Instantiate(spawnableObject, transform.position, Quaternion.identity);
                return;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkDarkRadius);
        Gizmos.DrawWireCube(transform.position, new Vector3(fieldHeight, fieldWidth));
    }


    enum SpawnIn
    {
        Dark,
        Light,
        Anywhere
    }
}