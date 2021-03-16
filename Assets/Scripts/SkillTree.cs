using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


public class SkillTree : MonoBehaviour
{
    public PlayerData playerData;

    public TMP_Text TotalBubbles;

    public GameObject NoMoneyPopup;


    //error sound
    [Header("Not enough bubbles")]
    public GameObject BuyEffect;
    public Animator animator;

    //start selected button
    public GameObject FirstButton;



    //locked skills
    [Header("Locked Skills")]
    public GameObject Speedlvl2_inactive;
    public GameObject Speedlvl3_inactive;
    public GameObject Jumplvl1_inactive;
    public GameObject Jumplvl2_inactive;
    public GameObject SuperJump_inactive;

    public GameObject Heartlvl2_inactive;
    public GameObject Heartlvl3_inactive;
    public GameObject Magnetlvl1_inactive;
    public GameObject Magnetlvl2_inactive;
    public GameObject ShieldSphere_inactive;

    public GameObject Punchlvl2_inactive;
    public GameObject Punchlvl3_inactive;
    public GameObject Multi1_inactive;
    public GameObject Multil2_inactive;
    public GameObject PunchCombo_inactive;

    [Header("Skills Check")]
    public GameObject Speedlvl1_check;
    public GameObject Speedlvl2_check;
    public GameObject Speedlvl3_check;
    public GameObject Jumplvl1_check;
    public GameObject Jumplvl2_check;
    public GameObject SuperJump_check;

    public GameObject Heartlvl1_check;
    public GameObject Heartlvl2_check;
    public GameObject Heartlvl3_check;
    public GameObject Magnetlvl1_check;
    public GameObject Magnetlvl2_check;
    public GameObject ShieldSphere_check;

    public GameObject Punchlvl1_check;
    public GameObject Punchlvl2_check;
    public GameObject Punchlvl3_check;
    public GameObject Multi1_check;
    public GameObject Multil2_check;
    public GameObject PunchCombo_check;


    [Header("Speed Level 1")]
    public TextMeshPro SpeedLvl1_txt;
    public int SpeedLvl1Cost;

    [Header("Speed Level 2")]
    public TextMeshPro SpeedLvl2_txt;
    public int SpeedLvl2Cost;

    [Header("Speed Level 3")]
    public TextMeshPro SpeedLvl3_txt;
    public int SpeedLvl3Cost;

    [Header("Jump Level 1")]
    public TextMeshPro JumpLvl1_txt;
    public int JumpLvl1Cost;

    [Header("Jump Level 2")]
    public TextMeshPro JumpLvl2_txt;
    public int JumpLvl2Cost;

    [Header("Super Jump")]
    public TextMeshPro SuperJump_txt;
    public int SuperJumpCost;

    [Header("Heart Level 1")]
    public TextMeshPro HeartLvl1_txt;
    public int HeartLvl1Cost;

    [Header("Heart Level 2")]
    public TextMeshPro HeartLvl2_txt;
    public int HeartLvl2Cost;

    [Header("Heart Level 3")]
    public TextMeshPro HeartLvl3_txt;
    public int HeartLvl3Cost;

    [Header("Magnet Level 1")]
    public TextMeshPro MagnetLvl1_txt;
    public int MagnetLvl1Cost;

    [Header("Magnet Level 2")]
    public TextMeshPro MagnetLvl2_txt;
    public int MagnetLvl2Cost;

    [Header("Shield Sphere")]
    public TextMeshPro ShieldSphere_txt;
    public int ShieldSphereCost;

    [Header("Punch Level 1")]
    public TextMeshPro PunchLvl1_txt;
    public int PunchLvl1Cost;

    [Header("Punch Level 2")]
    public TextMeshPro PunchLvl2_txt;
    public int PunchLvl2Cost;

    [Header("Punch Level 3")]
    public TextMeshPro PunchLvl3_txt;
    public int PunchLvl3Cost;

    [Header("Multi Level 1")]
    public TextMeshPro MultiLvl1_txt;
    public int MultiLvl1Cost;

    [Header("Multi Level 2")]
    public TextMeshPro MultiLvl2_txt;
    public int MultiLvl2Cost;

    [Header("Combo Cost")]
    public TextMeshPro Combo_txt;
    public int ComboCost;



