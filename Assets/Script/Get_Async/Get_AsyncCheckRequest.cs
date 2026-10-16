

using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class Get_AsyncCheckRequest : MonoBehaviour
{
    async void Start()
    {
        string url = "https://jsonplaceholder.typicode.com/todos/1";
        //string url = "http://localhost/api/users.php";

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            var operation = request.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();
            
            if (request.result != UnityWebRequest.Result.Success)
                Debug.Log(request.error);
            else
                Debug.Log(request.downloadHandler.text);
        }
    }
}
