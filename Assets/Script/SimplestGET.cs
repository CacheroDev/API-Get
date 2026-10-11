using System.Collections;

using UnityEngine;
using UnityEngine.Networking;

public class SimplestGET : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        string url = "https://jsonplaceholder.typicode.com/todos/1";

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            string json = request.downloadHandler.text;
            Debug.Log(json);
        }
    }
}
