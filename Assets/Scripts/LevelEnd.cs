using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private string _levelName;
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _progress;
    [SerializeField] private TMP_Text _text;


    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HandPresence>())
        {
            Load();
        }
    }

    public void Load()
    {
        _loadingScreen.SetActive(true);

        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync() 
    {
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_levelName);

        while (!asyncLoad.isDone)
        {
            float progress = asyncLoad.progress / 0.9f;
            _progress.value = progress;
            _text.text = "Load" + string.Format("{0:0}", progress * 100f);
            yield return 0;
        }
    }
}
