using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public TMP_Text City;
    public TMP_Text Temp;
    public TMP_Text Date;
    public TMP_Text cloudy;
    public GameObject icon;
    public TMP_Text Humidity;
    public TMP_Text pressure;
    public TMP_Text wind;

    public Sprite[] weatherIcons;

    // Start is called before the first frame update

    static private string weatherAPIKey = "your_key";
    static private string yourCity = "MEKNES"; // chose the city
    private string url = "https://api.weatherapi.com/v1/current.json?key=" + weatherAPIKey + "&q=" + yourCity;
    

    void Start()
    {
        StartCoroutine(Fetchdata());

    }
    IEnumerator Fetchdata()
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if(webRequest.responseCode == 200)
            {
                //string data = JsonUtility.ToJson(webRequest.downloadHandler.text);
               CityData cityData = JsonUtility.FromJson<CityData>(webRequest.downloadHandler.text);

                City.text = cityData.location.name;
                Date.text = cityData.location.localtime;
                Temp.text = cityData.current.temp_c.ToString() + '°';
                cloudy.text = cityData.current.condition.text;

                Humidity.text = cityData.current.humidity.ToString();
                pressure.text = cityData.current.pressure_mb.ToString();
                wind.text = cityData.current.wind_kph.ToString();

                switch (cityData.current.condition.text)
                {
                    case "Light rain":
                        icon.GetComponent<Image>().sprite = weatherIcons[2];
                        break;
                    case "Partly cloudy":
                        icon.GetComponent<Image>().sprite = weatherIcons[1];
                        break;
                    case "Clear":
                        icon.GetComponent<Image>().sprite = weatherIcons[0];
                        break;
                    case "Heavy rain":
                        icon.GetComponent<Image>().sprite = weatherIcons[3];
                        break;
                    default:
                        break;
                }

            }
            else
            {
                Debug.Log("error fetching;");
                Debug.LogError("Error fetching.");

            }



        }
    }

}
