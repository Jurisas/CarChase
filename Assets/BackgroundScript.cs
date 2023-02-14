using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField] private RoadSkinManager skinManager;
    public GameObject back;
    private float speed = 2;
    public GameObject ant;
    private int i;

    public GameObject b1;
    public GameObject b2;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = skinManager.getSelectedSkin().sprite;
        b1.GetComponent<SpriteRenderer>().sprite = skinManager.getSelectedSkin().sprite;
        b2.GetComponent<SpriteRenderer>().sprite = skinManager.getSelectedSkin().sprite;
        ant = GameObject.FindGameObjectWithTag("MainCamera");
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = skinManager.getSelectedSkin().sprite;
        b1.GetComponent<SpriteRenderer>().sprite = skinManager.getSelectedSkin().sprite;
        b2.GetComponent<SpriteRenderer>().sprite = skinManager.getSelectedSkin().sprite;
        
        if (ant.GetComponent<PauseMenu>().actualScore > 20)
        {
            speed = ant.GetComponent<PauseMenu>().actualScore / 10;
        }
        else
        {
            speed = 2;
        }
        transform.position += Vector3.down * (Time.deltaTime * speed);
        if (transform.position.y <= 0 && i==0)
        {
            var position = transform.position;
            Instantiate(back, new Vector3(position.x,(float) (position.y+(11.95)),0),Quaternion.identity);
            i++;
        }
        if (transform.position.y <= -15)
        {
            Destroy(gameObject);
        }
    }
}
