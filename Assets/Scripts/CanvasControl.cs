using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasControl : MonoBehaviour {

    public Canvas menuCanvas;
    public Canvas aboutCanvas;

    public Text firstPage;
    public Text secondPage;
    public Button buttonFirst;
    public Button buttonSecond;

    public void play()
    {
        SceneManager.LoadScene(1);
    }

    public void about()
    {
        menuCanvas.gameObject.SetActive(false);
        aboutCanvas.gameObject.SetActive(true);
    }

    public void nextPage()
    {
        firstPage.gameObject.SetActive(false);
        secondPage.gameObject.SetActive(true);

        buttonFirst.gameObject.SetActive(false);
        buttonSecond.gameObject.SetActive(true); 
    }
}
