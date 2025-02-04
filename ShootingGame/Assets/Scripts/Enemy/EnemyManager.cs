using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float minTime = 0.5f;
    float maxTime = 1.5f;

    float currentTime = 0f;
    public float createTime = 1.0f;
    public GameObject enemyFactory;

    public int poolSize = 10;
    //GameObject[] enemyObjectPool;
    public List<GameObject> enemyObjectPool;
    public Transform[] spawnPoints;

    public static EnemyManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        //enemyObjectPool = new GameObject[poolSize];
        enemyObjectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            
            //enemyObjectPool[i] = enemy;
            enemyObjectPool.Add(enemy);

            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            //for (int i = 0; i < poolSize; i++)
            //{
            //    GameObject enemy = enemyObjectPool[i];
            //    if (enemy.activeSelf == false)
            //    {
            //        //enemy.transform.position = transform.position;
            //        int index = Random.Range(0, spawnPoints.Length);
            //        enemy.transform.position = spawnPoints[index].position;

            //        enemy.SetActive(true);
            //        // enemy의 transform position 설정을 먼저 한 후에 SetActive(true)를 해야한다.
            //        // enemy 게임 오브젝트의 OnEnable() 함수에서 enemy transform을 사용하기 때문이다.

            //        break;
            //    }
            //}

            if (enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool[0];

                int index = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].position;

                enemy.SetActive(true);
                enemyObjectPool.RemoveAt(0);
            }

            createTime = Random.Range(minTime, maxTime);
            currentTime = 0f;
        }
    }
}
