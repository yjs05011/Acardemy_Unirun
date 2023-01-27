using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = default;
    private const string UI_OBJS ="UiObjs";
    private const string SCORE_TEXT ="ScoreText";
    private const string GAME_OVER_UI ="GameOverUI";
    public bool isGameOver = false;
    private GameObject scoreTxtObj = default;
    private GameObject gameOverUi = default;

    private int score = default;
    // Start is called before the first frame update
    private void Awake() {
        if(instance == null){
            instance = this;

            isGameOver = false;
            GameObject uiObjs_ = GFunc.GetRootObj(UI_OBJS);
            scoreTxtObj = uiObjs_.FindChildObj(SCORE_TEXT);
            gameOverUi = uiObjs_.FindChildObj(GAME_OVER_UI);
            score = 0;
            //Init
            
        }// 게임 매니저가 존재하지 않는 경우 변수에 할당 및 초기화
        else{
            GFunc.LogWarning("[System] GameManager : Duplicated object warning");
            Destroy(gameObject);

        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == true && Input.GetMouseButtonDown(0)){
            GFunc.LoadScene(GFunc.GetActiveScene().name);
    }
    }

    public void AddScore(int newScore)
    {
        if (isGameOver == true)
        {
            return;
        }

        score += newScore;
        scoreTxtObj.SetTmpText($"점수 : {score}");

    }
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);
    }
}
