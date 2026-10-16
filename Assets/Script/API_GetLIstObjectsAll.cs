using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class ToDos2
{
    public int userId;
    public int id;
    public string title;
    public bool completed;
}

[System.Serializable]
public class Todos2Wrapper
{
    public List<ToDos2> items;
}

public class API_GetLIstObjectsAll : MonoBehaviour
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
        string url = "https://jsonplaceholder.typicode.com/todos";

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
                yield break;
            }

            string json = request.downloadHandler.text;
            string wrappedJson = "{\"items\":" + json + "}";

            Todos2Wrapper wrapper = JsonUtility.FromJson<Todos2Wrapper>(wrappedJson);

            if (wrapper.items != null && wrapper.items.Count > 0)
            {
                for (int i = 0; i < wrapper.items.Count; i++)
                {
                    ToDos2 todos2 = wrapper.items[i];

                    userId = todos2.userId;
                    id = todos2.id;
                    title = todos2.title;
                    completed = todos2.completed;

                    Debug.Log(userId);
                    Debug.Log(id);
                    Debug.Log(title);
                    Debug.Log(completed);
                }
            }
        }
    }
}
