using JustLogic.Core;

partial class JLUnitEditorWindow
{
    private class Unit
    {
        public TypeInfo Type { get; private set; }

        public Unit(string path, TypeInfo type)
        {
            Path = path;
            Type = type;
            string[] parts = path.Split('/');
            if (parts.Length < 2)
            {
                CategoryPath = string.Empty;
                CategoryName = string.Empty;
                CategoryPathSlashed = string.Empty;
                Name = path;
            }
            else
            {
                CategoryPath = string.Join("/", parts, 0, parts.Length - 1);
                CategoryName = parts[parts.Length - 2];
                CategoryPathSlashed = CategoryName + "/";
                Name = parts[parts.Length - 1];
                CategoryLevel = parts.Length - 1;
                ParentCategoryPath = CategoryLevel >= 2 ? string.Join("/", parts, 0, parts.Length - 2) : string.Empty;
            }
        }

        public string Path { get; private set; }
        public string Name { get; private set; }
        public int CategoryLevel { get; private set; }
        public string ParentCategoryPath { get; private set; }
        public string CategoryPath { get; private set; }
        public string CategoryPathSlashed { get; private set; }
        public string CategoryName { get; private set; }
    }

}
