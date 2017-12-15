using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using Mono.Data.SqliteClient; 


public class gameManager : Singleton<gameManager> {

    public float score = 0f;

    public Light sceneLight;

    public AudioSource musicAudioSource;

    public Text mainTimeDisplay;
    public Text mainScoreDisplay;
    public Text gameOverTime;

    public bool gameIsOver = false;

    public GameObject gameOverDisplay;
    public GameObject gameOverTimeDisplay;
    public GameObject playAgainButton;
    public GameObject MenuButton;

    private float timer; 

    private void Start()
    {
        //DataBase connection 

        string conn = "URI=file:" + Application.dataPath + "/PickAndPlaceDatabase.s3db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT value,name, randomSequence " + "FROM PlaceSequence";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int value = reader.GetInt32(0);
            string name = reader.GetString(1);
            int rand = reader.GetInt32(2);

            Debug.Log("value= " + value + "  name =" + name + "  random =" + rand);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        //


        gameIsOver = false;

        score = 0;

        timer = 0;

        if (gameOverTimeDisplay)
        {
            gameOverTimeDisplay.SetActive(false);
        }

        if (gameOverDisplay)
            gameOverDisplay.SetActive(false);

        if (playAgainButton)
            playAgainButton.SetActive(false);

        if (MenuButton)
            MenuButton.SetActive(false);

        sceneLight.gameObject.SetActive(true);

        mainScoreDisplay.gameObject.SetActive(true);
        mainTimeDisplay.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (score < 0)
        {
            endGame();
        }

        else
        {
            timer += Time.deltaTime;
            score += Time.deltaTime;
            mainScoreDisplay.text = score.ToString("0.00");
            mainTimeDisplay.text = timer.ToString("0.0");
        }
    }

    public void endGame()
    {
        gameIsOver = true;

        if(sceneLight)
            sceneLight.gameObject.SetActive(false);

        if(mainScoreDisplay)
            mainScoreDisplay.gameObject.SetActive(false); 

        if(gameOverTime)
            gameOverTime.text = timer.ToString("0"); 

        // activate the gameOverScoreOutline gameObject, if it is set 
        if (gameOverTimeDisplay)
            gameOverTimeDisplay.SetActive(true);
        

        if (gameOverDisplay)
            gameOverDisplay.SetActive(true);

        // activate the playAgainButtons gameObject, if it is set 
        if (playAgainButton)
            playAgainButton.SetActive(true);

        if (MenuButton)
            MenuButton.SetActive(true);

        if (musicAudioSource)
            musicAudioSource.enabled = false; // turn off the music
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
