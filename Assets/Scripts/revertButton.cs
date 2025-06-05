using System.Collections;
using UnityEngine;

public class revertButton : MonoBehaviour
{
    public void Invert()
    {
        Resources1.isInvert = !Resources1.isInvert;
    }
}
