using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    private float minX, minY, maxX, maxY;

    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject[] enemys;
    [SerializeField] private float enemyTime;

    private float nextEnemyTime;


    private void Start()
    {
        maxX = points.Max(points => points.position.x);
        maxY = points.Max(points => points.position.y);
        minX = points.Min(points => points.position.x);
        minY = points.Min(points => points.position.y);
    }

    private void Update()
    {
        nextEnemyTime += Time.deltaTime;

        if(nextEnemyTime >= enemyTime)
        {
            nextEnemyTime = 0;
            CreateEnemys();
        }
    }

    private void CreateEnemys()
    {
        int enemyNumber = Random.Range(0, enemys.Length);   
        Vector2 aleatoriPosition = new Vector2 (Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(enemys[enemyNumber], aleatoriPosition, Quaternion.identity);
    }
}
