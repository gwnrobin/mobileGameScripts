using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Playe : MonoBehaviour
{
    [SerializeField]
    private GameObject text;
    private int CollectablesCollected;
    private int keyTag;
    private Vector3 startPosition;
    private int deathMessageCount;

    public TimeManager theTimeManager;
    public ScoreManager theScoreManager;
    private Animator chestAnim;

    public int theSecondsToWait;

    public GameObject theDeathMenu;

    void Start()
    {

        chestAnim = GameObject.Find("Chest").GetComponent<Animator>();
        startPosition = transform.position;
    }

    void Update()
    {
//        print(startPosition);
        if (text.GetComponent<Text>().enabled == true)
        {
            deathMessageCount++;
        }
        if(deathMessageCount == 90)
        {
            text.GetComponent<Text>().enabled = false;
            deathMessageCount = 0;
        }

        //Keybinding test for stopping timer.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            /*theTimeManager.StopCounting();*/
        }

        //Keybinding test for coins collecting.
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            theScoreManager.AddValueToScore(1);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        //Collision with collectable.
        if (other.tag == "collectable+")
        {
            CollectablesCollected++;
            Destroy(other.gameObject);
            theScoreManager.AddValueToScore(1);
        }

        //Collsion with key.
        if (other.tag == "key")
        {
            other.gameObject.GetComponent<KeyTag>().doDestroy = true;
        }

        //Collision with spikes.
        if (other.tag == "death")
        {
            transform.position = startPosition;
            theDeathMenu.SetActive(true);
            Time.timeScale = 0f;
            /*text.GetComponent< Text>().enabled = true;*/
        }

        //Collision with finish.
        if (other.tag == "Finish")
        {
            chestAnim.Play("Open", 0, 0);
            StartCoroutine(OnFinish());
        }

    }

    IEnumerator OnFinish()
    {
        /*theTimeManager.StopCounting();*/
        yield return new WaitForSeconds(theSecondsToWait);
        SceneManager.LoadScene(Application.loadedLevel +1);
        /*theTimeManager.ResetCounting();*/
    }

}
