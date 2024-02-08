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
            float tier1 = float.Parse(values[1]);
            Debug.Log(values[1]);
            float tier2 = float.Parse(values[2]);
            Debug.Log(values[2]);
            float tier3 = float.Parse(values[3]);
            Debug.Log(values[3]);
            float tier4 = float.Parse(values[4]);
            Debug.Log(values[4]);
            float tier5 = float.Parse(values[5]);
            Debug.Log(values[5]);
            float tier6 = float.Parse(values[6]);
            Debug.Log(values[6]);
            float tier7 = float.Parse(values[7]);
            Debug.Log(values[7]);
            float tier8 = float.Parse(values[8]);
            Debug.Log(values[8]);
            float tier9 = float.Parse(values[9]);
            Debug.Log(values[9]);
            float tier10 = float.Parse(values[10]);
            Debug.Log(values[10]);

            Country newCountry = new Country(country,tier1,tier2,tier3,tier4,tier5,tier6,tier7,tier8,tier9,tier10);
            countryList.Add(newCountry);
            Debug.Log(newCountry.countryName + " " + newCountry.tier1 + " " + newCountry.tier2 + " " + newCountry.tier3 + " " + newCountry.tier4 + " " + newCountry.tier5 + " " + newCountry.tier6 + " " + newCountry.tier7 + " " + newCountry.tier8 + " " + newCountry.tier9 + " " + newCountry.tier10 );
            
        }
        countriesData = countryList;
        return countryList;
    }

    public int getRockCount(string name, int tier){
        Country country = getCountry(name);
        switch(tier) {
            case 1:
                return countRocks(country.tier1);
                break;
            case 2:
                return countRocks(country.tier2);
                break;
            case 3:
                return countRocks(country.tier3);
                break;
            case 4:
                return countRocks(country.tier4);
                break;
            case 5:
                return countRocks(country.tier5);
                break;
            case 6:
                return countRocks(country.tier6);
                break;
            case 7:
                return countRocks(country.tier7);
                break;
            case 8:
                return countRocks(country.tier8);
                break;
            case 9:
                return countRocks(country.tier9);
                break;
            case 10:
                return countRocks(country.tier10);
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
