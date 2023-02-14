using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    //Nastavuje, zda se má hra obnovit do výchozí pozice
    public bool setWorldReset = false;
    
    //Texty a promenne pro penize a skore
    public Text coinsText;
    public Text scoreText;
    public Text hsText;
    public float actualScore = 0;
    
    public Text pause;
    public Text death;
    public Text gameName;
    
    //pozadi
    public Image background;
    public Image nameBck;
    public Image scoreBck;
    public Image hsBck;

    //tlacitka
    public GameObject gotomenu;
    public GameObject reset;
    public GameObject rewardVideo;
    
    public GameObject pauseButton;
    public GameObject playButton;
    public GameObject exitButton;
    public GameObject igButton;
    public GameObject shopButton;
    public GameObject backMenu;
    
    public GameObject roadBackMenu;
    public GameObject roadShopButton;
    public GameObject collectibles;
    public GameObject collBackMenu;
    

    public GameObject panel;
    public GameObject roadShopPanel;
    public GameObject collectiblesPanel;
    
    public GameObject back;

    //zda je menu aktivni
    private bool menuIsActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //Nastaveni textu pri spusteni
        coinsText.text = "COINS: " + PlayerPrefs.GetInt("coins");
        hsText.text = "HIGHSCORE: " + PlayerPrefs.GetFloat("highscore").ToString("0");
        scoreText.text = "SCORE: " + 0;
        
        pause.GetComponent<Text>().enabled = false;
        death.GetComponent<Text>().enabled = false;
        scoreText.GetComponent<Text>().enabled = false;

        reset.SetActive(false);
        gotomenu.SetActive(false);
        rewardVideo.SetActive(false);
        //backMenu.SetActive(false);
        panel.SetActive(false);
        roadShopPanel.SetActive(false);
        collectiblesPanel.SetActive(false);
        GetComponent<PauseMenu>().pauseButton.SetActive(false);
        GetComponent<PauseMenu>().scoreBck.enabled = false;
        
        Time.timeScale = 0;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        reset.GetComponent<Button>().onClick.AddListener(Reset);
        collectibles.GetComponent<Button>().onClick.AddListener(collectibleBook);
        roadShopButton.GetComponent<Button>().onClick.AddListener(goToRoadShop);
        pauseButton.GetComponent<Button>().onClick.AddListener(pauseGame);
        exitButton.GetComponent<Button>().onClick.AddListener(exitGame);
        playButton.GetComponent<Button>().onClick.AddListener(playGame);
        gotomenu.GetComponent<Button>().onClick.AddListener(resetGame);
        rewardVideo.GetComponent<Button>().onClick.AddListener(resetGame);
        igButton.GetComponent<Button>().onClick.AddListener(openIg);
        shopButton.GetComponent<Button>().onClick.AddListener(goToShop);
        backMenu.GetComponent<Button>().onClick.AddListener(resetGame);
        roadBackMenu.GetComponent<Button>().onClick.AddListener(resetGame);
        collBackMenu.GetComponent<Button>().onClick.AddListener(resetGame);
        coinsText.text = "COINS: " + PlayerPrefs.GetInt("coins");
   
    }

    private void Update()
    {
        actualScore += 1 * Time.deltaTime;
        scoreText.text = "SCORE: " + actualScore.ToString("0");
    }

    public void Reset()
    {
        resetGame();
        playGame();
    }
    
    //Smrt hrace UI
    public void onCrash()
    {
        Time.timeScale = 0;
        GetComponent<PauseMenu>().death.enabled = true;
        GetComponent<PauseMenu>().background.enabled = true;
        GetComponent<PauseMenu>().reset.SetActive(true);
        GetComponent<PauseMenu>().rewardVideo.SetActive(true);
        GetComponent<PauseMenu>().gotomenu.SetActive(true);
        GetComponent<PauseMenu>().pauseButton.SetActive(false);
        
        hsText.enabled = true;
        GetComponent<PauseMenu>().hsBck.enabled = true;
        hsText.text = "HIGHSCORE: " + PlayerPrefs.GetFloat("highscore").ToString("0");
        setWorldReset = true;
        


    }

    //Prechod do obchodu
    public void goToShop()
    {
        playButton.SetActive(false);
        exitButton.SetActive(false);
        igButton.SetActive(false);
        shopButton.SetActive(false);
        collectibles.SetActive(false);
        roadShopButton.SetActive(false);
        gameName.text = "SHOP";
        panel.SetActive(true);
        hsText.enabled = false;
        GetComponent<PauseMenu>().hsBck.enabled = false;
    }
    public void goToRoadShop()
    {
        playButton.SetActive(false);
        exitButton.SetActive(false);
        igButton.SetActive(false);
        shopButton.SetActive(false);
        collectibles.SetActive(false);
        roadShopButton.SetActive(false);
        gameName.text = "SHOP";
        roadShopPanel.SetActive(true);
        hsText.enabled = false;
        GetComponent<PauseMenu>().hsBck.enabled = false;
        setWorldReset = true;
    }
    
    public void collectibleBook()
    {
        playButton.SetActive(false);
        exitButton.SetActive(false);
        igButton.SetActive(false);
        shopButton.SetActive(false);
        collectibles.SetActive(false);
        roadShopButton.SetActive(false);
        gameName.text = "BOOK";
        collectiblesPanel.SetActive(true);
        hsText.enabled = false;
        GetComponent<PauseMenu>().hsBck.enabled = false;
        setWorldReset = true;
    }
    
    
    //Navrat do menu
    public void resetGame()
    {
        Time.timeScale = 1;
        gameName.text = "NONAME GAME";
        hsText.enabled = false;
        GetComponent<PauseMenu>().hsBck.enabled = false;
        setWorldReset = false;
        gameName.enabled = true;
        GetComponent<PauseMenu>().nameBck.enabled = true;
        playButton.SetActive(true);
        exitButton.SetActive(true);
        shopButton.SetActive(true);
        igButton.SetActive(true);
        roadShopButton.SetActive(true);
        collectibles.SetActive(true);
        hsText.enabled = true;
        GetComponent<PauseMenu>().hsBck.enabled = true;
        pause.GetComponent<Text>().enabled = false;
        death.GetComponent<Text>().enabled = false;
        scoreText.GetComponent<Text>().enabled = false;
        GetComponent<PauseMenu>().scoreBck.enabled = false;
        panel.SetActive(false);
        roadShopPanel.SetActive(false);
        collectiblesPanel.SetActive(false);
        reset.SetActive(false);
        gotomenu.SetActive(false);
        rewardVideo.SetActive(false);
        GetComponent<PauseMenu>().pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    
    //Stopnuti hry
    private void pauseGame()
    {
        if (!menuIsActive)
        {
            Time.timeScale = 0;
            GetComponent<PauseMenu>().background.enabled = true;
            GetComponent<PauseMenu>().pause.enabled = true;
            menuIsActive = true;
        }
        else
        {
            Time.timeScale = 1;
            GetComponent<PauseMenu>().background.enabled = false;
            GetComponent<PauseMenu>().pause.enabled = false;
            menuIsActive = false;
        }
    }
    
    //Ukonceni hry
    private void exitGame()
    {
        Application.Quit();
    }
    
    //Spusteni hry
    private void playGame()
    {
        
        Time.timeScale = 1;
        GetComponent<PauseMenu>().background.enabled = false;
        GetComponent<PauseMenu>().gameName.enabled = false;
        GetComponent<PauseMenu>().nameBck.enabled = false;
        playButton.SetActive(false);
        exitButton.SetActive(false);
        pauseButton.SetActive(true);
        igButton.SetActive(false);
        shopButton.SetActive(false);
        reset.SetActive(false);
        gotomenu.SetActive(false);
        rewardVideo.SetActive(false);
        roadShopButton.SetActive(false);
        collectibles.SetActive(false);
        hsText.enabled = false;
        GetComponent<PauseMenu>().hsBck.enabled = false;
        actualScore = 0;
        scoreText.GetComponent<Text>().enabled = true;
        GetComponent<PauseMenu>().scoreBck.enabled = true;
        panel.SetActive(false);
        roadShopPanel.SetActive(false);

    }

    //Otevreni ig odkazu
    private void openIg()
    {
        Application.OpenURL("instagram://user?username=jirka_kupka");
    }

    public float GetScore()
    {
        return actualScore;
    }
}
