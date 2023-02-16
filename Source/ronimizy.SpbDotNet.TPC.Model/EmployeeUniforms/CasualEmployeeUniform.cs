namespace ronimizy.SpbDotNet.TPC.Model.EmployeeUniforms;

public class CasualEmployeeUniform : EmployeeUniform
{
    public int ShirtColorArgb { get; set; }
    public string ShirtName { get; set; }
    public int ShirtMostPopularSize { get; set; }
    
    public int JeansColorArgb { get; set; }
    public string JeansName { get; set; }
    public int JeansMostPopularSize { get; set; }
    
    public int ShoesColorArgb { get; set; }
    public string ShoesName { get; set; }
    public int ShoesMostPopularSize { get; set; }

    public bool HoodieAllowed { get; set; }
}