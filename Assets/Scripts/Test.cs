using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MaterialSelection {
    public MyEnum enumVal;
    public Material mat;
}

public enum MyEnum {
    ONE,
    TWO,
}
public class Test : MonoBehaviour {
    public List<MaterialSelection> materials;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
