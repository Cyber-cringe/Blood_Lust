using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacter : MonoBehaviour
{
    [SerializeField] float MaxHP = 100;
    float HP = 30;
    [SerializeField] Image HPBar;
    [SerializeField] Text HPInfo;
    public static string ActiveItem="Default";
    [SerializeField] Text ActiveItemInfo;
    public GameObject Maincharacter;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Health"))
        {
            Destroy(other.gameObject);
            HP += MaxHP - HP>=20? 20: MaxHP - HP;

        }

        if (other.gameObject.CompareTag("Enemies"))
        {
            //Destroy(other.gameObject);
            Maincharacter.GetComponent<Transform>().position = Maincharacter.GetComponent<Transform>().position + new Vector3(2, 0, 0);
            HP -= 10;

            if (HP <= 0)
            {
                Destroy(gameObject);
                HPInfo.text = ($"{HP}/{MaxHP}");
                HPBar.fillAmount = HP / MaxHP;
            }


        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            //Maincharacter.GetComponent<Transform>().position = Maincharacter.GetComponent<Transform>().position + new Vector3(2, 0, 0);
            HP -= 10;

            if (HP <= 0)
            {
                HPInfo.text = ($"{HP}/{MaxHP}");
                HPBar.fillAmount = HP / MaxHP;
                Destroy(gameObject);
            }


        }
    }
    void Start()
    {
        HP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        HPInfo.text = ($"{HP}/{MaxHP}");
        HPBar.fillAmount = HP/MaxHP;
        ActiveItemInfo.text=($"Активный предмет: {ActiveItem}").ToString();
    }
}
