using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        // Gera uma cor aleatória
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        // Empacota a cor como 3 floats (R, G, B)
        object[] instantiationData = new object[] { randomColor.r, randomColor.g, randomColor.b };


        Vector2 spawnPos = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        PhotonNetwork.Instantiate("Player", spawnPos, Quaternion.identity, 0, instantiationData);

    }
}
