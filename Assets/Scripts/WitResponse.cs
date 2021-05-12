using System.Collections.Generic;
using System;
using Newtonsoft.Json.Serialization;

// classes converted from JSON responses

public class DoorEntity
{
    public string body { get; set; }
    public double confidence { get; set; }
    public int end { get; set; }
    public List<object> entities { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public string role { get; set; }
    public int start { get; set; }
    public bool suggested { get; set; }
    public string type { get; set; }
    public string value { get; set; }
}

public class Entities
{
    // [JsonPropertyName("door:entity")]
    public List<DoorEntity> DoorEntity { get; set; }
}

public class Intent
{
    public double confidence { get; set; }
    public string id { get; set; }
    public string name { get; set; }
}

public class Traits
{
}

public class Root
{
    public Entities entities { get; set; }
    public List<Intent> intents { get; set; }
    public string text { get; set; }
    public Traits traits { get; set; }
}