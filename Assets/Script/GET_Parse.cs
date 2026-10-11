using System.Collections;

using UnityEngine;
using UnityEngine.Networking;

public class ToDo
{
    public int userId;
    public int id;
    public string title;
    public bool completed;
}

public class GET_Parse : MonoBehaviour
{
    [SerializeField] int userId;
    [SerializeField] int id;
    [SerializeField] string title;
    [SerializeField] bool completed;

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

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
                yield break;
            }

            string json = request.downloadHandler.text;
            Debug.Log(json);

            ToDo todo = JsonUtility.FromJson<ToDo>(json);

            id = todo.id;
            userId = todo.userId;
            title = todo.title;
            completed = todo.completed;

            Debug.Log(userId);
            Debug.Log(id);
            Debug.Log(title);
            Debug.Log(completed);
        }
    }
}
