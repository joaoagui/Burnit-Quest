using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EndStage : MonoBehaviour
{

    public GameObject pyre;
    public GameObject endScreen;
    public GameObject pauseButton;
    public GameObject skipButton;
    public GameObject player;
    public GameObject playerWin;
    private bool Won = false;

    //public characterControl characterControl;

    public Text coinCount;
    public Text caloryCount;
    public Text squatCount;
    public Text stepCount;
    public Text punchCount;
    public Text situpCount;
    public Text jumpingjackCount;

    public GameObject button;
       
    void Start()
    {
        //characterControl = FindObjectOfType<CharacterControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Won == false)
        {
            Destroy(pauseButton);            Destroy(skipButton);
            Won = true;
            UILastBtn.lastselect = button;
            pyre.SetActive(true);
            Invoke("EndScreen", 2f);
            Invoke("ReplacePlayer", 0.5f);
        }
        
    }

    void ReplacePlayer()
    {
        Instantiate(playerWin, player.transform.position, Quaternion.identity);
        Destroy(player);
    }
 

    void EndScreen()
    {
        endScreen.SetActive(true);
        squatCount.text = "" +  DataManager.Instance.playerData.Squats;
        caloryCount.text = "" +  DataManager.Instance.playerData.stageCalories.ToString("F2");
        stepCount.text = "" +  DataManager.Instance.playerData.stepsNumber.ToString();
        punchCount.text = "" +  DataManager.Instance.playerData.punches.ToString();
        situpCount.text = "" + DataManager.Instance.playerData.sitUps.ToString();
        jumpingjackCount.text = "" + DataManager.Instance.playerData.jumpingJacks.ToString();
        coinCount.text = "" + CoinsScript.stageCoins.ToString();

        if ( DataManager.Instance.playerData.currentStage >=  DataManager.Instance.playerData.stageComplete)
        {
             DataManager.Instance.playerData.stageComplete =  DataManager.Instance.playerData.currentStage + 1;
        }

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button);

    }

    
}
