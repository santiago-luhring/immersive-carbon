using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{

    public string csvFileName = "carbon";
    public List<Country> countriesData;

    public List<Country> LoadData()
    {
        
       List<Country> countryList = new List<Country>();
       TextAsset csvFile = Resources.Load<TextAsset>(csvFileName);
        if (csvFile == null)
        {
            Debug.LogError("CSV File Not Found!");
            return countryList;
        }

        Debug.LogError("FileFound!");

        string[] lines = csvFile.text.Split('\n');

        for (int i = 1;i <= lines.Length-1; i++)
        {
            string line = lines[i];
            string[] values = line.Split(',');

            string country = values[0];
            Debug.Log(values[0]);
            float low = float.Parse(values[1]);
            Debug.Log(values[1]);
            float medium = float.Parse(values[2]);
            Debug.Log(values[2]);
            float high = float.Parse(values[3]);
            Debug.Log(values[3]);

            Country newCountry = new Country(country,low,medium,high);
            countryList.Add(newCountry);
            Debug.Log(newCountry.countryName + " " + newCountry.low + " " + newCountry.medium + " " + newCountry.high );
            
        }
        countriesData = countryList;
        return countryList;
    }

    public int getRockCount(string name, int income){
        Country country = getCountry(name);
        switch(income) {
            case 1:
                return countRocks(country.low);
                break;
            case 2:
                return countRocks(country.medium);
                break;
            case 3:
                return countRocks(country.high);
                break;
            default:
                return 0;
        }
    }

    private int countRocks(float value){
        Debug.Log(value);
        float kilograms = value * 1000;
        Debug.Log(kilograms);
        float rockCount = kilograms/10;
        Debug.Log(rockCount);
        return Mathf.RoundToInt(rockCount);
    }

    private Country getCountry(string name){
        foreach (Country item in countriesData){
            if(item.countryName == name){
                return item;
            }
        }
        return null;
    }
}
