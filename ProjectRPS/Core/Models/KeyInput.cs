using System.Text.Json.Serialization;

namespace ProjectRPS.Core.Models;

public class KeyInput
{
    [JsonPropertyName("input")]
    public string Input { get; set; }
}