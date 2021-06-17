using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class SlingshotManager : MonoBehaviour
{
    [Header("Game End")]
    public int waves;
    public TextMeshProUGUI goalText;


    public GameObject finishScreen;
    public GameObject pauseButton;
    public GameObject skipButton;

    public GameObject button;

    public GameObject TutorialScreen;

    private int currentSpawnPoint = 2;

    [Header("Enemy Spawn System")]
    [SerializeField]
    public int amountofEnemies;
    public static int gulletNumber;
    public static int startingtNumber;


    public Transform gulletSpawn1;
    public Transform gulletSpawn2;
    public Transform gulletSpawn3;

    public Transform gulletSpawn4;
    public Transform gulletSpawn5;
    public Transform gulletSpawn6;

    public GameObject gullet;
    private IEnumerator coroutine;
    public GameObject gulletDead;

    public Text sitUpText;
    public Text caloryText;
    public Text coinText;



    // Start is called before the first frame update
    void Start()
    {
        gulletNumber = amountofEnemies;
        coroutine = SpawnGullets();
        StartCoroutine(coroutine);
        startingtNumber = gulletNumber;
        
    }

    // Update is called once per frame
    void Update()
    {
        goalText.text = "" + gulletNumber;
        
        if(gulletNumber + 1 < startingtNumber)
        {
            Destroy(TutorialScreen, 1f);
        }

        if(gulletNumber <= 0)
        {
            gulletNumber = 0;

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies)
            {
                GameObject.Destroy(enemy);
                Instantiate(gulletDead, enemy.transform.position, Quaternion.identity);
            }
        }
    }

    public void Finish()
    {
        if (gulletNumber >= 0)
        {
            PauseMenu.paused = true;

            sitUpText.text = "" + DataManager.Instance.playerData.sitUps;
            caloryText.text = "" + DataManager.Instance.playerData.stageCalories.ToString("F2");
            coinText.text = "" + CoinsScript.stageCoins;

            finishScreen.SetActive(true);
            Destroy(pauseButton);
        }
    }


    public IEnumerator SpawnGullets()
    {

        while (gulletNumber > 0)
        {
            {
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

        if (gulletNumber <= 0)
        {
            yield return new WaitForSeconds(1f);
            Finish();
            FindObjectOfType<AudioManager>().Play("whistle");

            Destroy(pauseButton);
            Destroy(skipButton);

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(button);
        }
    }
}
