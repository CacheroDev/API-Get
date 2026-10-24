using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class ToDos4
{
    public int userId;
    public int id;
    public string title;
    public bool completed;
}

[System.Serializable]
public class ToDos4Wrapper
{
    public List<ToDos4> items;
}

public class Get_BearerToken : MonoBehaviour
{
    [SerializeField] int userId;
    [SerializeField] int id;
    [SerializeField] string title;
    [SerializeField] bool completed;

    [SerializeField] string token;

    void Start()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        //string url = "https://jsonplaceholder.typicode.com/todos";
        string url = "http://localhost/todo/api/todo.php";

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Authorization", "Bearer " + token);
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
                yield break;
            }

            string json = request.downloadHandler.text;
            string wrappedJson = "{\"items\":" + json + "}";

            ToDos4Wrapper wrapper = JsonUtility.FromJson<ToDos4Wrapper>(wrappedJson);

            if (wrapper.items != null && wrapper.items.Count > 0)
            {
                ToDos4 todos4 = wrapper.items[0];

                userId = todos4.userId;
                id = todos4.id;
                title = todos4.title;
                completed = todos4.completed;

                Debug.Log(userId);
                Debug.Log(id);
                Debug.Log(title);
                Debug.Log(completed);
            }
        }
    }
}
