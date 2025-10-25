namespace lorena_bodnarescu_lab2.ultimul.Models
{
    public class AssignedCategoryData
    {
        public int CategoryID { get; set; }      // trebuie să fie PUBLIC
        public string? CategoryName { get; set; } // folosește CategoryName, nu Name
        public bool Assigned { get; set; }
    }
}
