using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Highscores : MonoBehaviour {

	public string privateCode;
	public string publicCode;
	public string webURL = "http://dreamlo.com/lb/";
	public int min;
	public int max;

	//"T-e7_pXQnkGIiNGw754TawNULj0N_vm0W_GFHzznFNPg"
	//"62822ba58f40bb11c04d0c90"

	public DisplayHighscores highscoreDisplay;
	public Highscore[] highscoresList;
	static Highscores instance;
	Coroutine _coroutine;
	public Text UserName;
        public Text Score;
        public string Scoretext;
	
	void Awake() {
		
	}
	void Start()
    {
	instance = this;
        int score = PlayerPrefs.GetInt(Scoretext);
        Score.text = score.ToString("D1");;
        string username = PlayerPrefs.GetString("GameName");
        UserName.text = username;

        if(score <= max && score >= min)
        {
            AddNewHighscore(username, score);
        }
		else
		{
			ClearUserScoreVoid(username);
		}
		
    }

    public void LeaderboardCreateUser()
	{
        int score = Random.Range(min, max);
        Debug.Log("score = " + score);
        string username = "";
        string alphabet = "abcdefghijklmnopqrstuvwxyz";

        for (int i = 0; i < Random.Range(5, 10); i++)
        {
            username += alphabet[Random.Range(0, alphabet.Length)];
        }

         if(score <= max)
        {
          if(score >= min)
          {
            AddNewHighscore(username, score);
          }
        }
	}
	public void AddNewHighscore(string username, int score) {
		_coroutine = instance.StartCoroutine(instance.UploadNewHighscore(username,score));
	}

	IEnumerator UploadNewHighscore(string username, int score) {
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error)) {
			print ("Upload Successful");
			DownloadHighscores();
		}
		else {
			print ("Error uploading: " + www.error);
		}
	}

	public void DownloadHighscores() {
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

	IEnumerator DownloadHighscoresFromDatabase() {
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;
		
		if (string.IsNullOrEmpty (www.error)) {
			FormatHighscores (www.text);
			highscoreDisplay.OnHighscoresDownloaded(highscoresList);
		}
		else {
			print ("Error Downloading: " + www.error);
		}
	}
     public void ClearUserScoreVoid(string username) {
		StartCoroutine(ClearUserScoreAll(username));
	}
	IEnumerator ClearUserScoreAll(string username) {
		WWW www = new WWW(webURL + privateCode + "/delete/" + username);
		yield return www;
		
		if (string.IsNullOrEmpty (www.error)) {

		}
		else {
			print ("Error Downloading: " + www.error);
		}
	}

    public void ClearAllVoid() {
		StartCoroutine("ClearAll");
	}
	IEnumerator ClearAll() {
		WWW www = new WWW(webURL + privateCode + "/clear");
		yield return www;
		
		if (string.IsNullOrEmpty (www.error)) {

		}
		else {
			print ("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream) {
		string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i <entries.Length; i ++) {
			string[] entryInfo = entries[i].Split(new char[] {'|'});
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username,score);
			print (highscoresList[i].username + ": " + highscoresList[i].score);
		}
	}

}

public struct Highscore {
	public string username;
	public int score;

	public Highscore(string _username, int _score) {
		username = _username;
		score = _score;
	}

}
