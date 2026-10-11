using System.Collections;

using UnityEngine;
using UnityEngine.Networking;

public class GET_RequestResult : MonoBehaviour
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
            
            if (request.result != UnityWebRequest.Result.Success)       //Check request result if successful
            {
                Debug.LogError($"{request.result} | {request.responseCode} | {request.error}");
                yield break;
            }
            
            string json = request.downloadHandler.text;                 
            Debug.Log(json);
        }
    }
}
