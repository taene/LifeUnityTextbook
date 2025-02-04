using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   // 유니티UI를 사용하기 위한 네임스페이스

public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI;
    private int currentScore;

    public Text bestScoreUI;
    private int bestScore;

    // 싱글턴 객체
    public static ScoreManager Instance = null;

    // 싱글턴 객체에 값이 없으면 생성된 자기 자신을 할당
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

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

    // get/set Property
    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
            currentScoreUI.text = "현재점수 : " + currentScore;

            // bestScore UI
            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = "최고점수 : " + bestScore;

                // 최고점수 클라이언트에 저장
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }

    /*
    public void SetScore(int value)
    {
        currentScore = value;
        currentScoreUI.text = "현재점수 : " + currentScore;

        // bestScore UI
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreUI.text = "최고점수 : " + bestScore;

            // 최고점수 클라이언트에 저장
            PlayerPrefs.SetInt("Best Score", bestScore);
        }
    }

    public int GetScore()
    {
        return currentScore;
    }
    */
}
