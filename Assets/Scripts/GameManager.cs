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
    [Header("GameUI")]
    public GameObject Panel;
    public GameObject GameUIPanel;
  

   
    private void Awake() 
    {
        if(instance == null)
        {
            instance =this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
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
        CharacterManager.Instance.Player.SetPosition(currentSceneIndex);//플레이어를 시작 위치로 이동
        CharacterManager.Instance.Player.condition.ResetCondition();//플레이어를 시작 위치로 이동
        Time.timeScale =0;
        Panel.SetActive(true);
        Cursor.lockState= CursorLockMode.None;
    }
    public void GameClear()
    {
        GameUIPanel.SetActive(true);
        GameUIPanel.transform.GetChild(0).gameObject.SetActive(true);
        GameUIPanel.transform.GetChild(1).gameObject.SetActive(false);
        Time.timeScale =0;
        Cursor.lockState= CursorLockMode.None;
    }
    public void GameOver()
    {
        GameUIPanel.SetActive(true);
        GameUIPanel.transform.GetChild(1).gameObject.SetActive(true);
        GameUIPanel.transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale =0;
        Cursor.lockState= CursorLockMode.None;
    }

    public void RetryButton()
    {
        GameUIPanel.SetActive(false);
        GameStart();
    }
    public void ReturnRobby()
    {
        GameUIPanel.SetActive(false);
        SceneManager.LoadScene(0);
        currentSceneIndex =0;
        CharacterManager.Instance.Player.SetPosition(currentSceneIndex);//플레이어를 시작 위치로 이동
        Time.timeScale =1;
        Cursor.lockState= CursorLockMode.Locked;

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
