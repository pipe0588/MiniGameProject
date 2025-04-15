using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GamePlayer : MonoBehaviour
{
     
    public string PlayerName; //문자 - string
    public int Score; //숫자 - int (소수점 x)
    public int Hp;
    public float GameTimer; // 숫자 - float (t소수점 O)
    public bool IsPlaying; //맞냐 틀리냐 true false

    public GameObject txtTimer;
    public GameObject txtName;
    public GameObject txtScoreValue;
    public GameObject txtHpValue;

    public GameObject coinPrefab;
    public GameObject enemyPrefab;

    public GameObject itemContainer;

    public GameObject enemyContainer;

    public int ItenCount = 30;
    public float mapSize = 20;

    private void Start()
    {
        txtName.GetComponent<TMP_Text>().text = PlayerName;
        txtTimer.GetComponent<TMP_Text>().text = Hp.ToString();

        // 생성
        // 오버로딩
        // Instantiate(coinPrefab, position, rotation);

        // enemyContainer.transform
        // enemyContainerGetComponent<Transform>()

        //제어문
        // if
        // for

        // 시작 끝 변화
        int count;
        for( count = 1; count <=ItenCount; count ++ )
        {
            Debug.Log("반복중입니다.");
            GameObject item = Instantiate(enemyPrefab, enemyContainer.transform);
            // 변수
            float halfSize = 20 / 2; // 20 * 0.5f;
            float randomX = Random.Range(halfSize * -1, halfSize);
            float randomZ = Random.Range(halfSize * -1, halfSize);
            item.transform.position = new Vector3(randomX, 1, randomZ);
        }

        for (count = 1; count <= ItenCount; count ++)
        {
            GameObject item = Instantiate(coinPrefab, itemContainer.transform);
            // 변수
            float halfSize = 20 / 2; // 20 * 0.5f;
            float randomX = Random.Range(halfSize * -1, halfSize);
            float randomZ = Random.Range(halfSize * -1, halfSize);
            item.transform.position = new Vector3(randomX, 1, randomZ);
        }


        // 파괴
        //Destroy(txtName);

        //활성화/비활성화
        //txtName.SetActive(true);
        //txtName.SetActive(false);

        //컴포넌트 접근
        //txtName.GetComponent<TMP_Text>();
    }


    private void Update()
    {
        if(!IsPlaying)
        {
            Debug.Log("게임이 끝났습니다!");
            return;
        }



        GameTimer = GameTimer - Time.deltaTime;
        if (GameTimer < 0)
        {
            IsPlaying = false;
        }

        txtTimer.GetComponent<TMP_Text>().text = GameTimer.ToString("F1");
    }




    private void OnTriggerEnter(Collider other)
    {
        bool isEnemy = other.gameObject.tag == "Enemy";
        bool isItem = other.gameObject.tag == "Item";

        if (isEnemy)
        {
            Debug.Log("Enemy Check");
            Hp = Hp - 1;

            // -1  0
            //    <  <=
            //    >  >=
            if(Hp <= 0)
            {
                IsPlaying = false;
            }

            // if hp <= 0   -IsPlaying = false 
        }

        if (isItem)
        {
            Debug.Log("Item Check");
            Score = Score + 1;

        }

        txtScoreValue.GetComponent<TMP_Text>().text = Score.ToString();
        txtHpValue.GetComponent<TMP_Text>().text = Hp.ToString();

        Destroy(other.gameObject);
    }

}
