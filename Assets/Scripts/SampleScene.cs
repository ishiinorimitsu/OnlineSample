using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class SampleScene : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private void Start()
    {
        //プレイヤー自身の名前を”Player”に設定する。
        PhotonNetwork.NickName = "Player";

        //PhotonServerSettingsの設定内容を利用してマスターサーバーに接続する。
        PhotonNetwork.ConnectUsingSettings();
    }

    //マスターサーバーへの接続が完了したときに呼ばれる処理（11行目が動いてOKだったら呼ばれる。）
    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();

        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);      //引数（作成する部屋の名前、部屋のオプション設定、ロビーの初期設定）
        //まず既に”Room”という名前の部屋があるか検索、あれば入る、なければ作る。
    }

    public override void OnJoinedRoom()     //部屋に入ったときに自動的に呼ばれる。
    {
        //base.OnJoinedRoom();
        // ランダムな座標に自身のアバター（ネットワークオブジェクト）を生成する
        Vector3 position = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3));

        PhotonNetwork.Instantiate("Avatar",position,Quaternion.identity);       //引数（Resourceフォルダにあるゲームオブジェクトの名前、どこに、どんな向きで）
    }
}
