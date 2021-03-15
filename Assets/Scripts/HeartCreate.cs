using UnityEngine;

public class HeartCreate : MonoBehaviour
{

    public GameObject Heart4;
    public GameObject Heart5;
    public GameObject Heart6;
    public GameObject Heart7;
    public GameObject Heart8;
    public GameObject Heart9;
    public GameObject Heart10;

    private GameObject Target;

    public GameObject heartAnimation;

    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Target.transform.position.x, Target.transform.position.y), 5);
    }

    void AddHeart()
    {

        if ( DataManager.Instance.playerData.numOfHearts == 3)
        {
            GameObject NewHeart = Instantiate(heartAnimation, Heart4.transform.position , Quaternion.identity);
            NewHeart.transform.SetParent(Heart4.transform);
        }
        
        if ( DataManager.Instance.playerData.numOfHearts == 4)
        {
            GameObject NewHeart = Instantiate(heartAnimation, Heart5.transform.position, Quaternion.identity);
            NewHeart.transform.SetParent(Heart5.transform);
        }

        if ( DataManager.Instance.playerData.numOfHearts == 5)
        {
            GameObject NewHeart = Instantiate(heartAnimation, Heart6.transform.position, Quaternion.identity);
            NewHeart.transform.SetParent(Heart6.transform);
        }

        if ( DataManager.Instance.playerData.numOfHearts == 6)
        {
            GameObject NewHeart = Instantiate(heartAnimation, Heart7.transform.position, Quaternion.identity);
            NewHeart.transform.SetParent(Heart7.transform);
        }

        if ( DataManager.Instance.playerData.numOfHearts == 7)
        {
            GameObject NewHeart = Instantiate(heartAnimation, Heart8.transform.position, Quaternion.identity);
            NewHeart.transform.SetParent(Heart8.transform);
        }

        if ( DataManager.Instance.playerData.numOfHearts == 8)
        {
            GameObject NewHeart = Instantiate(heartAnimation, Heart9.transform.position, Quaternion.identity);
            NewHeart.transform.SetParent(Heart9.transform);
        }

        if ( DataManager.Instance.playerData.numOfHearts == 9)
        {
            GameObject NewHeart = Instantiate(heartAnimation, Heart10.transform.position, Quaternion.identity);
            NewHeart.transform.SetParent(Heart10.transform);
        }
    }

    public void UpdateHealth()
    {
        DataManager.Instance.playerData.numOfHearts += 1;
        Health.health =  DataManager.Instance.playerData.numOfHearts;
    }
}
