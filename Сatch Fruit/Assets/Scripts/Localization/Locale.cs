using System.Collections.Generic;
using UnityEngine;
using SaveSystem;

namespace Localization
{
    public static class Locale
    {
        private const string STR_LOCALIZATION_KEY = "locale";
        private const string STR_LOCALIZATION_PREFIX = "Localization/";

        public static string currentLanguage;
        public static bool currentLanguageHasBeenSet = false;

        public static Dictionary<string, string> CurrentLanguageStrings = new Dictionary<string, string>();
        public static TextAsset currentLocalizationText;

        public static string CurrentLanguage
        {
            get { return currentLanguage; }
            set{
                if (value != null && value.Trim() != string.Empty){
                    currentLanguage = value;
                    currentLocalizationText = Resources.Load(STR_LOCALIZATION_PREFIX + currentLanguage, typeof(TextAsset)) as TextAsset;
                    if (currentLocalizationText == null){
                        Debug.LogWarningFormat("Missing locale '{0}', loading English.", currentLanguage);
                        currentLanguage = SystemLanguage.English.ToString();
                        currentLocalizationText = Resources.Load(STR_LOCALIZATION_PREFIX + currentLanguage, typeof(TextAsset)) as TextAsset;
                    }
                    if (currentLocalizationText != null){
                        string[] lines = currentLocalizationText.text.Split(new string[] { "\r\n", "\n\r", "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
                        CurrentLanguageStrings.Clear();
                        for (int i = 0; i < lines.Length; i++){
                            string[] pairs = lines[i].Split(new char[] { '\t', '=' }, 2);
                            if (pairs.Length == 2){
                                CurrentLanguageStrings.Add(pairs[0].Trim(), pairs[1].Trim());
                            }
                        }
                    }else{
                        Debug.LogErrorFormat("Local language '{0}', not found!", currentLanguage);
                    }
                }
            }


        }

        public static bool CurrentLanguageHasBeenSet{
            get{
                return currentLanguageHasBeenSet;
            }
        }

        public static SystemLanguage PlayerLanguage{
            get{
               return (SystemLanguage)SaveSettings.Instance.LoadInt(STR_LOCALIZATION_KEY, (int)Application.systemLanguage);
            }
            set{
                SaveSettings.Instance.SaveInt(STR_LOCALIZATION_KEY, (int)value);
            }
        }
    }
}