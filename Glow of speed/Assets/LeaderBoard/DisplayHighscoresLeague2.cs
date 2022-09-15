using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscoresLeague2 : MonoBehaviour
{
    public Text[] highscoreFields;
	public HighscoresLeague2 highscoresManager;

	void Start() {
        // League 1
		for (int i = 0; i < highscoreFields.Length; i ++) {
			highscoreFields[i].text = i+1 + ". Fetching...";
		}

		StartCoroutine("RefreshHighscores");
	}
	
	public void OnHighscoresDownloaded(Highscore1[] highscoreList) {
        // League 1
		for (int i =0; i < highscoreFields.Length; i ++) {
			highscoreFields[i].text = i+1 + ". ";
			if (i < highscoreList.Length) {
				highscoreFields[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
			}
		}
	}
	
	IEnumerator RefreshHighscores() {
        // League 1
		while (true) {
			highscoresManager.DownloadHighscores();
			yield return new WaitForSeconds(30);
		}
	}
}
