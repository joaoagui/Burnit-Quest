using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SlingshotManager : MonoBehaviour
{
    [Header("P1 Sprites")]
    public SpriteRenderer P1Body;
    public SpriteRenderer P1ArmF;
    public SpriteRenderer P1HandF;
    public SpriteRenderer P1ArmB;
    public SpriteRenderer P1HandB;
    public SpriteRenderer P1Head;
    public SpriteRenderer P1Legs;

    [Header("P2 Sprites")]
    public SpriteRenderer P2Body;
    public SpriteRenderer P2ArmF;
    public SpriteRenderer P2HandF;
    public SpriteRenderer P2ArmB;
    public SpriteRenderer P2HandB;
    public SpriteRenderer P2Head;
    public SpriteRenderer P2Legs;

    [Header("Chay Sprites")]
    public Sprite ChayBody;
    public Sprite ChayArmF;
    public Sprite ChayHandF;
    public Sprite ChayArmB;
    public Sprite ChayHandB;
    public Sprite ChayHead;
    public Sprite ChayLegs;

    [Header("Game End")]
    public GameObject finishScreen;
    public GameObject pauseButton;
    public GameObject button;

    [Header("Score")]
    static public float p1Score;
    static public float p2Score;
    public Text P1ScoreText;
    public Text P2ScoreText;

    public TextMeshPro WinText;


    private int currentSpawnPoint = 1;


    [Header("Enemy Spawn System")]
    public int gulletNumber;

    public Transform gulletSpawn1;
    public Transform gulletSpawn2;
    public Transform gulletSpawn3;

    public Transform gulletSpawn4;
    public Transform gulletSpawn5;
    public Transform gulletSpawn6;

    public GameObject gullet;
    private IEnumerator coroutine;


    // Start is called before the first frame update
    void Start()
    {
        p1Score = 0;
        p2Score = 0;

        coroutine = SpawnGullets();
        StartCoroutine(coroutine);

        if (VersusSettings.P1Character == "Chay")
        {
            P1Body.sprite = ChayBody;
            P1ArmF.sprite = ChayArmF;
            P1HandF.sprite = ChayHandF;
            P1ArmB.sprite = ChayArmB;
            P1HandB.sprite = ChayHandB;
            P1Head.sprite = ChayHead;
            P1Legs.sprite = ChayLegs;
        }

        if (VersusSettings.P2Character == "Chay")
        {
            P2Body.sprite = ChayBody;
            P2ArmF.sprite = ChayArmF;
            P2HandF.sprite = ChayHandF;
            P2ArmB.sprite = ChayArmB;
            P2HandB.sprite = ChayHandB;
            P2Head.sprite = ChayHead;
            P2Legs.sprite = ChayLegs;
        }
    }

    // Update is called once per frame
    void Update()
    {
        P1ScoreText.text = "" + p1Score;
        P2ScoreText.text = "" + p2Score;
    }

    public void Finish()
    {
        if (p1Score > p2Score)
        {
            PauseMenu.paused = true;
            WinText.text = "P1 WINS!";
            finishScreen.SetActive(true);
            Destroy(pauseButton);
        }

        else if (p2Score > p1Score)
        {
            PauseMenu.paused = true;
            WinText.text = "P2 WINS!";
            finishScreen.SetActive(true);
            Destroy(pauseButton);
        }

        else if (p2Score == p1Score)
        {
            PauseMenu.paused = true;
            WinText.text = "DRAW!";
            finishScreen.SetActive(true);
            Destroy(pauseButton);
        }
    }


    public IEnumerator SpawnGullets()
    {

        while (gulletNumber > 0)
        {
            {

            gulletNumber -= 1;

            if (currentSpawnPoint == 6)
            {
                GameObject newGullet = Instantiate(gullet, gulletSpawn6.position, Quaternion.identity);
                newGullet.GetComponent<GulletFront>().movingUP = false;

                currentSpawnPoint = 1;
            }


            if (currentSpawnPoint == 5)
            {
                GameObject newGullet = Instantiate(gullet, gulletSpawn5.position, Quaternion.identity);
                newGullet.GetComponent<GulletFront>().movingUP = false;

                currentSpawnPoint += 1;
            }

            if (currentSpawnPoint == 4)
            {
                GameObject newGullet = Instantiate(gullet, gulletSpawn4.position, Quaternion.identity);
                newGullet.GetComponent<GulletFront>().movingUP = false;

                currentSpawnPoint += 1;
            }


            if (currentSpawnPoint == 3)
            {
                GameObject newGullet = Instantiate(gullet, gulletSpawn3.position, Quaternion.identity);
                newGullet.GetComponent<GulletFront>().movingUP = true;

                currentSpawnPoint += 1;
            }

            if (currentSpawnPoint == 2)
            {
                GameObject newGullet = Instantiate(gullet, gulletSpawn2.position, Quaternion.identity);
                newGullet.GetComponent<GulletFront>().movingUP = true;

                currentSpawnPoint += 1;
            }

            if (currentSpawnPoint == 1)
            {
                GameObject newGullet = Instantiate(gullet, gulletSpawn1.position, Quaternion.identity);
                newGullet.GetComponent<GulletFront>().movingUP = true;

                currentSpawnPoint += 1;
            }

            yield return new WaitForSeconds(2.5f);

            }

        }

        if(gulletNumber <= 0)
        {
            yield return new WaitForSeconds(9f);
            Finish();
            FindObjectOfType<AudioManager>().Play("whistle");

            Destroy(pauseButton);

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(button);
        }
    }
}
