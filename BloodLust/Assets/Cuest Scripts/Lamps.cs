using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lamps : MonoBehaviour
{
    [SerializeField] GameObject Quest;
    [SerializeField] GameObject GetItem;
    [SerializeField] Button AplyButton;
    [SerializeField] Button ResetButton;
    [SerializeField] string LowerPanelMessage = "Найден прудмет: пистолет";
    [SerializeField] Button[] lamps = new Button[5];
    private bool[] IsActive = new bool[5];


    // Start is called before the first frame update
    void Start()
    {
        ResetButton_Click();
        lamps[0].onClick.AddListener(() => { Lamp1_Click(); });
        lamps[1].onClick.AddListener(() => { Lamp2_Click(); });
        lamps[2].onClick.AddListener(() => { Lamp3_Click(); });
        lamps[3].onClick.AddListener(() => { Lamp4_Click(); });
        lamps[4].onClick.AddListener(() => { Lamp5_Click(); });
        AplyButton.onClick.AddListener(() => { ApplyButton_Click(); });
        ResetButton.onClick.AddListener(() => { ResetButton_Click(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeState(params int[] ind)
    {
        for (int i=0; i<ind.GetLength(0); i++)
        {
            if (IsActive[ind[i]]!=null && IsActive[ind[i]]==false)
            {
                IsActive[ind[i]] = true;
                lamps[ind[i]].GetComponent<Image>().color = new Color(230 / 255f, 240 / 255f, 75 / 255f, 175 / 255f);
            }
            else if (IsActive[ind[i]] != null && IsActive[ind[i]] == true)
            {
                IsActive[ind[i]] = false;
                lamps[ind[i]].GetComponent<Image>().color = new Color(220 / 255f, 220 / 255f, 220 / 255f, 175 / 255f);
            }
        }
    }


    public void Lamp1_Click()
    {
        ChangeState(1, 3, 4);
    }

    public void Lamp2_Click()
    {
        ChangeState(1, 4);
    }

    public void Lamp3_Click()
    {
        ChangeState(2);
    }

    public void Lamp4_Click()
    {
        ChangeState(3);
    }

    public void Lamp5_Click()
    {
        ChangeState(0, 1, 4);
    }


    IEnumerator ReturnColor()
    {
        yield return new WaitForSeconds(0.5f);
        AplyButton.GetComponent<Image>().color = new Color(90 / 255f, 90 / 255f, 90 / 255f);
    }

    public void ApplyButton_Click()
    {
        if (IsActive[0] && IsActive[1] && IsActive[2] && IsActive[3] && IsActive[4])
        {
            Quest.SetActive(false);
            Movement.CanShoot = true;
            Movement.CanMove = true;
            GetItem.SetActive(true);
            Interface.MessageText = LowerPanelMessage;
            Interface.ShowPanel = true;
        }
        else
        {
            AplyButton.GetComponent<Image>().color = new Color(1, 0, 0);
            StartCoroutine(ReturnColor());
        }
    }


    public void ResetButton_Click()
    {
        for (int i = 0; i < lamps.GetLength(0); i++)
        {
            lamps[i].GetComponent<Image>().color = new Color(220 / 255f, 220 / 255f, 220 / 255f, 175 / 255f);
            IsActive[i] = false;
        }
    }
}
