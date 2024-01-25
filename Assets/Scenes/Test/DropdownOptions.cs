using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DropdownOptions : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    private DataLoader dataLoader;
    // Start is called before the first frame update
    void Start()
    {
        dataLoader = new DataLoader();
        
         List<Country> countryList = new List<Country>();
         countryList = dataLoader.LoadData();

        List<string> opcoes = new List<string>();
        dropdown.ClearOptions();
        foreach (Country item in countryList){
                opcoes.Add(item.countryName);
        }
        dropdown.AddOptions(opcoes);
    }

    // Update is called once per frame
}
