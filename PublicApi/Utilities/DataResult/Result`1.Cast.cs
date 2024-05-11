﻿namespace LightResults;

partial struct Result<TValue>
{
    /// <summary>Implicitly converts a value to a success <see cref="Result{TValue}"/>.</summary>
    /// <param name="value">The value to convert into a success result.</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> representing a success result with the specified value.</returns>
    public static implicit operator Result<TValue>(TValue value)
    {
        return Ok(value);
    }
}
