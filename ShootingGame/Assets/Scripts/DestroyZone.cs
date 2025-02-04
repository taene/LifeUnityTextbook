using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet"))
        {
            other.gameObject.SetActive(false);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            player.bulletObjectPool.Add(other.gameObject);
        }
        else if (other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);

            //EnemyManager enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
            //enemyManager.enemyObjectPool.Add(other.gameObject);
            EnemyManager.Instance.enemyObjectPool.Add(other.gameObject);
        }
    }
}