    private void Start()
    {

        SpeedLvl1_txt.text = "" + SpeedLvl1Cost;
        SpeedLvl2_txt.text = "" + SpeedLvl2Cost;
        SpeedLvl3_txt.text = "" + SpeedLvl3Cost;
        JumpLvl1_txt.text = "" + JumpLvl1Cost;
        JumpLvl2_txt.text = "" + JumpLvl2Cost;
        SuperJump_txt.text = "" + SuperJumpCost;

        HeartLvl1_txt.text = "" + HeartLvl1Cost;
        HeartLvl2_txt.text = "" + HeartLvl2Cost;
        HeartLvl3_txt.text = "" + HeartLvl3Cost;
        MagnetLvl1_txt.text = "" + MagnetLvl1Cost;
        MagnetLvl2_txt.text = "" + MagnetLvl2Cost;
        ShieldSphere_txt.text = "" + ShieldSphereCost;

        PunchLvl1_txt.text = "" + PunchLvl1Cost;
        PunchLvl2_txt.text = "" + PunchLvl2Cost;
        PunchLvl3_txt.text = "" + PunchLvl3Cost;
        MultiLvl1_txt.text = "" + MultiLvl1Cost;
        MultiLvl2_txt.text = "" + MultiLvl2Cost;
        Combo_txt.text = "" + ComboCost;


        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstButton);
    }

    private void Update()
    {
        //set text total bubbles
        TotalBubbles.text = "" +  DataManager.Instance.playerData.totalCoins;

        //speed skills set checks and locks
        if (DataManager.Instance.playerData.SpeedLvl1 == 2)
        {
            Speedlvl1_check.SetActive(true);
            Speedlvl2_inactive.SetActive(false);
            Jumplvl1_inactive.SetActive(false);
        }
        if (DataManager.Instance.playerData.SpeedLvl2 == 2)
        {
            Speedlvl2_check.SetActive(true);
            Speedlvl3_inactive.SetActive(false);
        }
        if (DataManager.Instance.playerData.SpeedLvl3 == 2)
        {
            Speedlvl3_check.SetActive(true);
            if (DataManager.Instance.playerData.SpeedLvl3 == 2 && DataManager.Instance.playerData.JumpLvl2 == 2)
            {
                SuperJump_inactive.SetActive(false);
            }
        }   
        if (DataManager.Instance.playerData.JumpLvl1 == 2)
        {
            Jumplvl1_check.SetActive(true);
            Jumplvl2_inactive.SetActive(false);
        }
        if (DataManager.Instance.playerData.JumpLvl2 == 2)
        {
            Jumplvl2_check.SetActive(true);
            if (DataManager.Instance.playerData.SpeedLvl3 == 2 && DataManager.Instance.playerData.JumpLvl2 == 2)
            {
                SuperJump_inactive.SetActive(false);
            }
        }
        if (DataManager.Instance.playerData.SuperJumplvl1 == 2)
        {
            SuperJump_check.SetActive(true);
        }

        //defense skills set checks and locks
        if (DataManager.Instance.playerData.HealthLvl1 == 2)
        {
            Heartlvl1_check.SetActive(true);
            Heartlvl2_inactive.SetActive(false);
            Magnetlvl1_inactive.SetActive(false);
        }
        if (DataManager.Instance.playerData.HealthLvl2 == 2)
        {
            Heartlvl2_check.SetActive(true);
            Heartlvl3_inactive.SetActive(false);
        }
        if (DataManager.Instance.playerData.HealthLvl3 == 2)
        {
            Heartlvl3_check.SetActive(true);
            if (DataManager.Instance.playerData.HealthLvl3 == 2 && DataManager.Instance.playerData.MagnetLvl2 == 2)
            {
                ShieldSphere_inactive.SetActive(false);
            }
        }
        if (DataManager.Instance.playerData.MagnetLvl1 == 2)
        {
            Magnetlvl1_check.SetActive(true);
            Magnetlvl2_inactive.SetActive(false);
        }
        if (DataManager.Instance.playerData.MagnetLvl2 == 2)
        {
            Magnetlvl2_check.SetActive(true);
            if (DataManager.Instance.playerData.HealthLvl3 == 2 && DataManager.Instance.playerData.MagnetLvl2 == 2)
            {
                ShieldSphere_inactive.SetActive(false);
            }
        }
        if (DataManager.Instance.playerData.ShieldSphereLvl1 == 2)
        {
            ShieldSphere_check.SetActive(true);

        }

        //damage skills set checks and locks
        if (DataManager.Instance.playerData.PunchLvl1 == 2)
        {
            Punchlvl1_check.SetActive(true);
            Punchlvl2_inactive.SetActive(false);
            Multi1_inactive.SetActive(false);
        }
        if (DataManager.Instance.playerData.PunchLvl2 == 2)
        {
            Punchlvl2_check.SetActive(true);
            Punchlvl3_inactive.SetActive(false);
        }
        if (DataManager.Instance.playerData.PunchLvl3 == 2)
        {
            Punchlvl3_check.SetActive(true);
            if (DataManager.Instance.playerData.PunchLvl3 == 2 && DataManager.Instance.playerData.MultiLvl2 == 2)
            {
                PunchCombo_inactive.SetActive(false);
            }
        }
        if (DataManager.Instance.playerData.MultiLvl1 == 2)
        {
            Multi1_check.SetActive(true);
            Multil2_inactive.SetActive(false);
        }
        if (DataManager.Instance.playerData.MultiLvl2 == 2)
        {
            Multil2_check.SetActive(true);
            if (DataManager.Instance.playerData.PunchLvl3 == 2 && DataManager.Instance.playerData.MultiLvl2 == 2)
            {
                PunchCombo_inactive.SetActive(false);
            }
                
        }
        if (DataManager.Instance.playerData.ComboLvl1 == 2)
        {
            PunchCombo_check.SetActive(true);
        }
    }

    public void BuySpeedLvl1()
    {
        if ( DataManager.Instance.playerData.totalCoins >= SpeedLvl1Cost && DataManager.Instance.playerData.SpeedLvl1 < 2)
        {
             DataManager.Instance.playerData.totalCoins -= SpeedLvl1Cost;
            DataManager.Instance.playerData.SpeedLvl1 = 2;
            DataManager.Instance.playerData.SpeedLvl2 = 1;
            DataManager.Instance.playerData.JumpLvl1 = 1;
             DataManager.Instance.playerData.speedSkill = 1.25f;
            Instantiate(BuyEffect, Speedlvl1_check.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("SpeedLvl1", 2);
            PlayerPrefs.SetInt("JumpLvl1", 1);
            PlayerPrefs.SetInt("SpeedLvl2", 1);
        }
        else
        {
            NoMoney();
        }
    }

    public void BuySpeedLvl2()
    {
        if ( DataManager.Instance.playerData.totalCoins >= SpeedLvl2Cost && DataManager.Instance.playerData.SpeedLvl1 == 2 && DataManager.Instance.playerData.SpeedLvl2 < 2)
        {
             DataManager.Instance.playerData.speedSkill = 1.5f;
             DataManager.Instance.playerData.totalCoins -= SpeedLvl2Cost;
            DataManager.Instance.playerData.SpeedLvl2 = 2;
            DataManager.Instance.playerData.SpeedLvl3 = 1;
            Instantiate(BuyEffect, Speedlvl2_check.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("SpeedLvl2", 2);
            PlayerPrefs.SetInt("SpeedLvl3", 1);
        }
        else
        {
            NoMoney();
        }
    }

    public void BuySpeedLvl3()
    {
        if ( DataManager.Instance.playerData.totalCoins >= SpeedLvl3Cost && DataManager.Instance.playerData.SpeedLvl2 == 2 && DataManager.Instance.playerData.SpeedLvl3 < 2)
        {
             DataManager.Instance.playerData.totalCoins -= SpeedLvl3Cost;
            DataManager.Instance.playerData.SpeedLvl3 = 2;
            Instantiate(BuyEffect, Speedlvl3_check.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("SpeedLvl3", 2);
            PlayerPrefs.SetInt("SuperJumplvl1", 1);

            if (DataManager.Instance.playerData.SuperJumplvl1 <1)
            {
                DataManager.Instance.playerData.SuperJumplvl1 = 1;
            }         

        }
        {
            NoMoney();
        }
    }
    public void BuyJumpvl1()
    {
        if ( DataManager.Instance.playerData.totalCoins >= JumpLvl1Cost && DataManager.Instance.playerData.SpeedLvl1 == 2 && DataManager.Instance.playerData.JumpLvl1 < 2)
        {
            DataManager.Instance.playerData.totalCoins -= JumpLvl1Cost;
            DataManager.Instance.playerData.JumpLvl1 = 2;
            DataManager.Instance.playerData.jumpSkill += 2f;
            Instantiate(BuyEffect, Jumplvl1_check.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("JumpLvl1", 2);
            PlayerPrefs.SetInt("JumpLvl2", 1);
        }
        else
        {
            NoMoney();
        }
    }

    public void BuyJumplvl2()
    {
        if ( DataManager.Instance.playerData.totalCoins >= JumpLvl2Cost && DataManager.Instance.playerData.JumpLvl1 == 2 && DataManager.Instance.playerData.JumpLvl2 < 2)
        {
            DataManager.Instance.playerData.totalCoins -= JumpLvl2Cost;
            DataManager.Instance.playerData.JumpLvl2 = 2;
            DataManager.Instance.playerData.jumpSkill += 4f;
            Instantiate(BuyEffect, Jumplvl2_check.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("JumpLvl2", 2);
            PlayerPrefs.SetInt("SuperJumplvl1", 1);

            if (DataManager.Instance.playerData.SuperJumplvl1 < 1)
            {
                DataManager.Instance.playerData.SuperJumplvl1 = 1;
            }
        }
        else
        {
            NoMoney();
        }

    }

    public void BuySuperJump()
    {
        if ( DataManager.Instance.playerData.totalCoins >= SuperJumpCost && DataManager.Instance.playerData.SuperJumplvl1 < 2 && 
            (DataManager.Instance.playerData.SpeedLvl3 == 2 || DataManager.Instance.playerData.JumpLvl2 == 2))
        {
            DataManager.Instance.playerData.totalCoins -= SuperJumpCost;
            DataManager.Instance.playerData.SuperJumplvl1 = 2;
            DataManager.Instance.playerData.superJump = 1;
            Instantiate(BuyEffect, SuperJump_check.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("SuperJumplvl1", 2);
            PlayerPrefs.SetInt("superJump", 1);
        }
        else
        {
            NoMoney();
        }

    }



    public void BuyHeartLvl1()
    {
        if ( DataManager.Instance.playerData.totalCoins >= HeartLvl1Cost && DataManager.Instance.playerData.HealthLvl1 < 2)
        {
             DataManager.Instance.playerData.totalCoins -= HeartLvl1Cost;
            DataManager.Instance.playerData.HealthLvl1 = 2;
             DataManager.Instance.playerData.numOfHearts += 1;
            Instantiate(BuyEffect, Heartlvl1_check.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("HealthLvl1", 2);
            PlayerPrefs.SetInt("HealthLvl2", 1);
            PlayerPrefs.SetInt("MagnetLvl1", 1);

            if (DataManager.Instance.playerData.HealthLvl2 < 1)
            {
                DataManager.Instance.playerData.HealthLvl2 = 1;
            }
        }
        else
        {
            Debug.Log("no money");
            NoMoney();
        }

    }

    public void BuyHeartLvl2()
    {
        if ( DataManager.Instance.playerData.totalCoins >= HeartLvl2Cost && DataManager.Instance.playerData.HealthLvl1 == 2 && DataManager.Instance.playerData.HealthLvl2 < 2)
        {
            DataManager.Instance.playerData.totalCoins -= HeartLvl2Cost;
            DataManager.Instance.playerData.HealthLvl2 = 2;
            DataManager.Instance.playerData.numOfHearts += 1;
            Instantiate(BuyEffect, Heartlvl2_check.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("HealthLvl2", 2);
            PlayerPrefs.SetInt("HealthLvl3", 1);

            if (DataManager.Instance.playerData.HealthLvl3 < 1)
            {
                DataManager.Instance.playerData.HealthLvl3 = 1;
            }
        }
        else
        {
            NoMoney();
        }

    }

    public void BuyHeartLvl3()
    {
        if ( DataManager.Instance.playerData.totalCoins >= HeartLvl3Cost && DataManager.Instance.playerData.HealthLvl2 == 2 && DataManager.Instance.playerData.HealthLvl3 < 2)
        {
            DataManager.Instance.playerData.totalCoins -= HeartLvl3Cost;
            DataManager.Instance.playerData.HealthLvl3 = 2;
            DataManager.Instance.playerData.numOfHearts += 1;
            Instantiate(BuyEffect, Heartlvl3_check.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("HealthLvl3", 2);
            PlayerPrefs.SetInt("ShieldSphereLvl1", 1);

            if (DataManager.Instance.playerData.ShieldSphereLvl1 < 1)
            {
                DataManager.Instance.playerData.ShieldSphereLvl1 = 1;
            }
        }
        else
        {
            NoMoney();
        }

    }

    public void BuyMagnetLvl1()
    {
        if ( DataManager.Instance.playerData.totalCoins >= MagnetLvl1Cost && DataManager.Instance.playerData.HealthLvl1 == 2 && DataManager.Instance.playerData.MagnetLvl1 < 2)
        {
             DataManager.Instance.playerData.totalCoins -= MagnetLvl1Cost;
            DataManager.Instance.playerData.MagnetLvl1 = 2;
            DataManager.Instance.playerData.magnetRange = 4;
            Instantiate(BuyEffect, Magnetlvl1_check.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("MagnetLvl1", 2);
            PlayerPrefs.SetInt("MagnetLvl2", 1);

            if (DataManager.Instance.playerData.MagnetLvl2 < 1)
            {
                DataManager.Instance.playerData.MagnetLvl2 = 1;
            }
        }
        else
        {
            NoMoney();
        }

    }

    public void BuyMagnetLvl2()
    {
        if ( DataManager.Instance.playerData.totalCoins >= MagnetLvl2Cost && DataManager.Instance.playerData.MagnetLvl1 == 2 && DataManager.Instance.playerData.MagnetLvl2 < 2)
        {
            DataManager.Instance.playerData.totalCoins -= MagnetLvl2Cost;
            DataManager.Instance.playerData.MagnetLvl2 = 2;
            Instantiate(BuyEffect, Magnetlvl2_check.transform.position, Quaternion.identity);
            DataManager.Instance.playerData.magnetRange = 6;
            PlayerPrefs.SetInt("MagnetLvl2", 2);
            PlayerPrefs.SetInt("ShieldSphereLvl1", 1);

            if (DataManager.Instance.playerData.ShieldSphereLvl1 < 1)
            {
                DataManager.Instance.playerData.ShieldSphereLvl1 = 1;
            }
        }
        else
        {
            NoMoney();
        }

    }


    public void BuyShieldSphere()
    {
        if ( DataManager.Instance.playerData.totalCoins >= ShieldSphereCost && (DataManager.Instance.playerData.HealthLvl3 == 2 || DataManager.Instance.playerData.MagnetLvl2 == 2))
        {
            DataManager.Instance.playerData.totalCoins -= ShieldSphereCost;
            DataManager.Instance.playerData.ShieldSphereLvl1 = 2;
            DataManager.Instance.playerData.shieldSphere = 1;
            Instantiate(BuyEffect, ShieldSphere_check.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("ShieldSphereLvl1", 2);

        }
        else
        {
            NoMoney();
        }

    }

    public void BuyPunchLvl1()
    {
        if ( DataManager.Instance.playerData.totalCoins >= PunchLvl1Cost && DataManager.Instance.playerData.PunchLvl2 < 2)
        {
             DataManager.Instance.playerData.totalCoins -= PunchLvl1Cost;
            DataManager.Instance.playerData.PunchLvl1 = 2;
            Instantiate(BuyEffect, Punchlvl1_check.transform.position, Quaternion.identity);
             DataManager.Instance.playerData.damageSkill =  DataManager.Instance.playerData.damageSkill + 2;
            PlayerPrefs.SetInt("PunchLvl1", 2);
            PlayerPrefs.SetInt("PunchLvl2", 1);

            if (DataManager.Instance.playerData.PunchLvl2 < 1)
            {
                DataManager.Instance.playerData.PunchLvl2 = 1;
            }
        }
        else
        {
            NoMoney();
        }

    }

    public void BuyPunchLvl2()
    {
        if ( DataManager.Instance.playerData.totalCoins >= PunchLvl2Cost && DataManager.Instance.playerData.PunchLvl1 == 2 && DataManager.Instance.playerData.PunchLvl2 < 2)
        {
             DataManager.Instance.playerData.totalCoins -= PunchLvl2Cost;
            DataManager.Instance.playerData.PunchLvl2 = 2;
            Instantiate(BuyEffect, Punchlvl2_check.transform.position, Quaternion.identity);
             DataManager.Instance.playerData.damageSkill =  DataManager.Instance.playerData.damageSkill + 2;
            PlayerPrefs.SetInt("PunchLvl2", 2);
            PlayerPrefs.SetInt("PunchLvl3", 1);

            if (DataManager.Instance.playerData.PunchLvl3 < 1)
            {
                DataManager.Instance.playerData.PunchLvl3 = 1;
            }
        }
        else
        {
            NoMoney();
        }

    }

    public void BuyPunchLvl3()
    {
        if ( DataManager.Instance.playerData.totalCoins >= PunchLvl3Cost && DataManager.Instance.playerData.PunchLvl2 == 2 && DataManager.Instance.playerData.PunchLvl3 < 2)
        {
             DataManager.Instance.playerData.totalCoins -= PunchLvl3Cost;
            DataManager.Instance.playerData.PunchLvl3 = 2;
             DataManager.Instance.playerData.damageSkill = +3;
            Instantiate(BuyEffect, Punchlvl3_check.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("PunchLvl3", 2);
            PlayerPrefs.SetInt("ComboLvl1", 1);

            if (DataManager.Instance.playerData.ComboLvl1 < 1)
            {
                DataManager.Instance.playerData.ComboLvl1 = 1;
            }
        }
        else
        {
            NoMoney();
        }

    }


    public void BuyMultiLvl1()
    {
        if ( DataManager.Instance.playerData.totalCoins >= MultiLvl1Cost && DataManager.Instance.playerData.PunchLvl1 == 2 && DataManager.Instance.playerData.MultiLvl1 < 2)
        {
            DataManager.Instance.playerData.totalCoins -= MultiLvl1Cost;
            DataManager.Instance.playerData.MultiLvl1 = 2;
            DataManager.Instance.playerData.multishots = 1;
            Instantiate(BuyEffect, Multi1_check.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("MultiLvl1", 2);
            PlayerPrefs.SetInt("MultiLvl2", 1);

            if (DataManager.Instance.playerData.PunchLvl3 < 1)
            {
                DataManager.Instance.playerData.PunchLvl3 = 1;
            }
        }
        else
        {
            NoMoney();
        }

    }

    public void BuyMultiLvl2()
    {
        if ( DataManager.Instance.playerData.totalCoins >= MultiLvl2Cost && DataManager.Instance.playerData.MultiLvl1 == 2 && DataManager.Instance.playerData.MultiLvl2 < 2)
        {
            DataManager.Instance.playerData.totalCoins -= MultiLvl2Cost;
            DataManager.Instance.playerData.MultiLvl2 = 2;
            DataManager.Instance.playerData.multishots = 2;
            Instantiate(BuyEffect, Multil2_check.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("MultiLvl2", 2);
            PlayerPrefs.SetInt("ComboLvl1", 1);

            if (DataManager.Instance.playerData.ComboLvl1 < 1)
            {
                DataManager.Instance.playerData.ComboLvl1 = 1;
            }
        }
        else
        {
            NoMoney();
        }

    }

    public void BuyPunchCombo()
    {
        if ( DataManager.Instance.playerData.totalCoins >= ComboCost && DataManager.Instance.playerData.ComboLvl1 < 2 && 
            (DataManager.Instance.playerData.PunchLvl3 == 2 || DataManager.Instance.playerData.MultiLvl2 == 2))
        {
            DataManager.Instance.playerData.totalCoins -= ComboCost;
            DataManager.Instance.playerData.ComboLvl1 = 2;
            DataManager.Instance.playerData.punchCombo = 1;
            Instantiate(BuyEffect, PunchCombo_check.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("ComboLvl1", 2);
        }
        else
        {
            NoMoney();
        }

    }

    public void NoMoney()
    {
        Instantiate(NoMoneyPopup, new Vector2(0, 0), transform.rotation);
    }

}
