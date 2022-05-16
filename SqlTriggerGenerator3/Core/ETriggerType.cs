namespace SqlTriggerGenerator2
{
    public enum ETriggerType
    {
        None,
        Insert,
        Update,
        Delete
    }

    public static class ETriggerTypeExtensions
    {
        public static string GetName(this ETriggerType value)
        {
            return System.Enum.GetName(typeof(ETriggerType), value);
        }
    }
}
