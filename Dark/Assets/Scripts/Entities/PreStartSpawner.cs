using System.Collections;
using UnityEngine;

public class PreStartSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnableObject;
    [SerializeField] private int countSpawn;
    [SerializeField] private int fieldWidth;
    [SerializeField] private int fieldHeight;
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while (countSpawn >= 0)
        {
            countSpawn--;
            Spawn();
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void Spawn()
    {
        var x = Random.Range(-fieldWidth / 2, fieldWidth / 2);
        var y = Random.Range(-fieldHeight / 2, fieldHeight / 2);
        Instantiate(spawnableObject, new Vector3(x,y), Quaternion.identity, transform);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(fieldHeight, fieldWidth));
    }
}
