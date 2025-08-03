using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // chamado ao clicar no botão
    public void Connect()
    {
        Debug.Log("Conectando ao Photon...");
        PhotonNetwork.ConnectUsingSettings(); // Usa o AppID do Photon que você colocou antes
    }

    // Callback quando conectado ao servidor
    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado ao servidor Photon.");
        PhotonNetwork.JoinRandomRoom();
        //PhotonNetwork.JoinLobby();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Nenhuma sala encontrada. Criando nova sala...");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Entrou em uma sala!");
        PhotonNetwork.LoadLevel("GameScene");
    }



    public override void OnJoinedLobby()
    {
        Debug.Log("Entrou no Lobby. Indo para a GameScene...");
        SceneManager.LoadScene("GameScene"); // Nome exato da próxima cena
    }
}
