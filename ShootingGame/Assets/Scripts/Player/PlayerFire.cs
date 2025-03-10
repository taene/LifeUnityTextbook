using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;
    //GameObject[] bulletObjectPool;
    public List<GameObject> bulletObjectPool;

    // Start is called before the first frame update
    void Start()
    {
        // 게임이 시작하기 전에 먼저 탄창이 채워져 있어야 게임을 진행할 수 있으므로, PlayerFire 객체가 태어날 때 탄창에 총알을 만들어 넣는다.
        //bulletObjectPool = new GameObject[poolSize];
        bulletObjectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);

            //bulletObjectPool[i] = bullet;
            bulletObjectPool.Add(bullet);

            bullet.SetActive(false);
        }

        // 실행되는 플랫폼이 안드로이드일 경우 조이스틱을 활성화시킨다.
#if UNITY_ANDROID
        GameObject.Find("Dynamic Joystick").SetActive(true);
#elif UNITY_EDITOR || UNITY_STANDALONE
        GameObject.Find("Dynamic Joystick").SetActive(false);
#endif
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR||UNITY_STANDALONE
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();

            //for (int i = 0; i < poolSize; i++)
            //{
            //    GameObject bullet = bulletObjectPool[i];
            //    if (bullet.activeSelf == false)
            //    {
            //        bullet.transform.position = firePosition.transform.position;
            //        bullet.SetActive(true);

            //        break;
            //    }
            //}
        }
#endif
    }

    public void Fire()
    {
        if (bulletObjectPool.Count > 0)
        {
            GameObject bullet = bulletObjectPool[0];
            bullet.SetActive(true);
            bulletObjectPool.RemoveAt(0);   // bulletObjectPool.Remove(bullet);

            bullet.transform.position = firePosition.transform.position;
        }
    }
}