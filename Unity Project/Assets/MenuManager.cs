using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Play;

    public void _Play()
    {
        Play.gameObject.SetActive(false);
    }
}
