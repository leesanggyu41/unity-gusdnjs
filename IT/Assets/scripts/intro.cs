using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    public int num = 0;
    public Text eoghk;
    public GameObject video;
    public string sceneName;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            num++;
            if (num == 0) {
                eoghk.text += "\n그는 이 마을에서 사람들이 사라진이유을 찾기위해 여기저기 수소문한 결과";
                
            }
            if (num == 1) {
                eoghk.text += "\n 한 집 근처에서 사람들이 사라진다는걸 알게되었다.";  
                
            }
            if (num == 2) {
                eoghk.text += "\n그래서 그는 그집을 수색해보기로 한다.";
                    
            }
            if (num == 3) {
                eoghk.text = "";
                video.SetActive(true);
                StartCoroutine(start());
            }

        }

        IEnumerator start()
        {
            yield return new WaitForSeconds(7.5f);
            SceneManager.LoadScene(sceneName);

        }
    }
}
