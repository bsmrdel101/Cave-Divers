using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace BEAN 
{
    public class NetworkManagerUI : MonoBehaviour
    {
        [SerializeField] private Button hostBtn;
        [SerializeField] private Button clientBtn;


        void Awake()
        {
            hostBtn.onClick.AddListener(() => {
                NetworkManager.Singleton.StartHost();
            });
            clientBtn.onClick.AddListener(() => {
                NetworkManager.Singleton.StartClient();
            });
        }
    }
}
