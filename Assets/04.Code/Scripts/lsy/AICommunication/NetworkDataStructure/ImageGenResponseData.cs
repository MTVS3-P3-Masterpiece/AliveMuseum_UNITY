using Newtonsoft.Json;

public class ImageGenResponseData
{
    [JsonProperty("generated_images")]
    public string[] generated_images;
}