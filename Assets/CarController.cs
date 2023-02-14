using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    [SerializeField] private SkinManager skinManager;
    [SerializeField] private RoadSkinManager  manager;
    [SerializeField] private CollectibleManager collectibleManager;
    
    public Rigidbody2D _body;
    public GameObject _coin;
    public GameObject _coinTen;
    public Button _left;
    public Button _right;

    private float _horizontal;
    public float speed;
    public GameObject ant;

    private bool moveLeft;
    private bool moveRight;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = skinManager.getSelectedSkin().sprite;
        ant = GameObject.FindGameObjectWithTag("MainCamera");
        speed = skinManager.getSelectedSkin().speed;
        moveLeft = false;
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        movementPlayer();
        GetComponent<SpriteRenderer>().sprite = skinManager.getSelectedSkin().sprite;
        speed = skinManager.getSelectedSkin().speed;
    }

    private void FixedUpdate()
    {
        _body.velocity = new Vector2(_horizontal, _body.velocity.y);
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
    }
    
    public void PointerUpLeft()
    {
        moveLeft = false;
    }
    
    public void PointerDownRight()
    {
        moveRight = true;
    }
    
    public void PointerUpRight()
    {
        moveRight = false;
    }

    private void movementPlayer()
    {
        if (moveLeft)
        {
            _horizontal = -speed;
        }
        else if (moveRight)
        {
            _horizontal = speed;
        }
        else
        {
            _horizontal = 0;
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hot");
        if (other.tag.Equals("coin")) 
        {
            Debug.Log("nice");
            Destroy(other.gameObject);
            ant.GetComponent<SpawnScript>().numberOfSpawnedItems--;
            int getCoins = PlayerPrefs.GetInt("coins");
            PlayerPrefs.SetInt("coins", getCoins+(1 * skinManager.getSelectedSkin().coins));
        }
        
        if (other.tag.Equals("TENxCoin")) 
        {
            Debug.Log("nice");
            Destroy(other.gameObject);
            ant.GetComponent<SpawnScript>().numberOfSpawnedItems--;
            int getCoins = PlayerPrefs.GetInt("coins");
            PlayerPrefs.SetInt("coins", getCoins+(10 * skinManager.getSelectedSkin().coins));
        }
        
        if (other.tag.Equals("Flower"))
        {
            Destroy(other.gameObject);
            collectibleManager.AddFlower(manager.SkinIndex());
        }
        
        if (other.tag.Equals("traffic"))
        {
            
            float hs = PlayerPrefs.GetFloat("highscore");
            if (hs < ant.GetComponent<PauseMenu>().actualScore)
            {
                PlayerPrefs.SetFloat ("highscore", ant.GetComponent<PauseMenu>().actualScore);
                
            }
            transform.position = new Vector3(0,-2,-1);
            ant.GetComponent<PauseMenu>().onCrash();
        }
    }
}
