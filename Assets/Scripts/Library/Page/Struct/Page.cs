using System;

namespace UnityHooksLibrary.Page
{
    [Serializable]
    public class Page
    {
        public string name;
        public object rawData;
        public string[] scenes;

        public Page(string name, params string[] scenes)
        {
            this.name = name;
            this.scenes = scenes;
        }
    }
}