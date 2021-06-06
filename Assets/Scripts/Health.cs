using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Health : MonoBehaviour
{
    static public int health = 3;

    public PlayerData playerData;

    public GameObject playerObject;
    public Rigidbody2D rb;
    static public float invincibilityTimer = 2;

    //for Multiplayer
    static public float invincibilityTimerP2 = 2;


    public GameObject loseScreen;
    public GameObject playerLose;
    public GameObject button;
    public GameObject btnPause;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    //shieldSphere
    private float shieldRecharge = 0;
    private bool shieldActive = false;
    public GameObject shieldSphere;
    public GameObject shieldBreak;

    //for referencing if player is underwater
    public Player Player;

    private void Start()
    {
        health =  DataManager.Instance.playerData.numOfHearts;
        if( DataManager.Instance.playerData.shieldSphere == 1)
        {
            shieldActive = true;
            GameObject NewSphere = Instantiate(shieldSphere, rb.transform.position, Quaternion.identity);
            NewSphere.transform.SetParent(rb.transform);
        }
    }



    void Update()
    {
        invincibilityTimer += 1 * (Time.deltaTime * 1);
        invincibilityTimerP2 += 1 * (Time.deltaTime * 1);


        if (health >  DataManager.Instance.playerData.numOfHearts)
        {
            health =  DataManager.Instance.playerData.numOfHearts;
        }


        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i <  DataManager.Instance.playerData.numOfHearts)
            {
                hearts[i].enabled = true;
            }

            else
            {
                hearts[i].enabled = false;
            }
        }

        if(shieldActive == false && shieldRecharge >  DataManager.Instance.playerData.stageCalories &&  DataManager.Instance.playerData.shieldSphere == 1)
        {
            shieldActive = true;
            GameObject NewSphere = Instantiate(shieldSphere, transform.position, Quaternion.identity);
            NewSphere.transform.SetParent(rb.transform);
        }

        

    }

    private void OnTriggerEnter2D(Collider2D info)
    {
        if (shieldActive == false)
        {
            if (info.gameObject.CompareTag("Enemy") && health > 1 && invincibilityTimer >= 2)
            {
                invincibilityTimer = 0;
                health -=  1;

                if (Player.underwater == false && info.gameObject.transform.position.x <= playerObject.transform.position.x)
                {
                    rb.velocity = new Vector2(20, rb.velocity.y);
                }

                else if (Player.underwater == false && info.gameObject.transform.position.x > playerObject.transform.position.x)
                {
                    rb.velocity = new Vector2(-20, rb.velocity.y);
                }

                else if (Player.underwater == true)
                {
                    rb.velocity = new Vector2(0, -10);
                }
                FindObjectOfType<AudioManager>().Play("ouch");
            }

            else

            if (info.gameObject.CompareTag("Enemy") && health == 1 && invincibilityTimer >= 2)
            {
                health = 0;
                FindObjectOfType<AudioManager>().Play("ouch");

                Instantiate(playerLose, playerObject.transform.position, Quaternion.identity);
                Destroy(playerObject);

                loseScreen.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(button);
                UILastBtn.lastselect = button;
            }
        }

        else if (info.gameObject.CompareTag("Enemy") && shieldActive == true)
        {
            shieldActive = false;
            invincibilityTimer = 0;

            GameObject[] shields = GameObject.FindGameObjectsWithTag("Shield");
            foreach (GameObject shield in shields)
            {
                GameObject.Destroy(shield);
            }

            shieldRecharge =  DataManager.Instance.playerData.stageCalories - 10;

            if(info.gameObject.transform.position.x > playerObject.transform.position.x)
            {
                rb.velocity = new Vector2(20, rb.velocity.y);
            }

            else if (info.gameObject.transform.position.x <= playerObject.transform.position.x)
            {
                rb.velocity = new Vector2(-20, rb.velocity.y);
            }

            Instantiate(shieldBreak, transform.position, Quaternion.identity);
        }

    }
    private void OnTriggerStay2D(Collider2D info2)
    {
        if(shieldActive == false)
        { 
            if (info2.gameObject.CompareTag("Enemy") && health > 1 && invincibilityTimer >= 2)
            {
                invincibilityTimer = 0;
                FindObjectOfType<AudioManager>().Play("ouch");
                health -= 1;
                rb.velocity = new Vector2(-20, rb.velocity.y);
            }

            else if (info2.gameObject.CompareTag("Enemy") && health == 1 && invincibilityTimer >= 2)
            {
                health -= 1;
                FindObjectOfType<AudioManager>().Play("ouch");

                //destroy player object
                if(health <= 0)
                {
                    Instantiate(playerLose, playerObject.transform.position, Quaternion.identity);
                    Destroy(playerObject,0.1f);
                    Destroy(btnPause);

                    //End Screen
                    loseScreen.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(null);
                    EventSystem.current.SetSelectedGameObject(button);
                    UILastBtn.lastselect = button;
                }
            }

        }
        else if(info2.gameObject.CompareTag("Enemy") && shieldActive == true)
        {
            shieldActive = false;
            invincibilityTimer = 0;            
            shieldRecharge =  DataManager.Instance.playerData.stageCalories - 10;

            if(Player.underwater == false)
            {
                rb.velocity = new Vector2(-20, rb.velocity.y);
            }
            else if(Player.underwater == true)
            {
                rb.velocity = new Vector2(0, -10);
            }

            Destroy(shieldSphere);
            Instantiate(shieldBreak, transform.position, Quaternion.identity);
        }
    }
}
