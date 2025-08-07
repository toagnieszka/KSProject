namespace KSProject.Patterns.ResultPattern
{
    public sealed record Error(string Code, string Descript)
	{
		public static readonly Error None = new Error("None", "No error");
	}
}
