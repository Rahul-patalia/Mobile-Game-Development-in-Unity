using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    public GameObject fruit_pickup;

    private float min_X = -4.25f, max_X = 4.25f, min_Y = -2.26f, max_Y = 2.26f;
    private float z_pos = 5.8f;

    private Text Score_Text,gameOver_Text;
    private int ScoreCount;

    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        Score_Text = GameObject.Find("Score").GetComponent<Text>();
        gameOver_Text = GameObject.Find("GameOver").GetComponent<Text>();
        

        Invoke("StartSpawning", 0.5f);
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void StartSpawning()
    {
        StartCoroutine(SpawnPickups());
    }

    public void CancelSpawning()
    {
        CancelInvoke("StartSpawning");
    }

    IEnumerator SpawnPickups()
    {
        yield return new WaitForSeconds(Random.Range(1f, 1.5f));

        if (Random.Range(0, 10) >= 2)
        {
            Instantiate(fruit_pickup,
                new Vector3(Random.Range(min_X, max_X), Random.Range(min_Y, max_Y), z_pos),
                Quaternion.identity);
        }
        Invoke("StartSpawning", 0f);
    }

    public void increaseScore()
    {
        ScoreCount++;
        Score_Text.text = "Score : " + ScoreCount;
    }

    public void gameOver()
    {
        gameOver_Text.text = "Game Over";
    }
}
