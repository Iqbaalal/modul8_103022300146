using System;
using System.IO;
using System.Text.Json;

public class BankTransferConvig { 
    public int lang { get; set; }
    public Transfer transfer { get; set; }
    public String[] methods  { get; set; }
    public Confirmation confirmation { get; set; } 
}

public class Transfer {
    public int threshold { get; set; }
    public int low_fee { get; set; }
    public int high_fee { get; set; }
}

public class Confirmation { 
    public String en { get; set; }
    public String id { get; set; }
}

public class UIConfig {
    public BankTransferConvig config;

    public const String filePath = @"bank_transfer_config.json";

    public UIConfig()
    {
        try
        {
            ReadConfigFile();
        }
        catch (Exception)
        {
            SetDefault();
            WriteNewConfigFile();
        }
    }

    private BankTransferConvig ReadConfigFile()
    {
        String configJsonData = File.ReadAllText(filePath);
        config = JsonSerializer.Deserialize<BankTransferConvig>(configJsonData); return config;
    }

    private void SetDefault() {
        "lang": "en”,
        "transfer": {
                "threshold": 2500000,
            "low_fee": 6500,
            "high_fee": 15000
        },
        "methods": ["“RTO", "(real-time)”", "“SKN”", "“RTGS”", "“BI", "FAST”"],
        "confirmation": {
            "en": "yes”,,
            "id": "ya”
        }
    }

    private void WriteNewConfigFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        String jsonString = JsonSerializer.Serialize(config, options);
        File.WriteAllText(filePath, jsonString);
    }

}