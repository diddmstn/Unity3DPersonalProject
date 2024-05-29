using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    [Header("Count")]
    public int count;
    public TextMeshProUGUI countText;
    public static GameManager instance;
    Coroutine coroutine;
    public int currentSceneIndex=0;
    public GameObject Panel;

   
    private void Awake() 
    {
        if(instance == null)
        {
            instance =this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance==this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start() 
    {
        countText.gameObject.SetActive(false);
    }

    public void EnterGame()
    {
       coroutine=StartCoroutine(CountDown());
    }

    void GameStart()
    {
        CharacterManager.Instance.Player.SetPosition();//플레이어를 시작 위치로 이동
        Time.timeScale =0;
        Panel.SetActive(true);
        Cursor.lockState= CursorLockMode.None;

        //게임 설명 유아이 뜨게 하고

    }
    public void ClosePanel()
    {
        Panel.SetActive(false);
        coroutine=StartCoroutine(CountDown());
        Cursor.lockState= CursorLockMode.Locked;

    }

    IEnumerator CountDown()
    {
        countText.gameObject.SetActive(true);
        for(int i=count;0<i;i--)
        {
            countText.text= $"{i}";
            yield return new WaitForSecondsRealtime(1f);
        }
        if(currentSceneIndex==0)
        {
            currentSceneIndex=Random.Range(1,2);
            SceneManager.LoadScene(currentSceneIndex);
            yield return null;
            GameStart();

        }
        else
        {
            Time.timeScale =1;
        }
        

        countText.gameObject.SetActive(false);
    }
}
