using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pyatnashki : MonoBehaviour
{
    [SerializeField] Button[] cells = new Button[16];
    [SerializeField] Text[] numbers = new Text[16];
    [SerializeField] GameObject Quest;
    [SerializeField] Button AplyButton;
    [SerializeField] GameObject GetItem;
    [SerializeField] string LowerPanelMessage = "Найден прудмет: дробовик";
    // Start is called before the first frame update
    void Start()
    {
        bool IsHere;
        for (int i = 0; i < numbers.GetLength(0) - 1;)
        {
            int RandomNumber = UnityEngine.Random.Range(1, 16);
            IsHere = false;
            for (int j = 0; j < i; j++)
            {
                if (Convert.ToInt32(numbers[j].text) == RandomNumber)
                {
                    IsHere= true;
                    break;
                }
            }

            if (!IsHere)
            {
                numbers[i].text = RandomNumber.ToString();
                i++;
            }
                
        }

        numbers[numbers.GetLength(0) - 1].text = "";

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

    private void SwapCells<T>(ref T a, ref T b)
    {
        T temp;
        temp = a;
        a = b;
        b = temp;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z) && Input.GetKeyUp(KeyCode.X) && Quest.activeSelf)
        {
            for (int i = 0; i < numbers.GetLength(0) - 1; i++)
            {
                numbers[i].text = (i+1).ToString();
            }
        }
    }

    private bool CheckCell(int ind, int shift)
    {
        if (((ind + shift) % 4 == 3 && shift == -1) || ((ind + shift) % 4 == 0 && shift == 1))
            return false;

        if ((ind + shift) < cells.GetLength(0) && (ind + shift) >= 0 && numbers[ind + shift].text == "")
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

        return false;
    }

    IEnumerator ReturnColor(Button cell)
    {
        cell.GetComponent<Image>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.5f);
        cell.GetComponent<Image>().color = new Color(90 / 255f, 90 / 255f, 90 / 255f);
    }

    public void move(int ind)
    {
        if (ind > cells.GetLength(0) || ind < 0) return;
        if (CheckCell(ind, 1)) return;
        if (CheckCell(ind, 4)) return;
        if (CheckCell(ind, -1)) return;
        if (CheckCell(ind, -4)) return;
        
        StartCoroutine(ReturnColor(cells[ind]));
    }

    public void ApplyButton_Click()
    {
        if (numbers[numbers.GetLength(0)-1].text != "")
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
        Movement.CanShoot = true;
        Movement.CanMove = true;
        GetItem.SetActive(true);
        Interface.MessageText = LowerPanelMessage;
        Interface.ShowPanel = true;
    }

}
