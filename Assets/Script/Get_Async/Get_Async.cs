

using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class Get_Async : MonoBehaviour
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
            Debug.Log(request.downloadHandler.text);
        }
    }    
}
