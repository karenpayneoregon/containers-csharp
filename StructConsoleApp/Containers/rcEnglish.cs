namespace StructConsoleApp.Containers
{
    public struct rcEnglish
    {
        string _continue;
        public string Continue
        {
            get => _continue ?? "Continue";
            set => _continue = value;
        }
    }
}