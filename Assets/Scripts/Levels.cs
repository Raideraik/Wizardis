using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _progress;
    [SerializeField] private TMP_Text _text;
    public void Level1()
    {
        Load("Level1");
    } public void Level2()
    {
        Load("Level2");
    } public void Level3()
    {
        Load("Level3");
    } public void Level4()
    {
        Load("Level4");
    } public void Level5()
    {
        Load("Level5");
    }

    public void Load(string name)
    {
        _loadingScreen.SetActive(true);

        StartCoroutine(LoadAsync(name));
    }

    IEnumerator LoadAsync(string name)
    {
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        while (!asyncLoad.isDone)
        {
            float progress = asyncLoad.progress / 0.9f;
            _progress.value = progress;
            _text.text = "Load" + string.Format("{0:0}", progress * 100f);
            yield return 0;
        }
    }
}
