using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SlingShotManager : MonoBehaviour
{
    [Header("Game End")]
    public int waves;
    public TextMeshPro goalText;


    public GameObject finishScreen;
    public GameObject pauseButton;
    public GameObject button;

    [Header("Score")]
    public Text P1ScoreText;

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
        coroutine = SpawnGullets();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        goalText.text = "" + gulletNumber;
    }

    public void Finish()
    {
        if (gulletNumber >= 0)
        {
            PauseMenu.paused = true;
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
            yield return new WaitForSeconds(9f);
            Finish();
            FindObjectOfType<AudioManager>().Play("whistle");

            Destroy(pauseButton);

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(button);
        }
    }
}
