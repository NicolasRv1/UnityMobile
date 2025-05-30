using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    [Header("Input Field")]
    public TMP_InputField txtUsername;
    public TMP_InputField txtPassword;
    public TMP_Text txtError;
    private IEnumerator coroutine;

    public void OpenKeyboard()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OpenCreateScene()
    {
        SceneManager.LoadScene("CreateUserScene");
    }

    public void Login()
    {
        var login = new LoginRequest
        {
            username = txtUsername.text,
            password = txtPassword.text
        };

        coroutine = NetworkService.Login(login, txtError);
        StartCoroutine(coroutine);
    }
}
