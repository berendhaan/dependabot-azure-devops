﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Tingle.Dependabot.Models;

public sealed class DependabotUpdateJobDefinition
{
    [JsonPropertyName("job")]
    public required JsonObject? Job { get; set; }

    [JsonPropertyName("credentials")]
    public required JsonArray Credentials { get; set; }
}

public sealed class CreatePullRequestModel
{
    [Required]
    [MinLength(1)]
    [JsonPropertyName("dependencies")]
    public List<ChangedDependency>? Dependencies { get; set; }

    [Required]
    [MinLength(1)]
    [JsonPropertyName("updated-dependency-files")]
    public List<UpdatedDependencyFile>? DependencyFiles { get; set; }

    [JsonPropertyName("base-commit-sha")]
    public string? BaseCommitSha { get; set; }

    [JsonExtensionData]
    public Dictionary<string, object>? Extensions { get; set; }
}

public sealed class ChangedDependency
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("previous-version")]
    public string? PreviousVersion { get; set; }

    [Required]
    [JsonPropertyName("requirements")]
    public JsonArray? Requirements { get; set; }

    [JsonPropertyName("previous-requirements")]
    public string? PreviousRequirements { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("removed")]
    public bool? Removed { get; set; }
}

public sealed class UpdatePullRequestModel
{
    [Required]
    [MinLength(1)]
    [JsonPropertyName("dependency-names")]
    public List<string>? DependencyNames { get; set; }

    [Required]
    [MinLength(1)]
    [JsonPropertyName("updated-dependency-files")]
    public List<UpdatedDependencyFile>? DependencyFiles { get; set; }

    [JsonPropertyName("base-commit-sha")]
    public string? BaseCommitSha { get; set; }

    [JsonExtensionData]
    public Dictionary<string, object>? Extensions { get; set; }
}

public sealed class UpdatedDependencyFile
{
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("content_encoding")]
    public string? ContentEncoding { get; set; }

    [JsonPropertyName("deleted")]
    public bool? Deleted { get; set; }

    [JsonPropertyName("directory")]
    public string? Directory { get; set; }

    [JsonPropertyName("mode")]
    public string? Mode { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("operation")]
    public string? Operation { get; set; } // convert from string to enum once we know all possible values

    [JsonPropertyName("support_file")]
    public bool? SupportFile { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; } // convert from string to enum once we know all possible values
}

public sealed class ClosePullRequestModel
{
    //[Required]
    //[MinLength(1)]
    //[JsonPropertyName("dependency-names")]
    //public List<string>? DependencyNames { get; set; } // This can also be a string that's why it has not been enabled

    [JsonPropertyName("reason")]
    public string? Reason { get; set; } // convert from string to enum once we know all possible values

    [JsonExtensionData]
    public Dictionary<string, object>? Extensions { get; set; }
}

public sealed class RecordUpdateJobErrorModel
{
    [JsonPropertyName("error-type")]
    public string? ErrorType { get; set; }

    [JsonPropertyName("error-detail")]
    public JsonNode? ErrorDetail { get; set; }

    [JsonExtensionData]
    public Dictionary<string, object>? Extensions { get; set; }
}

public sealed class MarkAsProcessedModel
{
    [JsonPropertyName("base-commit-sha")]
    public string? BaseCommitSha { get; set; }

    [JsonExtensionData]
    public Dictionary<string, object>? Extensions { get; set; }
}

public sealed class UpdateDependencyListModel
{
    [Required]
    [JsonPropertyName("dependencies")]
    public JsonArray? Dependencies { get; set; }

    [Required]
    [MinLength(1)]
    [JsonPropertyName("dependency_files")]
    public List<string>? DependencyFiles { get; set; }

    [JsonExtensionData]
    public Dictionary<string, object>? Extensions { get; set; }
}