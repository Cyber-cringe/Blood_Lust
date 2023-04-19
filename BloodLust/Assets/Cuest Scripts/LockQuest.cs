using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockQuest : Quests
{
    [SerializeField] Image[] lamps = new Image[5];
    [SerializeField] GameObject[] grooves = new GameObject[5];
    private bool[] IsActive = new bool[5];
    private bool StopCor;
    //[SerializeField] Locks[] Passed = new Locks [4];
    //public byte PassedLockInd;
    [SerializeField] MainCharacter character;
    private List<string> PassedID = new List<string>(10);

    Color on = new Color(100 / 255f, 240 / 255f, 75 / 255f, 175 / 255f);
    Color off = new Color(220 / 255f, 220 / 255f, 220 / 255f, 175 / 255f);
    int ind;

    public void AddPassedID(string id)
    {
        PassedID.Add(id);
    }

    public bool CheckedPassedID(string id)
    {
        return PassedID.Contains(id);
    }

    void Start()
    {
        for (int i = 0; i < IsActive.GetLength(0); i++)
        {
            IsActive[i] = false;
        }
        ind = -1;
        AplyButton.onClick.AddListener(() => { ApplyButton_Click(); });
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T) && ind != -1 && !IsActive[ind])
        {
            grooves[ind].GetComponent<Transform>().position -= new Vector3(0, 1f, 0);
            IsActive[ind] = true;
            return;
        }
        if (Input.GetKeyUp(KeyCode.T) && ind != -1 && IsActive[ind])
        {
            grooves[ind].GetComponent<Transform>().position += new Vector3(0, 1f, 0);
            IsActive[ind] = false;
            return;
        }
        if (IsActive[0]&& IsActive[1]&& IsActive[2] && IsActive[3] && IsActive[4])
        {
            StopCor = true;
            ind= -1;
            return;
        }
        Debug.Log(ind.ToString());
    }


    IEnumerator RandLamp()
    {
        if (StopCor)
            yield break;

        int RandInd = UnityEngine.Random.Range(0, 5);
        float RandTime = UnityEngine.Random.Range(4, 8) / 10f;
        ind = RandInd;
        lamps[RandInd].color = on;
        yield return new WaitForSeconds(RandTime);
        lamps[RandInd].color = off;
        ind = -1;

        yield return new WaitForSeconds(RandTime);
        StartCoroutine(RandLamp());

    }


    public void StartWork()
    {
        for (int i = 0; i < IsActive.GetLength(0); i++)
        {
            if (IsActive[i])
            grooves[i].GetComponent<Transform>().position += new Vector3(0, 1f, 0);

            IsActive[i] = false;
            lamps[i].color = off;
        }

        StopCor = false;
        StartCoroutine(RandLamp());
    }

    public void StopWork()
    {
        StopCoroutine(RandLamp());
        StopCor = true;
    }


    private void ApplyButton_Click()
    {
        bool EverythingIsActive = true;
        for (int i = 0; i < IsActive.GetLength(0); i++)
        {
            if (!IsActive[i])
            {
                StartCoroutine(ReturnColor(AplyButton));
                return;
            }    
        }
        
        AddPassedID(Locks.MainActiveID);
        LowerPanelMessage = character.RandReward();
        Quest.SetActive(false);
        Movement.CanShoot = true;
        Movement.CanMove = true;
        interf.ShowPanel(LowerPanelMessage);

    }
}

