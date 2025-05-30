using TMPro;
using UnityEngine;

public class PrincipalController : MonoBehaviour
{
    public TMP_Text lblUsername;
    public TMP_Text update;
    public TMP_Text fixed_update;

    private int contadorUpdate;
    private int contadorFixed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lblUsername.text = PlayerPrefs.GetString("Username");
    }

    // Update is called once per frame
    void Update()
    {
        update.text = contadorUpdate.ToString();
        contadorUpdate++;
    }

    private void FixedUpdate()
    {
        fixed_update.text = contadorFixed.ToString();
        contadorFixed++;
    }
}
