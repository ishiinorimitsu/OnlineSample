using UnityEngine;
using Photon.Pun;

public class RpcSample : MonoBehaviourPunCallbacks
{
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RpcSendMessage("こんにちは");
            photonView.RPC(nameof(RpcSendMessage), RpcTarget.All, "こんにちは");
        }
    }

    [PunRPC]
    private void RpcSendMessage(string message)
    {
        Debug.Log(message);
    }
}
