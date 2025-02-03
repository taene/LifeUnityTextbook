using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // 유니티UI를 사용하기 위한 네임스페이스

public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI;
    public int currentScore;

    public Text bestScoreUI;
    public int bestScore;

    // Start is called before the first frame update
    void Start()
    {
        // 게임이 시작할 때 bestScore이 불러와져야 하므로
        // ScoreManager 객체가 태어날 때, 최고점수를 불러와 bestScore 변수에 할당하기
        bestScore = PlayerPrefs.GetInt("Best Score", 0);    // value의 0은 저장된 내용이 없을 경우, 기본 반환 값 지정
        bestScoreUI.text = "최고점수 : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
