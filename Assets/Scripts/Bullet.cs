
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public GameObject miniMeteor;
    private float miniMeteorTimeLife = 3f;

    public float speed = 10f;
    
    public Vector3 targetVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
        var newPos = transform.position;
        if(newPos.x > Player.xBorderLimit)
            gameObject.SetActive(false);
        else if (newPos.x < -Player.xBorderLimit)
            gameObject.SetActive(false);
        else if (newPos.y > Player.yBorderLimit)
            gameObject.SetActive(false);
        else if(newPos.y < -Player.yBorderLimit)
            gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MiniEnemy"))
        {
            IncreaseScore();
            Destroy(other.gameObject);
            gameObject.SetActive(false);
        }
         if(other.gameObject.CompareTag("Enemy"))
        {
            
            Vector2 p = new Vector2(5f, 7f);
            GameObject mini1 = Instantiate(miniMeteor,other.transform.position , Quaternion.Euler(0,0,45f));
            MiniMeteor mini1rig = mini1.GetComponent<MiniMeteor>();
            mini1rig.targetVector = new Vector2(0,-5f);
            Destroy(mini1, miniMeteorTimeLife);
            
            GameObject mini2 = Instantiate(miniMeteor,other.transform.position , Quaternion.Euler(0,0,-45f));
            MiniMeteor mini2rig = mini2.GetComponent<MiniMeteor>();
            mini2rig.targetVector = new Vector2(0,-5f);
            Destroy(mini2, miniMeteorTimeLife);
            
            Destroy(other.gameObject);
            IncreaseScore();
            gameObject.SetActive(false);
        }
    }

    
    private void IncreaseScore()
    {
        Player.SCORE++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Puntos : " + Player.SCORE;
    }


}

