using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerSystem : MonoBehaviour
{

    public static UIManagerSystem instance;

    #region Singleton
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            if (instance !=this)
            {
                Destroy(instance);
            }
        }
    }
    #endregion
    [SerializeField]
    private GameObject _currentPanel;
    [SerializeField]
    private GameObject _previousPanel;
    [SerializeField]
    private List<GameObject> _openedPanels = new List<GameObject>();

    private void Start()
    {
        _openedPanels.Add(_currentPanel);
    }

    private void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    private void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void SetCurrentPanel(GameObject panel,bool isOpen)
    {
        if (isOpen)
        {
            _openedPanels.Add(panel);
            _currentPanel = _openedPanels[_openedPanels.Count - 1];
            _previousPanel= _openedPanels[_openedPanels.Count - 2];
            OpenPanel(_currentPanel);
            ClosePanel(_previousPanel);
        }
        else
        {
            ClosePanel(_currentPanel);
            _openedPanels.Remove(panel);
            _currentPanel = _openedPanels[_openedPanels.Count - 1];
            OpenPanel(_currentPanel);
            if (_openedPanels.Count > 1)
            {
                _previousPanel = _openedPanels[_openedPanels.Count - 2];
            }
            else
            {
                _previousPanel = null;
            }
        } 
    }


}
