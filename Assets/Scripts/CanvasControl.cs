using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mono.Data.SqliteClient;
using System.Data;

public class CanvasControl : MonoBehaviour {

    //DB connection Var
    string _strDBName = "URI=file:MasterSQLite.db";
    IDbConnection _connection;
    IDbCommand _command;

    public Canvas menuCanvas;
    public Canvas aboutCanvas;

    public Text firstPage;
    public Text secondPage;

    public Button buttonFirst;
    public Button buttonSecond;

    public InputField nameInput;

    public string playerName;


    private void Start()
    {
        _connection = new SqliteConnection(_strDBName);
        _connection.Open();
        _command = _connection.CreateCommand();
    }

    public void play()
    {
        nameInput.gameObject.SetActive(true);
        playerName = nameInput.text.ToString();

        _command.CommandText = "insert into highscores (name) values ('playerName')";
        _command.ExecuteNonQuery();

        _command.Dispose();
        _command = null;
        _connection.Close();
        _connection = null;

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

    public void loadScene()
    {
        SceneManager.LoadScene(1);
    }
}
