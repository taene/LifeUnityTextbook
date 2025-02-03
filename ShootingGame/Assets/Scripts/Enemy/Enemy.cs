using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;

    // enemy와 다른물체가 충돌 시 폭발효과 발생:
    // 1. 적이 다른 물체와 충돌(enemy script-OnCollisionEnter)했으니까
    // 2. 폭발 효과 공장에서 폭발 효과를 하나 만들어야 한다.
    // 3. 폭발효과를 발생(위치)시키고 싶다.
    // 폭발 공장 주소(외부에서 값 넣음)
    public GameObject explosionFactory;

    // Start is called before the first frame update
    void Start()
    {
        int randValue = Random.Range(0, 10);
        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        // currentScore UI
        GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager scoreManager = smObject.GetComponent<ScoreManager>();

        scoreManager.SetScore(scoreManager.GetScore() + 1);

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
