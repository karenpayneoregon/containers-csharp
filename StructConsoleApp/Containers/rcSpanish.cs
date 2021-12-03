namespace StructConsoleApp.Containers
{
    public struct rcSpanish
    {
        string _continue;
        public string Continue
        {
            get => _continue ?? "Continuar";
            set => _continue = value;
        }
    }
}