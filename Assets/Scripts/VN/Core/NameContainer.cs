using UnityEngine;
using TMPro;

namespace DIALOGUE
{
    [System.Serializable]
    public class NameContainer
    {
        [SerializeField] private GameObject root;
        [SerializeField] private TextMeshProUGUI namaCharText;

        public void Show(string nameToShow = "")
        {
            root.SetActive(true);

            if (nameToShow != string.Empty)
            {
                namaCharText.text = nameToShow;
            }
        }

        public void Hide()
        {
            root.SetActive(false);
        }
    }
}