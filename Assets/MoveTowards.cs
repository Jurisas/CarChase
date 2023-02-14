using UnityEngine;
using UnityEngine.Serialization;

public class MoveTowards : MonoBehaviour
{
    [FormerlySerializedAs("_body")] public Rigidbody2D body;
    public GameObject ant;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
        speed = Random.Range(2f, 4f);
        ant = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * (Time.deltaTime * (speed + ant.GetComponent<PauseMenu>().actualScore / 10));

        if (transform.position.y <= -8)
        {
            Destroy(gameObject);
            ant.GetComponent<SpawnScript>().numberOfSpawnedItems--;
            
        }

        if (ant.GetComponent<PauseMenu>().setWorldReset)
        {
            Destroy(gameObject);
            ant.GetComponent<SpawnScript>().numberOfSpawnedItems--;
        }
    }
}
