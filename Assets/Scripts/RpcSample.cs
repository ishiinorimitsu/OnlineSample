using UnityEngine;
using Photon.Pun;

public class RpcSample : MonoBehaviourPunCallbacks
{
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RpcSendMessage("‚±‚ñ‚É‚¿‚Í");
            photonView.RPC(nameof(RpcSendMessage), RpcTarget.All, "‚±‚ñ‚É‚¿‚Í");
        }
    }

    [PunRPC]
    private void RpcSendMessage(string message)
    {
        Debug.Log(message);
    }
}
