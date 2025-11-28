namespace JsonSDK;

public static class Validator
{
	/// <summary>
	/// Ensures the provided JSON string is not null and is valid JSON.
	/// Throws an exception if the input is invalid.
	/// </summary>
	/// <param name="json">The JSON string to check.</param>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="json"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown if <paramref name="json"/> is not valid JSON.</exception>
	public static void ValidatorJson(string json)
	{
		if (json is null)
			throw new ArgumentNullException(nameof(json));
		if (!IsValidJson(json))
			throw new ArgumentException("Invalid JSON format", nameof(json));
	}

	/// <summary>
	/// Validates whether the provided string is a syntactically correct JSON value.
	/// </summary>
	/// <param name="json">The JSON string to validate.</param>
	/// <returns>True if the string is valid JSON, otherwise false.</returns>
	private static bool IsValidJson(string json)
	{
		if (json is null)
			return false;
		try
		{
			System.Text.Json.JsonDocument.Parse(json);
			return true;
		}
		catch
		{
			return false;
		}
	}
}
