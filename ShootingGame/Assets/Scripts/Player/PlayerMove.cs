using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 사용자의 입력에 따라 플레이어 이동시키기

    // 목표의 최종 내용: 플레이어를 이동시키고 싶다.
    // => 1. 질문) 어디로?
    // => 2. 답) 이동하려는 방향으로, 3. 사용자의 입력에 따라

    // 목표: 사용자의 입력에 따라 플레이어를 이동시키고 싶다.
    // 순서: 1. 사용자 입력 처리하기 2. 방향 만들기 3. 플레이어 이동시키기

    public float speed = 5;

    void Start()
    {
        
    }

    void Update()
    {
        // 플레이어 이동시키기 1
        // - 사용자 입력 처리
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Vector3 dir = Vector3.right * h + Vector3.up * v;   // 벡터의 더하기로 플레이어가 움직일 방향 구하기
        Vector3 dir = new Vector3(h, v, 0);

        //transform.Translate(dir * speed * Time.deltaTime);
        // 위 코드 P = P0 + vt 공식으로 변경!
        transform.position += dir * speed * Time.deltaTime;
    }
}
