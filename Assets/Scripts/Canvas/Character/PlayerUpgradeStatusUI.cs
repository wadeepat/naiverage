using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgradeStatusUI : MonoBehaviour
{
    [SerializeField] private GameObject Status;
    [SerializeField] private GameObject UpgradeStatus;
    [SerializeField] private Text[] statusText;
    [SerializeField] private Text[] upgradeStatusText;
    [SerializeField] private Text pearlsText;
    private int[] status;
    private int[] upgradeStatus;
    private int pearls;
    private int cost = 500;
    // Start is called before the first frame update
    void Start()
    {
        pearls = 0;
        // GetStatus();
        // GetUpgradeStatus();
        Status.SetActive(true);
        UpgradeStatus.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        GetStatus();
        if (Input.GetKeyDown("i"))
        {
            Status.SetActive(true);
            UpgradeStatus.SetActive(false);
        }
        if (UpgradeStatus.activeSelf)
        {
            pearlsText.text = "" + pearls;
        }

    }
    public void StatusButton()
    {
        GetStatus();
        Status.SetActive(true);
        UpgradeStatus.SetActive(false);
    }

    public void UpgradeStatusButton()
    {
        upgradeStatus = PlayerStatus.callStatus();
        GetUpgradeStatus();
        pearls = 0;
        Status.SetActive(false);
        UpgradeStatus.SetActive(true);
    }


    public void GetStatus()
    {
        status = PlayerStatus.callStatus();
        for (int i = 0; i < status.Length - 3; i++)
        {
            switch (i)
            {
                case 0:
                    statusText[i].text = "" + status[i + 1] + " / " + status[i];
                    break;
                case 1:
                    statusText[i].text = "" + status[i + 2] + " / " + status[i + 1];
                    break;
                case 3:
                    statusText[i].text = "" + status[i + 3] + " %";
                    break;
                case 4:
                    statusText[i].text = "" + status[i + 3] + " %";
                    break;
                default:
                    statusText[i].text = "" + status[i + 3];
                    break;
            }
        }
    }

    public void GetUpgradeStatus()
    {
        for (int i = 0; i < status.Length - 2; i++)
        {
            switch (i)
            {
                case 0:
                    upgradeStatusText[i].text = "" + upgradeStatus[i];
                    upgradeStatusText[i].color = upgradeStatus[i] == status[i] ? new Color(201 / 255f, 165 / 255f, 157 / 255f, 1) : Color.green;
                    break;
                case 1:
                    upgradeStatusText[i].text = "" + upgradeStatus[i + 1];
                    upgradeStatusText[i].color = upgradeStatus[i + 1] == status[i + 1] ? new Color(201 / 255f, 165 / 255f, 157 / 255f, 1) : Color.green;
                    break;
                case 2:
                    upgradeStatusText[i].text = "" + upgradeStatus[i + 2] + " / s";
                    upgradeStatusText[i].color = upgradeStatus[i + 2] == status[i + 2] ? new Color(201 / 255f, 165 / 255f, 157 / 255f, 1) : Color.green;
                    break;
                case 4:
                    upgradeStatusText[i].text = "" + upgradeStatus[i + 2] + " %";
                    upgradeStatusText[i].color = upgradeStatus[i + 2] == status[i + 2] ? new Color(201 / 255f, 165 / 255f, 157 / 255f, 1) : Color.green;
                    break;
                case 5:
                    upgradeStatusText[i].text = "" + upgradeStatus[i + 2] + " %";
                    upgradeStatusText[i].color = upgradeStatus[i + 2] == status[i + 2] ? new Color(201 / 255f, 165 / 255f, 157 / 255f, 1) : Color.green;
                    break;
                default:
                    upgradeStatusText[i].text = "" + upgradeStatus[i + 2];
                    upgradeStatusText[i].color = upgradeStatus[i + 2] == status[i + 2] ? new Color(201 / 255f, 165 / 255f, 157 / 255f, 1) : Color.green;
                    break;
            }
        }
    }

    public void PlusButton(int index)
    {
        if (pearls + cost > MagicPearls.CheckPearl()) return;
        switch (index)
        {
            case 0:
                if (upgradeStatus[0] < 500)
                {
                    upgradeStatus[0] += 50;
                    pearls += cost;
                }
                break;
            case 1:
                if (upgradeStatus[2] < 500)
                {
                    upgradeStatus[2] += 50;
                    pearls += cost;
                }
                break;
            case 2:
                if (upgradeStatus[4] < 10)
                {
                    upgradeStatus[4] += 2;
                    pearls += cost;
                }
                break;
            case 3:
                if (upgradeStatus[5] < cost)
                {
                    upgradeStatus[5] += 20;
                    pearls += cost;
                }
                break;
            case 4:
                if (upgradeStatus[6] < 100)
                {
                    upgradeStatus[6] += 10;
                    pearls += cost;
                }
                break;
            case 5:
                if (upgradeStatus[7] < 60)
                {
                    upgradeStatus[7] += 20;
                    pearls += cost;
                }
                break;
            case 6:
                if (upgradeStatus[8] < 100)
                {
                    upgradeStatus[8] += 10;
                    pearls += cost;
                }
                break;
            case 7:
                if (upgradeStatus[9] < 100)
                {
                    upgradeStatus[9] += 10;
                    pearls += cost;
                }
                break;
        }
        GetUpgradeStatus();
    }

    public void MinusButton(int index)
    {
        
        switch (index)
        {
            case 0:
                if (upgradeStatus[0] > status[0])
                {
                    upgradeStatus[0] -= 50;
                    pearls -= cost;
                }
                break;
            case 1:
                if (upgradeStatus[2] > status[2])
                {
                    upgradeStatus[2] -= 50;
                    pearls -= cost;
                }
                break;
            case 2:
                if (upgradeStatus[4] > status[4])
                {
                    upgradeStatus[4] -= 2;
                    pearls -= cost;
                }
                break;
            case 3:
                if (upgradeStatus[5] > status[5])
                {
                    upgradeStatus[5] -= 20;
                    pearls -= cost;
                }
                break;
            case 4:
                if (upgradeStatus[6] > status[6])
                {
                    upgradeStatus[6] -= 10;
                    pearls -= cost;
                }
                break;
            case 5:
                if (upgradeStatus[7] > status[7])
                {
                    upgradeStatus[7] -= 20;
                    pearls -= cost;
                }
                break;
            case 6:
                if (upgradeStatus[8] > status[8])
                {
                    upgradeStatus[8] -= 10;
                    pearls -= cost;
                }
                break;
            case 7:
                if (upgradeStatus[9] > status[9])
                {
                    upgradeStatus[9] -= 10;
                    pearls -= cost;
                }
                break;
        }
        GetUpgradeStatus();

    }
    public void UpgradeButton()
    {
        if (MagicPearls.CheckPearl() >= pearls)
        {
            for (int i = 0; i < upgradeStatus.Length; i++)
            {
                PlayerStatus.upgradeStatus(i, upgradeStatus[i]);
            }
            status = PlayerStatus.callStatus();
            GetUpgradeStatus();
            MagicPearls.UsePearl(pearls);
            pearls = 0;

        }
        else
        {
            Debug.Log("Can not upgrade status");
        }
    }


}
