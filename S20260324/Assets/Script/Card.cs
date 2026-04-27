using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    public TextMeshProUGUI text;
    public int cardNumber;
    public float rotationSpeed;
    public bool isFront = true;
    private Quaternion flipRotation = Quaternion.Euler(0, 180f, 0);
    private Quaternion originRotation = Quaternion.Euler(0, 0, 0);

    public bool isMatched = false;
    public Object CardBack_obj;
    private SpriteRenderer CardBack;

    private CardGame manager;


    public bool isImageOnly = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       CardBack = CardBack_obj.GetComponent<SpriteRenderer>();

       manager = FindAnyObjectByType<CardGame>();

       TextMeshProUGUI Text_con = GetComponentInChildren<TextMeshProUGUI>();

        if (isImageOnly && cardNumber < 10)
        {
            Text_con.enabled = false;
        }
        else
        {
            Text_con.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFront)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originRotation, rotationSpeed * Time.deltaTime);

            CardBack.enabled = false;

        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, flipRotation, rotationSpeed * Time.deltaTime);

            CardBack.enabled = true;

        }


    }


    public void ClickCard()
    {


        if (isMatched || isFront)
        {
            return;
            
        }
        manager.OnClickCard(this);

    }

    // ! 쓰면 bool값 반대로 바뀜.



    public void Flip(bool isFront)
    {
        this.isFront = isFront;
    }


    public void SetCard(int New_cardNumber)
    {
        text = GetComponentInChildren<TextMeshProUGUI>();

        text.text = New_cardNumber.ToString();

        cardNumber = New_cardNumber;
    }

    public void ChangeColor(Color newColor)
    {
        GetComponent<Image>().color = newColor;
    }


    public void Setimage(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
    }

}
