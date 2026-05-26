using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Toggle toggleBGM;
    public Toggle toggleFX;

    public Slider BgmSlider;
    public Slider FxSlider;

    public GameObject Panel;
    public GameObject PanelSet;

    public Button GameEndButton;

    private PlayerInput playerInput;

    private CardGame cardGame;

    public Button setButtonOpen;
    public Button setButtonClose;

    public Button removeButton;
    public Button restartButton;

    public Slider test_setCount;
    public TextMeshProUGUI test_Count;


    public InputField InputCount;


    private void Awake()
    {
        Panel.SetActive(false);
        PanelSet.SetActive(false);

        playerInput = new PlayerInput();

        cardGame = FindAnyObjectByType<CardGame>();

        playerInput.KeyMap.ESC.performed +=  e => TogglePanel();

        playerInput.Enable();

        setButtonOpen.onClick.AddListener(OpenSet);
        setButtonClose.onClick.AddListener(CloseSet);

        GameEndButton.onClick.AddListener(EndTheGame);

        toggleBGM.onValueChanged.AddListener(OnToggleBGMChange);

        toggleFX.onValueChanged.AddListener(OnToggleFXChange);

        BgmSlider.onValueChanged.AddListener(OnBgmsliderChange);
        FxSlider.onValueChanged.AddListener(OnFXliderChange);

        removeButton.onClick.AddListener(RemoveCard);

        restartButton.onClick.AddListener(Restart);

        test_setCount.onValueChanged.AddListener(SetCardNumber_float);



        
    }


    private void OpenSet()
    {
        PanelSet.SetActive(true);
    }

    private void CloseSet()
    {
        PanelSet.SetActive(false);
    }

    private void EndTheGame()
    {
        Application.Quit();
    }

    private void OnToggleBGMChange(bool isOn)
    {
        SoundManager.Instance.OnOffBGM(isOn);
    }

    private void OnToggleFXChange(bool isOn)
    {
        SoundManager.Instance.OnOffFX(isOn);
    }


    private void TogglePanel()
    {
        Panel.SetActive(!Panel.activeSelf);

        cardGame.isCardBackOff = Panel.activeSelf;


    }


    private void CardOff()
    {
        cardGame.isCardBackOff = false;
    }



    private void RemoveCard()
    {

        Debug.Log("Restart Game");

        CardOff();
        Invoke("DestroyCard", 0.1f);

        cardGame.cards.Clear();

    }

    private void Restart()
    {
        //SceneManager.LoadScene("SampleScene");

        cardGame.StartGame();
    }

    private void SetCardNumber_float(float cardCount_float)
    {
        SetCardNumber((int)cardCount_float);
    }

    private void SetCardNumber(int cardCount)
    {
        cardGame.cardCount = cardCount;
    }

    private void Update()
    {
        SetCardNumber_float(test_setCount.value);
    }


    public void DestroyCard()
    {
        GameObject[] Cards = GameObject.FindGameObjectsWithTag("Card");
        foreach (GameObject target in Cards)
        {
            GameObject.Destroy(target);
        }
    }

    private void OnBgmsliderChange(float volue)
    {
        SoundManager.Instance.SetBGMVolume(volue);
    }

    private void OnFXliderChange(float volue)
    {
        SoundManager.Instance.SetFXVolume(volue);
    }



    private void FixedUpdate()
    {
        test_Count.text = cardGame.cardCount.ToString();
    }


}
