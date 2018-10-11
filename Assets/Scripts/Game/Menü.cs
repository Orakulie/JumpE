using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menü : MonoBehaviour {
    public Text Coins;
    public int Preis = 30;
    public Slider quality;
    public Text qualitystatus;
    public Toggle Vollbild;
	// Use this for initialization
	void Start () {
        GameObject.Find("Placeholder").GetComponent<Text>().text = PlayerPrefs.GetString("Name");
        try
        {
            GameObject.Find("Network").GetComponent<NetworkManagerHUD>().enabled = false;
        }
        catch
        {

        }
	}

    // Update is called once per frame
    void Update() {
        Coins.text = "Coins: " + PlayerPrefs.GetInt("Coins");
        QualitySettings.SetQualityLevel((int)quality.value, true);
        qualitystatus.text = "" + QualitySettings.names[QualitySettings.GetQualityLevel()];
        if(Vollbild.isOn == true)
        {
            //Screen.fullScreen = true;
            Screen.SetResolution(1920, 1080, true);
        }
        if (Vollbild.isOn == false)
        {
            Screen.SetResolution(800, 600, false);
        }
    }

    public void Starten()
    {
        try
        {
            GameObject.Find("Network").GetComponent<NetworkManagerHUD>().enabled = true;
        }
        catch
        {

        }
        if (GameObject.Find("NameP").GetComponent<Text>().text != "")
        {
            PlayerPrefs.SetString("Name", GameObject.Find("NameP").GetComponent<Text>().text);
            SceneManager.LoadScene(1);
        }
        if (GameObject.Find("NameP").GetComponent<Text>().text == "")
        {
         //PlayerPrefs.SetString("Name", GameObject.Find("NameP").GetComponent<Text>().text);
            SceneManager.LoadScene(1);
        }
    }
    public void Rpg()
    {
        try
        {
            GameObject.Find("Network").GetComponent<NetworkManagerHUD>().enabled = true;
        }
        catch
        {

        }
        if (GameObject.Find("NameP").GetComponent<Text>().text != "")
        {
            PlayerPrefs.SetString("Name", GameObject.Find("NameP").GetComponent<Text>().text);
            SceneManager.LoadScene(2);
        }
        if (GameObject.Find("NameP").GetComponent<Text>().text == "")
        {
            //PlayerPrefs.SetString("Name", GameObject.Find("NameP").GetComponent<Text>().text);
            SceneManager.LoadScene(2);
        }
    }
    public void Beenden()
    {
        Application.Quit();
    }
    public void Farbe(string farbe)
    {
        if (farbe == "Blau")
        {
            if (PlayerPrefs.GetInt("Coins") >= Preis)
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - Preis);
                PlayerPrefs.SetString("Farbe", "Blau");
                Debug.Log("Gekauft blau");
                Debug.Log(PlayerPrefs.GetInt("Coins"));
            }
           
        }
        if (farbe == "Gelb")
        {
            if (PlayerPrefs.GetInt("Coins") >= Preis)
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - Preis);
                PlayerPrefs.SetString("Farbe", "Gelb");
                Debug.Log("Gekauft gelb");
                Debug.Log(PlayerPrefs.GetInt("Coins"));
            }

        }
    }
}

