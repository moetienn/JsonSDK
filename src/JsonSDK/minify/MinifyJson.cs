namespace JsonSDK;

/// <summary>
/// Provides utility methods for JSON manipulation and validation.
/// </summary>
public static class Minify
{
	/// <summary>
	/// Minifies a JSON string by removing all unnecessary whitespace outside of string values.
	/// Throws an exception if the input is null or not valid JSON.
	/// </summary>
	/// <param name="json">The JSON string to minify.</param>
	/// <returns>A minified JSON string with no extra whitespace outside of string values.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="json"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown if <paramref name="json"/> is not valid JSON.</exception>
	public static string MinifyJson(string json, bool validate)
	{
        if (validate)
            Validator.Validate(json);

		var result = new System.Text.StringBuilder(json.Length);
		bool insideString = false;

		for (int i = 0; i < json.Length; i++)
		{
			char c = json[i];

			if (IsQuoteChar(c, i, json))
			{
				insideString = !insideString;
				result.Append(c);
			}
			else if (ShouldIgnoreWhitespace(c, insideString))
				continue;
			else
				result.Append(c);
		}
		return result.ToString();
	}

	/// <summary>
	/// Checks if the given character is a quote character ("), not escaped by a backslash.
	/// Used to determine string boundaries in JSON.
	/// </summary>
	/// <param name="c">The character to check.</param>
	/// <param name="i">The index of the character in the JSON string.</param>
	/// <param name="json">The full JSON string.</param>
	/// <returns>True if the character is a non-escaped quote, otherwise false.</returns>
	private static bool IsQuoteChar(char c, int i, string json)
	{
		return c == '"' && (i == 0 || json[i - 1] != '\\');
	}

	/// <summary>
	/// Determines if the given character is whitespace that should be ignored (not inside a string value).
	/// </summary>
	/// <param name="c">The character to check.</param>
	/// <param name="insideString">True if currently inside a string value, otherwise false.</param>
	/// <returns>True if the whitespace should be ignored, otherwise false.</returns>
	private static bool ShouldIgnoreWhitespace(char c, bool insideString)
	{
		return !insideString && char.IsWhiteSpace(c);
	}
}
