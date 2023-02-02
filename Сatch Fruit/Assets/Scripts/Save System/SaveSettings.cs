using UnityEngine;

namespace SaveSystem
{
    public class SaveSettings : MonoBehaviour
    {
        #region Singeltone: SaveSettings

        public static SaveSettings Instance;

        private void Awake()
        {
            Instance = this;
        }

        #endregion

        #region PlayerPrefs Int
        public void SaveInt(string nameKey, int number)
        {
            PlayerPrefs.SetInt(nameKey, number);
            PlayerPrefs.Save();
        }

        public int LoadInt(string nameKey, int number)
        {
            if (PlayerPrefs.HasKey(nameKey))
            {
                number = PlayerPrefs.GetInt(nameKey);
            }
            return number;
        }

        #endregion

        #region Delete Saves

        public void DeleteAllSaves()
        {
            PlayerPrefs.DeleteAll();
        }

        public void DeleteASpecificSave(string nameSave)
        {
            PlayerPrefs.DeleteKey(nameSave);
        }

        #endregion
    }
}