using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class JoinGame : MonoBehaviour
{
    List<GameObject> roomList = new List<GameObject>();
    
    private NetworkManager networkManager;
    [SerializeField]
    private GameObject roomListItemPrefab;
    
    [SerializeField]
    private Text status;

    [SerializeField]
    private Transform roomListParent;

    private void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }

        RefreshRoomList();

    }

    public void RefreshRoomList()
    {
        networkManager.matchMaker.ListMatches(0, 20, "", false, 0, 0, OnMatchList);
        status.text = "Loading...";
    }

    public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {


        foreach (MatchInfoSnapshot match in matches)
        {
            GameObject _roomListItemGO = Instantiate(roomListItemPrefab);
            _roomListItemGO.transform.SetParent (roomListParent);
            roomList.Add (_roomListItemGO);
        }

        if (roomList.Count == 0)
        {
            status.text = "No rooms at the moment.";
        }

            status.text = "";

        if (matches == null)
        {
            status.text = "Couldn't get room list";
            return;
        }

        ClearRoomList();
        

    }

    private void ClearRoomList()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            Destroy(roomList[i]);
        }

        roomList.Clear();
    }

   
}
