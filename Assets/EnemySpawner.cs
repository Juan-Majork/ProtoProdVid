using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    private int selectEnemy;
    [SerializeField] private float waitToSpawn;
    [SerializeField] private float timeToSpawn;

    private void FixedUpdate()
    {
        timeToSpawn += Time.deltaTime;

        if (timeToSpawn > waitToSpawn)
        {
            selectEnemy = Random.Range(0, enemy.Length);
            Instantiate(enemy[selectEnemy], transform.position, Quaternion.identity);
            timeToSpawn = 0;
        }
    }
}
