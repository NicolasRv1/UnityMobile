using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NetworkService : MonoBehaviour
{
    public static IEnumerator Login(LoginRequest request, TMP_Text txtError)
    {
        string jsondata = JsonUtility.ToJson(request);

        using (UnityWebRequest req = UnityWebRequest.PostWwwForm(Resources.BaseURL + Resources.LoginPath, "POST"))
        {
            req.method = "POST";
            req.SetRequestHeader("Content-Type", "application/json");
            req.SetRequestHeader("Accept", "application/json");
            req.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsondata));

            yield return req.SendWebRequest();

            if (req.result != UnityWebRequest.Result.Success)
            {
                txtError.text = req.downloadHandler.text;
            }
            else
            {
                LoginResponse res = JsonUtility.FromJson<LoginResponse>(req.downloadHandler.text);

                PlayerPrefs.SetString(Resources.APIKEY, JsonUtility.ToJson(res));

                SceneManager.LoadScene(Resources.Screen.PrincipalScreen);
            }
        }
    }
}
