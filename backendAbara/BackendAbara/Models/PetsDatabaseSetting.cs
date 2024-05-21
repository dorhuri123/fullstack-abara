namespace BackendAbara.Models;

public class PetsDatabaseSetting
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string PetsCollectionName { get; set; } = null!;
}