namespace JsonSDK;

public sealed class JsonValidationResult
{
	public bool IsValid { get; init; }
	public string? ErrorMessage { get; init; }
	public long? Line { get; init; }
	public long? Column { get; init; }
	public Exception? Exception { get; init; }

	public static JsonValidationResult Success()
		=> new() { IsValid = true };
}
