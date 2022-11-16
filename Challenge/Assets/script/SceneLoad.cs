using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Loadlevel());
    }

    IEnumerator Loadlevel()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Menu");
    }
}
