using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quests : MonoBehaviour
{
    [SerializeField] protected GameObject Quest;
    [SerializeField] protected GameObject GetItem;
    [SerializeField] protected Button AplyButton;
    [SerializeField] protected Interface interf;
    [SerializeField] protected string LowerPanelMessage = "Найден прудмет: ключ";
    // Start is called before the first frame update

    protected IEnumerator ReturnColor(Button button)
    {
        button.GetComponent<Image>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.5f);
        button.GetComponent<Image>().color = new Color(90 / 255f, 90 / 255f, 90 / 255f);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
