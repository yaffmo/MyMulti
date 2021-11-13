using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{

    [SerializeField]
    TMP_Text playerDisplayName;

    [SyncVar(hook = nameof(HandlePlayerDisplayNameUpdated))]
    string playerSyncName;

    [Server]
    public void SetPlayerDisplayName(string newDisplayName)
    {
        playerSyncName = newDisplayName;
    }

    private void HandlePlayerDisplayNameUpdated(string oldName, string newName)
    {
        playerDisplayName.text = newName;
    }



}
