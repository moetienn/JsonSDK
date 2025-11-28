using System.Text.Json;
namespace JsonSDK;

public static class Validator
{
	/// <summary>
	/// Validates whether the provided string is a syntactically correct JSON value.
	/// Parses the input JSON and returns a <see cref="JsonValidationResult"/> indicating validity and error details if invalid.
	/// </summary>
	/// <param name="json">The JSON string to validate.</param>
	/// <returns>
	/// A <see cref="JsonValidationResult"/> object containing:
	/// <list type="bullet">
	/// <item><description><c>IsValid</c>: <c>true</c> if the JSON is valid, <c>false</c> otherwise.</description></item>
	/// <item><description><c>ErrorMessage</c>: The error message if invalid, otherwise <c>null</c>.</description></item>
	/// <item><description><c>Line</c>: The line number of the error if invalid, otherwise <c>null</c>.</description></item>
	/// <item><description><c>Column</c>: The column (byte position) of the error if invalid, otherwise <c>null</c>.</description></item>
	/// <item><description><c>Exception</c>: The <see cref="JsonException"/> thrown if invalid, otherwise <c>null</c>.</description></item>
	/// </list>
	/// </returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="json"/> is <c>null</c>.</exception>
	public static JsonValidationResult Validate(string json)
	{
		if (json is null)
			throw new ArgumentNullException(nameof(json));

		try
		{
			using var doc = JsonDocument.Parse(json);
			return JsonValidationResult.Success();
		}
		catch (JsonException ex)
		{
			return new JsonValidationResult
			{
				IsValid = false,
				ErrorMessage = ex.Message,
				Line = ex.LineNumber,
				Column = ex.BytePositionInLine >= 0 ? (long?)(ex.BytePositionInLine + 1) : null,
				Exception = ex
			};
		}
	}
}
