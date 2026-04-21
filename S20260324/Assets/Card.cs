using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public CardGame cardGame;
    public bool isMatched = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFront)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originRotation, rotationSpeed * Time.deltaTime);

        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, flipRotation, rotationSpeed * Time.deltaTime);
        }


    }


    public void ClickCard()
    {


        if (!isMatched)
        {
            cardGame.OnClickCard(this);
            
        }


    }

    // ! 쓰면 bool값 반대로 바뀜.



    public void Flip(bool isFront)
    {
        this.isFront = isFront;
    }


    public void SetCard(int New_cardNumber)
    {
        text = GetComponentInChildren<TextMeshProUGUI>();

        this.cardNumber = New_cardNumber;

        text.text = New_cardNumber.ToString();
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
