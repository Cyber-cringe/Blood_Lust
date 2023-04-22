using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pyatnashki : Quests
{
    [SerializeField] Button[] cells = new Button[16];
    [SerializeField] Text[] numbers = new Text[16];

    private void SwapCells<T>(ref T a, ref T b)
    {
        T temp;
        temp = a;
        a = b;
        b = temp;
    }

    private bool CheckCell(int ind, int shift) //перемещение клеточек
    {
        if (((ind + shift) % 4 == 3 && shift == -1) || ((ind + shift) % 4 == 0 && shift == 1))
            return false;
        try
        {
            if (numbers[ind + shift].text == "")
            {
                Vector3 pos = cells[ind].GetComponent<RectTransform>().position;
                cells[ind].GetComponent<RectTransform>().position = cells[ind + shift].GetComponent<RectTransform>().position;
                cells[ind + shift].GetComponent<RectTransform>().position = pos;
                SwapCells(ref cells[ind], ref cells[ind + shift]);
                SwapCells(ref numbers[ind], ref numbers[ind + shift]);
                cells[ind + shift].onClick.RemoveAllListeners();
                cells[ind + shift].onClick.AddListener(() => { move(ind + shift); });
                return true;
            }
        }
        catch (IndexOutOfRangeException) { return false; }

        return false;

    }

    public bool move(int ind, bool ChangeCokor = true)
    {
        if (ind > cells.GetLength(0) || ind < 0) return false;
        if (CheckCell(ind, 1)) return true;
        if (CheckCell(ind, 4)) return true;
        if (CheckCell(ind, -1)) return true;
        if (CheckCell(ind, -4)) return true;

        if (ChangeCokor) StartCoroutine(ReturnColor(cells[ind]));
        return false;
    }

    private void ApplyButton_Click()
    {
        if (numbers[numbers.GetLength(0) - 1].text != "")
        {
            StartCoroutine(ReturnColor(AplyButton));
            return;
        }

        for (int i = 1; i < numbers.GetLength(0) - 1; i++)
        {
            if (Convert.ToInt32(numbers[i].text) < Convert.ToInt32(numbers[i - 1].text))
            {
                StartCoroutine(ReturnColor(AplyButton));
                return;
            }
        }

        Quest.SetActive(false);
        WeaphonScript.totalWeaphons += 1;
        Movement.CanShoot = true;
        Movement.CanMove = true;
        GetItem.SetActive(true);
        interf.ShowPanel(LowerPanelMessage);
    }

    void Start()
    {
        for (int i = 0; i < numbers.GetLength(0) - 1; i++)
        {
            numbers[i].text = (i + 1).ToString();
        }
        numbers[numbers.GetLength(0) - 1].text = "";

        //привязка методов к кнопкам
        {
            cells[0].onClick.AddListener(() => { move(0); });
            cells[1].onClick.AddListener(() => { move(1); });
            cells[2].onClick.AddListener(() => { move(2); });
            cells[3].onClick.AddListener(() => { move(3); });
            cells[4].onClick.AddListener(() => { move(4); });
            cells[5].onClick.AddListener(() => { move(5); });
            cells[6].onClick.AddListener(() => { move(6); });
            cells[7].onClick.AddListener(() => { move(7); });
            cells[8].onClick.AddListener(() => { move(8); });
            cells[9].onClick.AddListener(() => { move(9); });
            cells[10].onClick.AddListener(() => { move(10); });
            cells[11].onClick.AddListener(() => { move(11); });
            cells[12].onClick.AddListener(() => { move(12); });
            cells[13].onClick.AddListener(() => { move(13); });
            cells[14].onClick.AddListener(() => { move(14); });
            AplyButton.onClick.AddListener(() => { ApplyButton_Click(); });
        }
        
        int CellInd;
        int VoidCellInd = 15;

        for (int i = 0; i < UnityEngine.Random.Range(75, 100);)
        {
            CellInd = UnityEngine.Random.Range(0, 15);
            if ((Mathf.Abs(VoidCellInd - CellInd) == 4 || Mathf.Abs(VoidCellInd - CellInd) == 1) && numbers[CellInd].text != "" && move(CellInd, false))
            {
                VoidCellInd = CellInd;
                i++;
            }

        }

    }
}
