using System.Collections.Generic;
using UnityEngine;


class Artifact : MonoBehaviour
{
    private List<int> _artefacts = new List<int>();
    public Artifact()
    {
    }

    public List<int> GetListOfArtefacts()
    {
        return _artefacts;
    }

    public void AddNewArtifact(int id)
    {
        if (!_artefacts.Contains(id))
        {
            _artefacts.Add(id);
        }
    }

    void Start()
    {

    }
}

