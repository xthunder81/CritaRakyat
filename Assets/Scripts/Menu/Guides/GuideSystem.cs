using UnityEngine;

public class GuideSystem : MonoBehaviour
{


    public GameObject[] guides;
    public Menu menu;

    int _selectedObjectIndex = -1;

    public void SelectObject(int selectedIndex)
    {
        menu = GetComponent<Menu>();


        if (_selectedObjectIndex >= 0)
            guides[_selectedObjectIndex].SetActive(false);


        _selectedObjectIndex = selectedIndex;
        guides[selectedIndex].SetActive(true);

        if (_selectedObjectIndex == guides.Length - 1)
        {
            guides[_selectedObjectIndex].SetActive(false);
            TempGuide = 1;
            SaveGuidesPlayerPref();
        }

        else if (_selectedObjectIndex == 2)
        {
            //StartCoroutine(menu.TombolKartu());
            //menu.SubKartuMenu.SetActive(true);
        }
        
        else if (_selectedObjectIndex > 3)
        {
            menu.TombolHome();
        }
    }

    void Start()
    {
        for (int i = 0; i < guides.Length; i++)
        {
            guides[i].SetActive(false);
        }

        LoadGuidesPlayerPref();

        if (TempGuide !=1)
        {
            SelectObject(0);
        }
        // SelectObject(0);
    }

    private int tempGuide;
    public int TempGuide
    {
        get { return tempGuide; }
        set { tempGuide = value; }
    }

    public void LoadGuidesPlayerPref()
    {
        if (PlayerPrefs.HasKey("Guide1"))
            TempGuide = PlayerPrefs.GetInt("Guide1");
        else
            TempGuide = 0;
    }

    public void SaveGuidesPlayerPref()
    {
        PlayerPrefs.SetInt("Guide1", tempGuide);

    }

    public void Guide_Line()
    {
        int nextObjectIndex = _selectedObjectIndex;
        if (nextObjectIndex < guides.Length)
        {
            nextObjectIndex += 1;
            SelectObject(nextObjectIndex);
        }
    }
}