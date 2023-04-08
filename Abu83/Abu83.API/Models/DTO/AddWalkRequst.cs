namespace Abu83.API.Models.DTO
{
    public class AddWalkRequst
    {
        
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
    }
}
